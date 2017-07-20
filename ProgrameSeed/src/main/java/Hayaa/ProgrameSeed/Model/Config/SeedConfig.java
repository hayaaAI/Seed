package Hayaa.ProgrameSeed.Model.Config;

import java.util.UUID;

public class SeedConfig
{
    /// <summary>
    /// ���ӷ����ַ
    /// </summary>
    public String SeedServerUrl;   
    /// <summary>
    /// ����ģʽ������Ŀ¼�洢·��
    /// </summary>
    public  String LocalConfigDirectoryPath;
    /// <summary>
    /// �洢·���Ƿ����·��Ŀ¼
    /// </summary>
    public Boolean IsVirtualPath;
    /// <summary>
    /// ����������ַ
    /// </summary>
    public String AppConfigSentinelUrl;
    /// <summary>
    /// �����ܳ�
    /// </summary>
    public String TransfersSecurityKey;
    /// <summary>
    /// ���ط������ID
    /// </summary>
    public int AppID;
    /// <summary>
    /// �������÷���ID
    /// </summary>
    public UUID AppConfigID;
    /// <summary>
    /// �������÷����汾
    /// 0��ʾ��ȡ����
    /// </summary>
    public int Version;
    /// <summary>
    /// ����ģʽ�Ƿ�Զ�̻�
    /// </summary>
    public  Boolean IsRemote;
    /// <summary>
    /// ���������ļ���
    /// </summary>
    public String AppConfigFileName;
}
