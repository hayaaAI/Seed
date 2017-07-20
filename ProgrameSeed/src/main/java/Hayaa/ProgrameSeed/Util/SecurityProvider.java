package Hayaa.ProgrameSeed.Util;



import Hayaa.ProgrameSeed.ProgramDistributedConfig;

public class SecurityProvider
{
	 private static String GetMd5(String source)
     {
         
         return source;
     }
     private static Boolean VerifyMd5(String source, String hash)
     {
         return true;
     }
     public static String GetPassword()
     {
         String key = "";
         try
         {
             key = ProgramDistributedConfig.Instance().GetSeedConfig().TransfersSecurityKey;
         }
         catch(Exception ex)
         {

         }
         return GetMd5(key);
     }
     public static Boolean VerifyPassword(String password)
     {
    	 String key = "";
         try
         {
             key = ProgramDistributedConfig.Instance().GetSeedConfig().TransfersSecurityKey;
         }
         catch(Exception ex)
         {

         }
         return VerifyMd5(key, password);
     }
     public static String GetMd5Sign(String info)
     {
         return GetMd5(info);
     }
     public static Boolean VerifyMd5Sign(String infoSign)
     {
    	 String key = "";
         try
         {
             key = ProgramDistributedConfig.Instance().GetSeedConfig().TransfersSecurityKey;
         }
         catch(Exception ex)
         {

         }
         return VerifyMd5(key, infoSign);
     }
}
