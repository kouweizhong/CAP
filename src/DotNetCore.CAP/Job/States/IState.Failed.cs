﻿using System;
using DotNetCore.CAP.Models;

namespace DotNetCore.CAP.Job.States
{
    public class FailedState : IState
    {
        public const string StateName = "Failed";

        public TimeSpan? ExpiresAfter => TimeSpan.FromDays(15);

        public string Name => StateName;

        public void Apply(CapSentMessage message, IStorageTransaction transaction)
        {
        }

        public void Apply(CapReceivedMessage message, IStorageTransaction transaction)
        {
        }
    }
}