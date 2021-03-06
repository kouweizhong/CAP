﻿using System;
using DotNetCore.CAP.Models;

namespace DotNetCore.CAP.Job.States
{
    public class ScheduledState : IState
    {
        public const string StateName = "Scheduled";

        public TimeSpan? ExpiresAfter => null;

        public string Name => StateName;

        public void Apply(CapSentMessage message, IStorageTransaction transaction)
        {
        }

        public void Apply(CapReceivedMessage message, IStorageTransaction transaction)
        {
        }
    }
}