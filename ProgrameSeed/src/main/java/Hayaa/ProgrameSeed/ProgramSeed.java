package Hayaa.ProgrameSeed;

import java.util.HashMap;
import java.util.Map;

import Hayaa.ProgrameSeed.Config.SeedDefineTable;
import Hayaa.ProgrameSeed.Model.InstanceEnvironmentInfo;
import Hayaa.ProgrameSeed.Model.Config.SeedConfig;
import Hayaa.ProgrameSeed.Util.HttpRequestHelper;
import Hayaa.ProgrameSeed.Util.JsonConvert;
import Hayaa.ProgrameSeed.Util.SecurityProvider;

public class ProgramSeed {
	private static ProgramSeed g_instance = new ProgramSeed();
    private ProgramInstanceEnvironment _ProgramInstanceEnvironment = new ProgramInstanceEnvironment();
    private InstanceEnvironmentInfo _Environment;
    private ProgramSeed()
    {
        
    }
    public static ProgramSeed Instance()
    {        
            return g_instance;
    }
   
    public String InitProgram()
    {
        String result = "";
        try
        {

          
            _Environment = _ProgramInstanceEnvironment.ScanEnvironment();          
            ProgramDistributedConfig.Instance().RunInAppStartInit();
            SeedConfig seedConfig = ProgramDistributedConfig.Instance().GetSeedConfig();
            SendbaseInfo(_Environment, seedConfig.SeedServerUrl);
             SendSeedConfigInfo(seedConfig, seedConfig.SeedServerUrl);
            
        }
        catch (Exception ex)
        {
            return ex.getMessage();
        }
        return result;
    }
 
    public String ResetConfig()
    {
        return InitProgram();
    }
   
    private void SendSeedConfigInfo(SeedConfig appConfig, String seedServerUrl)
    {
        Map<String, String> paramters = new HashMap<String, String>();
        String info = JsonConvert.SerializeObject(appConfig);
        paramters.put(SeedDefineTable.UrlAction, SeedDefineTable.UrlAction_SendSeedConfig);
        paramters.put(SeedDefineTable.AppConfig, info);
        paramters.put(SeedDefineTable.SentinelSign, SecurityProvider.GetMd5Sign(info));
        String r = HttpRequestHelper.Instance().GetNormalRequestResult(seedServerUrl, paramters,"post");
        
    }
   
    private void SendbaseInfo(InstanceEnvironmentInfo environment, String seedServerUrl)
    {
    	 Map<String, String> paramters = new HashMap<String, String>();
        String info = JsonConvert.SerializeObject(environment);
        paramters.put(SeedDefineTable.UrlAction, SeedDefineTable.UrlAction_SendEvn);
        paramters.put(SeedDefineTable.Eveinfo, info);
        paramters.put(SeedDefineTable.SentinelSign, SecurityProvider.GetMd5Sign(info));
        String r = HttpRequestHelper.Instance().GetNormalRequestResult(seedServerUrl, paramters,"post");
      
    }
}
