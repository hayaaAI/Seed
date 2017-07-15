using System;
using System.Collections.Generic;
using System.Text;

namespace Hayaa.ProgrameSeed
{
   public class ConfigHelper<T> where T : class
    {
        public static T GetConfig(int componentID) 
        {
            var config=ProgramDistributedConfig.Instance.GetComponentConfig(componentID);
            if (config != null)
            {
                if (string.IsNullOrEmpty(config.Content))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(config.Content);
                }
            }
            return default(T);
        }
    }
}
