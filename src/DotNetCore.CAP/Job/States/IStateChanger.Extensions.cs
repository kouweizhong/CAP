﻿using System.Threading.Tasks;
using DotNetCore.CAP.Models;

namespace DotNetCore.CAP.Job.States
{
    public static class StateChangerExtensions
    {
        public static async Task ChangeStateAsync(
            this IStateChanger @this, CapSentMessage message, IState state, IStorageConnection connection)
        {
            using (var transaction = connection.CreateTransaction())
            {
                @this.ChangeState(message, state, transaction);
                await transaction.CommitAsync();
            }
        }

        public static async Task ChangeStateAsync(
            this IStateChanger @this, CapReceivedMessage message, IState state, IStorageConnection connection)
        {
            using (var transaction = connection.CreateTransaction())
            {
                @this.ChangeState(message, state, transaction);
                await transaction.CommitAsync();
            }
        }
    }
}