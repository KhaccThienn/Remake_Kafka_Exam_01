global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Text.Json;
global using System.Threading.Tasks;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Logging;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using Confluent.Kafka;
global using Manonero.MessageBus.Kafka.Abstractions;
global using Manonero.MessageBus.Kafka.Settings;

global using Kafka_Exam_01.Infrastructure.DataContext;
global using Kafka_Exam_01.Infrastructure.Domain;
global using Kafka_Exam_01.Infrastructure.DTOs;
global using Kafka_Exam_01.Infrastructure.InMemories;
global using Kafka_Exam_01.Infrastructure.IProducers;
global using Kafka_Exam_01.Infrastructure.Producers;
global using Kafka_Exam_01.Infrastructure.Requests;
global using Kafka_Exam_01.Infrastructure.SeedDataAsync;
global using Kafka_Exam_01.Infrastructure.Settings;
