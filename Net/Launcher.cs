using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Dragon;
using UnityEngine.Networking;

public class Launcher : ApplicationBase<Launcher>
{
    private string appPath = "Base";
    private string basePath;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        basePath = Application.persistentDataPath;
        IECoroutine.Run(LoadResourceCorotine(XLuaManager.Instance.StartLua));
        //RegisterController(Consts.E_StartUp, typeof(StartUpCommand));
        //SendEvent(Consts.E_StartUp);
    }

    IEnumerator LoadResourceCorotine(Action callBack)
    {
        WDebug.Log("本地地址：" + basePath);
        //查看本地是否有版本文案，如果没有则拷贝
        string configPath = basePath + "/Config.txt";
        if (!File.Exists(configPath))
        {
            string config = Resources.Load<TextAsset>("Config").text;
            WDebug.Log(config);
            File.WriteAllText(configPath, config);
        }
        int verson = Int32.Parse(System.IO.File.ReadAllText(configPath).Split('_')[1]);
        WDebug.Log("本地Lua版本：" + verson);

        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/" + appPath + "/Config.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        WDebug.Log("获取网络版本信息："+ str);
        if (string.IsNullOrEmpty(str))
        {
            //网络连接失败看本地是否有数据
            if (File.Exists(basePath + "/Lua/LuaLauncher.lua"))
            {
                callBack?.Invoke();
            }
            else
            {
                TipMgr.Instance.Show(EnumTipType.TipSureCanel,"第一次打开需要连接网络验证版本号!");
                yield break;
            }
        }
        int UrlVerson = Int32.Parse(str.Split('_')[1]);
        WDebug.Log("网端Lua版本：" + UrlVerson);

        if (UrlVerson > verson)
        {
            WDebug.Log("需要更新代码");
            yield return IECoroutine.Run(DownLua("LuaLauncher"));
            yield return IECoroutine.Run(DownLua("LuaTools"));
            WDebug.Log("更新成功");
            callBack?.Invoke();
        }
        else
        {
            callBack?.Invoke();
        }
    }

    IEnumerator DownLua(string luaName)
    {
        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/" + appPath + "/" + luaName + ".lua");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        string LuaPath = basePath + "/Lua/";
        if (!Directory.Exists(LuaPath))
            Directory.CreateDirectory(LuaPath);
        File.WriteAllText(basePath + "/Lua/" + luaName + ".lua", str);
    }
}
