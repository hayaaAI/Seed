package Hayaa.ProgrameSeed.Model.Config;

import java.util.UUID;

public class AppConfig {
	 public Boolean IsFactory()
     {
		 return !((this.CompeontInstances == null) || (this.CompeontInstances.length == 0));
     }
     /// <summary>
     /// ����ID
     /// </summary>	
     public int AppID;
     /// <summary>
     /// �������ID
     /// </summary>	
     public UUID SolutionID;
     /// <summary>
     /// �����������
     /// </summary>	
      public String SolutionName;
     /// <summary>
     /// ��������
     /// </summary>	
     public String ConfigContent;
     
     /// <summary>
     /// �������÷����汾 
     /// </summary>
     public int Version;
     /// <summary>
     /// �������
     /// </summary>
     public ComponentConfig[] Components;
     /// <summary>
     /// �������ʵ��
     /// </summary>
    
     public ComponentService[] CompeontInstances;
}
