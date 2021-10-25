using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class HPMediator : Mediator
{
    public new const string NAME = "hp_mediator";//中介的名字
    private HPView hpView;

    /// <summary>
    /// 继承Mediator的构造函数。
    /// </summary>
    public HPMediator() : base(NAME)
    {

    }
    /// <summary>
    /// 获取这个中介的名字
    /// </summary>
    public override string MediatorName
    {
        get
        {
            return base.MediatorName;
        }
    }
    /// <summary>
    /// 这个中介或者说这个UI界面对那些消息感兴趣
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notis = new List<string>();
        notis.Add(NotificationString.HPVIEWCLOSE);
        notis.Add(NotificationString.HPVIEWOPEN);
        notis.Add(NotificationString.HPCHANGE);
        return notis;
    }
    /// <summary>
    /// 当收到这些消息的时候，UI界面应该做什么反应
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationString.HPVIEWCLOSE:
                hpView.CloseView();
                break;
            case NotificationString.HPVIEWOPEN:
                hpView.OpenView();
                break;
            case NotificationString.HPCHANGE:
                hpView.ShowHP((int)(notification.Body));
                break;
        }
    }
    /// <summary>
    /// 注册这个中介的时候回调这个方法。初始化出UI界面。
    /// </summary>
    public override void OnRegister()
    {
        base.OnRegister();
        hpView = GameObject.Instantiate(Resources.Load<HPView>("HP"));
    }
    /// <summary>
    /// 移除中介的时候回调这个方法。销毁掉这个UI界面
    /// </summary>
    public override void OnRemove()
    {
        base.OnRemove();
        GameObject.Destroy(hpView);
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="notificationName"></param>
    public override void SendNotification(string notificationName)
    {
        base.SendNotification(notificationName);
    }
    /// <summary>
    /// 发送带参数的消息
    /// </summary>
    /// <param name="notificationName"></param>
    /// <param name="body"></param>
    public override void SendNotification(string notificationName, object body)
    {
        base.SendNotification(notificationName, body);
    }
}
