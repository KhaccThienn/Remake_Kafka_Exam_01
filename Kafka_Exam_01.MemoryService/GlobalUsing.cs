global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Text.Json;
global using System.Threading.Tasks;
global using Microsoft.EntityFrameworkCore;
global using Confluent.Kafka;
global using Manonero.MessageBus.Kafka.Abstractions;
global using Manonero.MessageBus.Kafka.Settings;
global using static Confluent.Kafka.ConfigPropertyNames;

global using Kafka_Exam_01.Infrastructure.DataContext;
global using Kafka_Exam_01.Infrastructure.Domain;
global using Kafka_Exam_01.Infrastructure.DTOs;
global using Kafka_Exam_01.Infrastructure.InMemories;
global using Kafka_Exam_01.Infrastructure.IProducers;
global using Kafka_Exam_01.Infrastructure.Requests;
global using Kafka_Exam_01.Infrastructure.SeedDataAsync;
global using Kafka_Exam_01.Infrastructure.Settings;

global using Kafka_Exam_01.MemoryService.Commands.CommandModels;
global using Kafka_Exam_01.MemoryService.Commands.Handlers;
global using Kafka_Exam_01.MemoryService.Interfaces;
global using Kafka_Exam_01.MemoryService.Interfaces.Commands;
global using Kafka_Exam_01.MemoryService.IServices;
global using Kafka_Exam_01.MemoryService.Services;

global using Kafka_Exam_01.MemoryService.BackgroundTasks;

global using Kafka_Exam_01.MemoryService;
global using Kafka_Exam_01.MemoryService.Extensions;
