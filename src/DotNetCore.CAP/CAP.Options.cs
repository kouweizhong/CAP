﻿namespace DotNetCore.CAP
{
    /// <summary>
    /// Represents all the options you can use to configure the system.
    /// </summary>
    public class CapOptions
    {
        /// <summary>
        /// Default value for polling delay timeout, in seconds.
        /// </summary>
        public const int DefaultPollingDelay = 8;

        /// <summary>
        /// Default value for CAP job.
        /// </summary>
        public const string DefaultCronExp = "* * * * *";

        public CapOptions()
        {
            CronExp = DefaultCronExp;
            PollingDelay = DefaultPollingDelay;
        }

        /// <summary>
        /// Corn expression for configuring retry cron job. Default is 1 min.
        /// </summary>
        public string CronExp { get; set; }

        /// <summary>
        /// Productor job polling delay time. Default is 8 sec.
        /// </summary>
        public int PollingDelay { get; set; } = 8;
    }
}