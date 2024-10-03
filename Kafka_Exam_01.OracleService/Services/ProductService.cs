﻿namespace Kafka_Exam_01.OracleService.Services
{
    public class ProductService : IProductService
    {
        private readonly IServiceScopeFactory    _scopeFactory;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger       = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task<TableProduct> InsertProduct(TableProduct p)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                // Use dbContext here
                try
                {
                    await dbContext.TableProducts.AddAsync(p);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return p;
        }

        public async Task<TableProduct?> UpdatePrice(decimal productId, decimal price)
        {

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            // Use dbContext here
            var product = await dbContext.TableProducts.FirstOrDefaultAsync(p => p.Id == productId);

            bool flag     = true;
            if (product != null)
            {
                product.Id    = productId;
                product.Price = price;

                if (price < 0)
                {
                    flag = false;
                }
                if (flag)
                {
                    try
                    {
                        dbContext.TableProducts.Update(product);
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                _logger.LogError("Product Not Found");
            }
            return product;
        }

        public async Task<TableProduct?> UpdateQuantity(decimal productId, decimal quantity, bool Increase)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext   = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var product     = await dbContext.TableProducts.FirstOrDefaultAsync(p => p.Id == productId);

            bool flag = true;
            if (product != null)
            {
                if (Increase)
                {
                    product.Quantity += quantity;
                }
                else
                {
                    if (quantity > product.Quantity)
                    {
                        flag = false;
                    }
                    else
                    {
                        product.Quantity -= quantity;
                    }
                }
                if (flag)
                {
                    try
                    {
                        dbContext.TableProducts.Update(product);
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                _logger.LogError("Product Not Found");
            }
            return product;
        }
    }
}
