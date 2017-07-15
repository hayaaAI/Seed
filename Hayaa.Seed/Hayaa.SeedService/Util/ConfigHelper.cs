using Hayaa.ProgrameSeed;
using Hayaa.SeedService.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.SeedService.Util
{
    class AppConfigHelper: ConfigHelper<ServiceConfig>
    {
        internal static ServiceConfig GetSeedServiceConfig()
        {
            return ConfigHelper<ServiceConfig>.GetConfig(1);
        }
        internal static string GetCon()
        {
            var config= ConfigHelper<ServiceConfig>.GetConfig(1);
            return config.DatabaseConnection;
        }
    }
}
