using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

//数据控制层 就收玩家输入 或者视图层发来的输入消息
public class DataCommand : SimpleCommand
{
    //执行方法
    public override void Execute(INotification notification)
    {
        //调用数据层“增加等级的方法”
        //DataProxy datapro = (DataProxy)Facade.RetrieveProxy(DataProxy.NAME);
        DataProxy datapro = Facade.RetrieveProxy(DataProxy.NAME) as DataProxy;
        datapro.AddLevel(10);
    }
}