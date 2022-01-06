using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class WDebug
{
    private static bool enableLog = true;                     //进入Log
    private static bool enableSave = false;                   //进入保存
    private static List<string> listInfo = new List<string>();//LOG日志
    private static string logPath = "";                       //LOG保存地址
    private static StringBuilder theLog = new StringBuilder();
    private static bool isInit = false;                       //是否初始化

    //日志初初始化接口 是否显示 是否保存 地址
    public static void Init(bool enable, bool save)
    {
        if (!isInit)
        {
            isInit = true;
            logPath = Application.persistentDataPath + "/WDebug.txt";
            enableLog = enable;
            listInfo.Clear();
            enableSave = save;
            new FileStream(logPath, FileMode.Create, FileAccess.Write).Close();
            Log("WDebug初始化成功...");
            Log(logPath);
        }
        else
        {
            LogError("WDebug已经初始化,无需再次初始化");
        }
    }

    public static List<string> GetLogger()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < listInfo.Count; i++)
        {
            list.Add(listInfo[i]);
        }
        return list;
    }

    //日志输出接口
    public static void Log(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Log => ", data);
            saveLog(tempData);
            Debug.Log(tempData, null);
        }
    }

    //警告输出接口
    public static void LogWarning(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Warning => ", data);
            saveLog(tempData);
            Debug.LogWarning(tempData, null);
        }
    }

    //错误输出接口
    public static void LogError(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Error => ", data);
            saveLog(tempData);
            Debug.LogError(tempData, null);
        }
    }

    //得到Log信息并整理
    private static string GetLog(string type, params object[] data)
    {
        theLog.Length = 0;
        theLog.Append(type);
        for (int i = 0; i < data.Length; i++) theLog.Append(" " + data[i]);
        theLog.Append("\n");
        //theLog.Append("Time => ");
        theLog.Append(DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss:fff] "));
        theLog.Append("\r");
        return theLog.ToString();
    }

    private static void saveLog(string strLog)
    {
        if (listInfo.Count > 0x3e8)
        {
            listInfo.RemoveRange(0, 500);
        }
        listInfo.Add(strLog);
        if (enableSave)
        {
            FileStream stream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(strLog + "\r\n");
            writer.Flush();
            writer.Close();
            stream.Close();
        }
    }

    public static string get_uft8(string unicodeString)
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        Byte[] encodedBytes = utf8.GetBytes(unicodeString);
        String decodedString = utf8.GetString(encodedBytes);
        return decodedString;
    }
}
