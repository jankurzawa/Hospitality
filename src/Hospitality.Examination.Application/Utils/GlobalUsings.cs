global using AutoMapper;
global using Azure.Storage.Queues;
global using Hospitality.Common.DTO.Examination;
global using Hospitality.Examination.Application.Contracts.Persistence;
global using Hospitality.Examination.Application.Functions.Examinations.Commands;
global using Hospitality.Examination.Application.Services;
global using Hospitality.Examination.Domain.Entities.Enums;
global using Hospitality.Examination.Domain.Entities;
global using Hospitality.Examination.RabbitMQ;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Newtonsoft.Json;
global using RabbitMQ.Client.Events;
global using RabbitMQ.Client;
global using System.Diagnostics;
global using System.Reflection;
global using System.Text;