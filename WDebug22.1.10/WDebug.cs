using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class WDebug
{
    private static bool enableLog = true;                     //进入Log
    private static bool enableSave = false;                   //进入保存
    private static string logPath = "";                       //LOG保存地址
    private static StringBuilder theLog = new StringBuilder();
    private static bool isInit = false;                       //是否初始化

    //日志初初始化接口 是否显示 是否保存 地址
    public static void Init(bool enable, bool save)
    {
        if (!isInit)
        {
            isInit = true;
            string path = Application.persistentDataPath + "/WDebug";
            CreateDirectory(path);
            logPath = path + "/WDebug_"+ DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff")+".txt";
            enableLog = enable;
            enableSave = save;
            new FileStream(logPath, FileMode.Create, FileAccess.Write).Close();
            Log("WDebug初始化成功...");
            Log(logPath);
        }
        else
        {
            //一次启动，不能初始化两次
            Log("WDebug已经初始化,无需再次初始化");
        }
    }
    public static void CreateDirectory(string destFileName)
    {
        if (!Directory.Exists(destFileName))
            Directory.CreateDirectory(destFileName);
    }

    //日志输出接口
    public static void Log(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Log", data);
            saveLog(tempData);
            Debug.Log(tempData, null);
        }
    }

    //警告输出接口
    public static void LogWarning(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Warning", data);
            saveLog(tempData);
            Debug.LogWarning(tempData, null);
        }
    }

    //错误输出接口
    public static void LogError(params object[] data)
    {
        if (enableLog)
        {
            string tempData = GetLog("Error", data);
            saveLog(tempData);
            Debug.LogError(tempData, null);
        }
    }

    //得到Log信息并整理
    private static string GetLog(string type, params object[] data)
    {
        theLog.Length = 0;
        for (int i = 0; i < data.Length; i++) theLog.Append(data[i]);
        theLog.Append("\n");
        theLog.Append(DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss:fff] "));
        theLog.Append(type);
        theLog.Append("\r");
        return get_uft8(theLog.ToString());
    }

    private static void saveLog(string strLog)
    {
        if (enableSave)
        {
            //写入本地的时候，偶现异常
            FileStream stream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            try
            {
                writer.Write(strLog + "\r\n");
            }
            catch (Exception e)
            {
                Debug.Log("日志无法写入本地：" + strLog);
                throw;
            }
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
