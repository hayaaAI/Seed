package Hayaa.ProgrameSeed.Util;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;

public class FileHelper
{
	public static String ReadAllText(String filePath)
	{
		File file = new File(filePath);
		StringBuilder result = new StringBuilder();
		try
		{
			BufferedReader br = new BufferedReader(new FileReader(file));// 构造一个BufferedReader类来读取文件
			String s = null;
			while ((s = br.readLine()) != null)
			{// 使用readLine方法，一次读一行
				result.append(System.lineSeparator() + s);
			}
			br.close();
		} catch (Exception e)
		{
			e.printStackTrace();
		}
		return result.toString();
	}
	public static void AppendAllText(String filePath,String fileContent)
	{
		File file = new File(filePath);
		try
		{
			BufferedWriter br = new BufferedWriter(new FileWriter(file));// 构造一个BufferedReader类来读取文件
			br.write(fileContent);
			br.close();
		} catch (Exception e)
		{
			e.printStackTrace();
		}
		
	}
	public static Boolean Exists(String filePath) {
		File file=new File(filePath);
		return file.exists();
	}
	public static Boolean Delete(String filePath) {
		File file=new File(filePath);
		return file.delete();
	}
}
