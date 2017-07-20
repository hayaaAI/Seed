package Hayaa.ProgrameSeed.Util;

public class StringHelper {
	public static Boolean IsNullOrEmpty(String target) {
		if(target==null) return true;
		if(target.isEmpty()) return true;
		return false;
	}
}
