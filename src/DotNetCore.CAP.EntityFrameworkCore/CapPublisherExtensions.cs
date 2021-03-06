﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DotNetCore.CAP.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DotNetCore.CAP.Infrastructure;

namespace DotNetCore.CAP
{
    static class CapPublisherExtensions
    {
        public static async Task Publish(this ICapPublisher publisher, string topic, string content, DatabaseFacade database)
        {
            var connection = database.GetDbConnection();
            var transaction = database.CurrentTransaction;
            transaction = transaction ?? await database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            var message = new CapSentMessage
            {
                KeyName = topic,
                Content = content,
                StatusName = StatusName.Enqueued
            };

            var sql = "INSERT INTO [cap].[CapSentMessages] ([Id],[Added],[Content],[KeyName],[LastRun],[Retries],[StatusName])VALUES(@Id,@Added,@Content,@KeyName,@LastRun,@Retries,@StatusName)";
            await connection.ExecuteAsync(sql, transaction);

            JobQueuer.PulseEvent.Set();

        }

        public static async Task<int> Publish(this ICapPublisher publisher, string topic, string content, IDbConnection connection,IDbTransaction transaction)
        {
            var message = new CapSentMessage
            {
                KeyName = topic,
                Content = content,
                StatusName = StatusName.Enqueued
            };

            var sql = "INSERT INTO [cap].[CapSentMessages] ([Id],[Added],[Content],[KeyName],[LastRun],[Retries],[StatusName])VALUES(@Id,@Added,@Content,@KeyName,@LastRun,@Retries,@StatusName)";
            return await connection.ExecuteAsync(sql, transaction);

            JobQueuer.PulseEvent.Set();
        }

    }
}