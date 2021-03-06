﻿using System;
using DotNetCore.CAP.Models;

namespace DotNetCore.CAP.Job.States
{
    public class ProcessingState : IState
    {
        public const string StateName = "Processing";

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