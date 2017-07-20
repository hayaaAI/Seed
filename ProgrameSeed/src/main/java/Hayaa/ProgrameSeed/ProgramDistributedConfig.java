package Hayaa.ProgrameSeed;


import java.io.IOException;
import java.net.URLDecoder;
import java.util.HashMap;

import java.util.Map;
import java.util.Properties;
import java.util.UUID;

import org.codehaus.jackson.JsonGenerationException;
import org.codehaus.jackson.map.JsonMappingException;
import org.codehaus.jackson.map.ObjectMapper;

import Hayaa.ProgrameSeed.Config.SeedDefineTable;
import Hayaa.ProgrameSeed.Model.Config.AppConfig;
import Hayaa.ProgrameSeed.Model.Config.ComponentConfig;
import Hayaa.ProgrameSeed.Model.Config.ComponentService;
import Hayaa.ProgrameSeed.Model.Config.SeedConfig;
import Hayaa.ProgrameSeed.Util.FileHelper;
import Hayaa.ProgrameSeed.Util.HttpRequestHelper;
import Hayaa.ProgrameSeed.Util.JsonConvert;
import Hayaa.ProgrameSeed.Util.StringHelper;

public class ProgramDistributedConfig
{
	private AppConfig _appConfig;
	private SeedConfig _seedConfig;	
	private static ProgramDistributedConfig _instance = new ProgramDistributedConfig();

	public static ProgramDistributedConfig Instance()
	{

		return _instance;

	}

	private ProgramDistributedConfig()
	{
		_appConfig = new AppConfig();
		_appConfig.Components = null;
		_appConfig.ConfigContent = "";
		_appConfig.SolutionID = null;
		_appConfig.SolutionName = "解决方案";
		_appConfig.Version = 0;
		try
		{
			_seedConfig = ReadSeedConfig();
		} catch (Exception ex)
		{
			_seedConfig = new SeedConfig();
			_seedConfig.Version = 0;
			_seedConfig.AppConfigID = null;
			_seedConfig.IsRemote = false;
		}
	}

	private void ReadLocal(SeedConfig seedConfig, InitResult result)
	{
		if ((seedConfig.LocalConfigDirectoryPath != null) && (!seedConfig.LocalConfigDirectoryPath.isEmpty()))
		{
			result.Result = false;
			result.Message = "本地配置文件路径为空";
			return;
		}
		try
		{
			AppConfig temp = JsonConvert.DeserializeObject(
					FileHelper.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName),
					AppConfig.class);
			if (temp == null)
			{
				_appConfig = temp;
			}
		} catch (Exception ex)
		{
			result.Result = false;
			result.Message = ex.getMessage();
			return;
		}
	}

	private AppConfig ReadLocal(SeedConfig seedConfig)
	{
		if (StringHelper.IsNullOrEmpty(seedConfig.LocalConfigDirectoryPath))
		{
			return null;
		}
		try
		{
			AppConfig temp =JsonConvert.DeserializeObject(
					FileHelper.ReadAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName),
					AppConfig.class);
			return temp;
		} catch (Exception ex)
		{

		}
		return null;
	}

	private void ReadRemote(SeedConfig seedConfig) throws JsonGenerationException, JsonMappingException, IOException
	{

		AppConfig localconfig = null;

		if (FileHelper.Exists(seedConfig.LocalConfigDirectoryPath + "/app.Config"))
		{
			localconfig = ReadLocal(seedConfig);
		}
		AppConfig remoteConfig = GetRemote(seedConfig.SeedServerUrl, seedConfig.AppConfigID);

		if (remoteConfig != null)
		{
			if (seedConfig.Version == 0)
			{
				FileHelper.Delete(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName);

				FileHelper.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName,
						JsonConvert.SerializeObject(remoteConfig));
			}
			if ((seedConfig.Version > 0) && (localconfig == null))
			{
				FileHelper.AppendAllText(seedConfig.LocalConfigDirectoryPath + "/" + seedConfig.AppConfigFileName,
						JsonConvert.SerializeObject(remoteConfig));
			}
		}

	}

	@SuppressWarnings("unchecked")
	private AppConfig GetRemote(String url, UUID solutionID)
	{
		@SuppressWarnings("rawtypes")
		Map<String, String> dic = new HashMap<String, String>();
		dic.put(SeedDefineTable.UrlAction, SeedDefineTable.GetRmoteConfigAction);
		dic.put(SeedDefineTable.SolutionIDParam, solutionID.toString());
		String str = "";
		AppConfig result = null;
		try
		{
			str = HttpRequestHelper.Instance().GetNormalRequestResult(url, dic, "get");
			str = URLDecoder.decode(str, "UTF-8");
			result = JsonConvert.DeserializeObject(str, AppConfig.class);
		} catch (Exception ex)
		{
			result = null;
			return result;
		}
		return result;
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	private SeedConfig ReadSeedConfig()
    {
        SeedConfig r = new SeedConfig();
       
             r.IsRemote = true;
             r.IsVirtualPath = true;
            		 r.LocalConfigDirectoryPath = "/Config";
            				 r.Version = 0;
            				 Properties props = System.getProperties();
        try
        {
        	
            String baseDirectory = props.getProperty("java.class.path");
            r=JsonConvert.DeserializeObject(FileHelper.ReadAllText(baseDirectory + "/seed.config"),SeedConfig.class);
        }
        catch (Exception ex)
        {
            r = new SeedConfig(); r.IsVirtualPath = false;
        }
        if (r.IsVirtualPath)
        {
            r.LocalConfigDirectoryPath= props.getProperty("java.class.path")+r.LocalConfigDirectoryPath;
        }
        return r;
    }

	public AppConfig GetLocalConfig()
	{
		return ReadLocal(_seedConfig);
	}

	public Boolean IsEmpty()
	{
		if (_appConfig.SolutionID==null)
		{
			return true;
		}
		return false;
	}

	public Boolean IsFactory()
	{
		return _appConfig.IsFactory();
	}
	
	public InitResult RunInAppStartInit() throws JsonGenerationException, JsonMappingException, IOException
	{
		InitResult r = new InitResult();
		r.Result = true;
		if (_seedConfig.IsRemote)
		{
			ReadRemote(_seedConfig);
		}
		ReadLocal(_seedConfig, r);
		return r;
	}

	public ComponentConfig GetComponentConfig(int componetID)
    {       
		for(int i=0;i<_appConfig.Components.length;i++) {
			if(_appConfig.Components[i].ComponentID == componetID)
			return _appConfig.Components[i];
		}
		return null;
    }

	public ComponentService[] GetComponentServices()
	{
		return _appConfig.CompeontInstances;
	}

	public SeedConfig GetSeedConfig()
	{
		return _seedConfig;
	}
}
