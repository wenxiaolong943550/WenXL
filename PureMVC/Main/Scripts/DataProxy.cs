using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine;

//数据封装 数据代理类
public class DataProxy : Proxy
{
    //声明本类名称，覆盖名称
    public new const string NAME = "DataProxy";
    //对应的引用实体类
    private MyData _MyData = null;

    //构造方法
    public DataProxy() : base(NAME)
    {
        _MyData = new MyData();
    }

    //增加等级
    public void AddLevel(int addNumber)
    {
        _MyData.Level += addNumber;
        //把变化了的数据 发送给视图
        SendNotification("Msg_AddLevel", _MyData);
    }
}
