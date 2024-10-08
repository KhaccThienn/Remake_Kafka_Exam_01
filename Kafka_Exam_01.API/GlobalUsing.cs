﻿global using System;
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

global using Kafka_Exam_01.API.Extensions;
global using Kafka_Exam_01.API.IServices;
global using Kafka_Exam_01.API.Services;

global using Kafka_Exam_01.Infrastructure.DataContext;
global using Kafka_Exam_01.Infrastructure.Domain;
global using Kafka_Exam_01.Infrastructure.DTOs;
global using Kafka_Exam_01.Infrastructure.InMemories;
global using Kafka_Exam_01.Infrastructure.IProducers;
global using Kafka_Exam_01.Infrastructure.Producers;
global using Kafka_Exam_01.Infrastructure.Requests;
global using Kafka_Exam_01.Infrastructure.SeedDataAsync; 
global using Kafka_Exam_01.Infrastructure.Extensions;
