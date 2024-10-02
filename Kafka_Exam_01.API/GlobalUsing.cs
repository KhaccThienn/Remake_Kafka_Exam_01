global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Text.Json;
global using Microsoft.EntityFrameworkCore;
global using Confluent.Kafka;
global using Manonero.MessageBus.Kafka.Abstractions;
global using static Confluent.Kafka.ConfigPropertyNames;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;

global using Kafka_Exam_01.API.Core.DataContext;
global using Kafka_Exam_01.API.Core.Domain;
global using Kafka_Exam_01.API.Core.DTOs;
global using Kafka_Exam_01.API.Core.InMemories;
global using Kafka_Exam_01.API.Core.IProducers;
global using Kafka_Exam_01.API.Core.IServices;
global using Kafka_Exam_01.API.Core.Requests;
global using Kafka_Exam_01.API.Core.SeedDataAsync; 

global using Kafka_Exam_01.API.Extensions;
global using Kafka_Exam_01.API.Producers;
global using Kafka_Exam_01.API.Services;