package Hayaa.ProgrameSeed.Util;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.URL;
import java.net.URLConnection;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

public class HttpRequestHelper
{
	 private static HttpRequestHelper g_instance = new HttpRequestHelper();

     public static HttpRequestHelper Instance()
     {
        
             return g_instance;
         
     }
	public String GetNormalRequestResult(String requestUrl, Map<String, String> urlParam, String method) 
	{
		String contentType="application/x-www-form-urlencoded";
		StringBuilder parm=new StringBuilder();
		for(Entry<String, String> entry:urlParam.entrySet())
		  {
			parm.append(String.format("{0}={1}&", entry.getKey(),entry.getKey()));
		   }
		if(method=="post") return sendPost(requestUrl,parm.toString(),contentType);
		if(method=="get")return sendGet(requestUrl,parm.toString(),contentType);
		return "";
	}

	private  String sendGet(String url, String parm, String contentType)
	{
		String result = "";
		String sendurl = url + "?" + parm;
		BufferedReader in = null;
		try
		{
			// 生成url
			URL realurl = new URL(sendurl);
			// 建立链接对象
			URLConnection connection = realurl.openConnection();
			// 设置请求头
			connection.setRequestProperty("accept", "*/*");
			connection.setRequestProperty("connection", "Keep-Alive");
			connection.setRequestProperty("ContentType", contentType); 
			connection.connect();
			// 获取响应头
			Map<String, List<String>> httpResponseHeader = connection.getHeaderFields();
			// 打印响应头
			Iterator<Map.Entry<String, List<String>>> iterator = httpResponseHeader.entrySet().iterator();
			while (iterator.hasNext())
			{
				Map.Entry<String, List<String>> en = iterator.next();
				for (String value : en.getValue())
				{
					System.out.println(en.getKey() + ":" + value);
				}
			}
			// 获取返回流
			in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
			String line = "";
			while ((line = in.readLine()) != null)
			{
				line = new String(line.getBytes("UTF-8"), "UTF-8");
				result += line;
			}
		} catch (Exception e)
		{
			e.printStackTrace();
		} finally
		{
			// 关闭流 //关闭流
			try
			{
				if (in != null)
				{
					in.close();
				}
			} catch (Exception e)
			{
				e.printStackTrace();
				;
			}
		}
		return result;
	}

	private  String sendPost(String url, String parm, String contentType)
	{
		PrintWriter printWriter = null;
		// 声明输出流对象
		BufferedReader in = null;
		// 声明输入流
		String result = "";
		try
		{
			URL realurl = new URL(url);
			// 创建链接对象
			URLConnection connection = realurl.openConnection();
			// 设置响应头
			connection.setRequestProperty("accept", "*/*");
			connection.setRequestProperty("connection", "Keep-Alive");
			connection.setRequestProperty("ContentType", contentType); 
			// 发送POST请求必须设置如下两行
			connection.setDoOutput(true);
			connection.setDoInput(true);
			// 获得对应链接的输出流
			printWriter = new PrintWriter(connection.getOutputStream());
			printWriter.println(parm);
			// 缓冲
			printWriter.flush();
			// 得到响应头
			Map<String, List<String>> httpResponseHeader = connection.getHeaderFields();
			Iterator<Map.Entry<String, List<String>>> iterator = httpResponseHeader.entrySet().iterator();
			while (iterator.hasNext())
			{
				Map.Entry<String, List<String>> en = iterator.next();
				for (String value : en.getValue())
				{
					System.out.println(en.getKey() + ":" + value);
				}
			}
			// 得到响应流
			in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
			String line = "";
			while ((line = in.readLine()) != null)
			{
				line = new String(line.getBytes("UTF-8"), "UTF-8");
				result += line;
			}
		} catch (Exception e)
		{
			System.out.println("url生成失败");
			e.printStackTrace();
		}
		return result;
	}

}
