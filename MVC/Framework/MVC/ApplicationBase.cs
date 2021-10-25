using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//抽象类单利模式
public abstract class ApplicationBase<T> : Singleton<T> where T : MonoBehaviour
{
    //注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

    //发送消息
    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
}