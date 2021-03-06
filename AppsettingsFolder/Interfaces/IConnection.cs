﻿using AppsettingsFolder.Classes;

namespace AppsettingsFolder.Interfaces
{
    public interface IConnection
    {
        /// <summary>
        /// Development environment connection string
        /// </summary>
        public string DevelopmentConnection { get; set; }
        /// <summary>
        /// Production environment connection string
        /// </summary>        
        public string ProductionConnection { get; set; }
        /// <summary>
        /// Test environment connection string
        /// </summary>
        public string TestConnection { get; set; }
        /// <summary>
        /// Current environment
        /// </summary>
        public Environments Environment { get; set; }

    }
}
