package Hayaa.ProgrameSeed.Model.Config;



public class ComponentService
{
    /// <summary>
    /// ID
    /// </summary>	
    public int ComponentInstanceID;
    /// <summary>
    /// �����û�ID
    /// </summary>	
    public int AppUserID;
    /// <summary>
    /// ���ID
    /// </summary>		
    public int ComponetID;
    /// <summary>
    /// ����ӿ�ʵ������ȫ�޶���
    /// ��ʽ��"����, ������,"
    /// </summary>	
    public String ComponentServiceCompeleteName;
    /// <summary>
    /// ����ӿ�ʵ������
    ///  ��ʽ��"����"
    /// </summary>	
    public String ComponentServiceName;
    /// <summary>
    /// ������
    /// </summary>	
    public String ComponentAssemblyName;
    /// <summary>
    /// jar�ļ�����
    /// </summary>	
    public String ComponentAssemblyFileName;
    /// <summary>
    /// jar�ļ��洢·��
    /// </summary>	
    public String ComponentAssemblyFileStorePath;
    /// <summary>
    /// �ӿ�����
    /// </summary>
    public String[] GetComponentInterface()
    {
        
            if ((this.ComponentInterfaces!=null)&&(!this.ComponentInterfaces.isEmpty()))
            {
                return this.ComponentInterfaces.split(",");
            }
            return null;
       
    }
    public String ComponentInterfaces;
    /// <summary>
    /// ���򼯰汾
    /// </summary>		

    public String AssemblyVersion;
    /// <summary>
    /// �齨����1��jar2�Ƿ���
    /// </summary>
    public int ComponentType;
    /// <summary>
    /// �����ַ
    /// </summary>
    public String ServiceUrl;
}
