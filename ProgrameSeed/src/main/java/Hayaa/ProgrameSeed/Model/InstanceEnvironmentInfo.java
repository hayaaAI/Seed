package Hayaa.ProgrameSeed.Model;

import java.util.Properties;

public class InstanceEnvironmentInfo {
	public InstanceEnvironmentInfo() {
		Properties props = System.getProperties();
		this.SystemInfo=props.getProperty("os.name")+" "+props.getProperty("os.version");		
		this.HostBaseDirectory=props.getProperty("java.class.path");
		this.IsWeb=true;
		InitNetInfo();
	}
	private void InitNetInfo() {
			
	}
	
    public String SystemInfo;
  
    public String MachineName;
   
    public int CpuCount;
   
    public String SystemIPs;
    
    public String AppPool;
   
    public String HostBaseDirectory;
   
    public Boolean IsWeb;
   
    public int ServicePort;
}
