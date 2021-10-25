using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

/// <summary>
/// 参考另一个中介中的注释，这个不注释了
/// </summary>
public class ShowInfoMeidator : Mediator
{
    public new const string NAME = "show_info_mediator";//中介的名字
    private ShowInfoView showInfoView;

    public ShowInfoMeidator() : base(NAME)
    {

    }
    public override string MediatorName
    {
        get
        {
            return base.MediatorName;
        }
    }
    /// <summary>
    /// 这个中介对应的UI，这个UI对那些通知感兴趣
    /// /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests()
    {
        List<string> notis = new List<string>();
        notis.Add(NotificationString.HPCHANGE);
        notis.Add(NotificationString.CLOSESHOWINFO);
        notis.Add(NotificationString.OPENSHOWINFO);
        return notis;
    }

    /// <summary>
    /// 收到通知后，UI变化显示信息
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case NotificationString.OPENSHOWINFO:
                showInfoView.OpenView();
                break;
            case NotificationString.CLOSESHOWINFO:
                showInfoView.CloseView();
                break;
            case NotificationString.HPCHANGE:
                showInfoView.ShowHP((int)(notification.Body));
                break;
        }

    }
    /// <summary>
    /// 当注册的时候调用它
    /// </summary>
    public override void OnRegister()
    {
        base.OnRegister();
        showInfoView = GameObject.Instantiate(Resources.Load<ShowInfoView>("ShowInfo"));
    }
    /// <summary>
    /// 当移除掉的时候调用它
    /// </summary>
    public override void OnRemove()
    {
        base.OnRemove();
        GameObject.Destroy(showInfoView);
    }
    /// <summary>
    /// 发送通知
    /// </summary>
    /// <param name="notificationName"></param>
    public override void SendNotification(string notificationName)
    {
        base.SendNotification(notificationName);
    }
    /// <summary>
    /// 发送通知
    /// </summary>
    /// <param name="notificationName"></param>
    /// <param name="body"></param>
    public override void SendNotification(string notificationName, object body)
    {
        base.SendNotification(notificationName, body);
    }
}
