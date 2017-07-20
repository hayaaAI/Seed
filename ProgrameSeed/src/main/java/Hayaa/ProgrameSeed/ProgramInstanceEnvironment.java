package Hayaa.ProgrameSeed;

import java.net.InetAddress;

import Hayaa.ProgrameSeed.Model.InstanceEnvironmentInfo;

public class ProgramInstanceEnvironment {
   InstanceEnvironmentInfo ScanEnvironment()
    {
	   InstanceEnvironmentInfo r= new InstanceEnvironmentInfo();
        r.SystemIPs = GetSystemIP();
        r. AppPool = GetAppPool();
        r.ServicePort = GetServicePort();
        return r;
    }
     private int GetServicePort()
     {
         int port = -1;    
         try {
        	
        	 
         }
         catch(Exception e) {
        	 
         }
         return port;
     }

     private String GetAppPool()
     {
    	 String appPool = "";        
         return appPool;
     }

     private  String GetSystemIP()
     {
    	 try {
             InetAddress addr = InetAddress.getLocalHost();
             return addr.getHostAddress().toString();                 
         } catch (Exception e) {
             e.printStackTrace();
         }	
    	 return "localhost";
     }
}
