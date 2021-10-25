using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

/// <summary>
/// 管理场景，同时注册场景里的要用到的所有UI。离开场景时记得移除中介，也就是卸载UI界面。
/// </summary>
public class TestSceneManager : MonoBehaviour
{
    private void Awake()
    {
        RegisterAllMediator();
    }

    private void Start()
    {
        //发送消息，打开showinfoUI界面
        Facade.Instance.SendNotification(NotificationString.OPENSHOWINFO);
    }

    /// <summary>
    /// 注册场景里的UI
    /// </summary>
    public void RegisterAllMediator()
    {
        Facade.Instance.RegisterMediator(new ShowInfoMeidator());
        Facade.Instance.RegisterMediator(new HPMediator());
    }

    /// <summary>
    /// 移除场景里的UI
    /// </summary>
    public void RemoveAllMediator()
    {
        Facade.Instance.RemoveMediator(MediatorEnum.hp_mediator.ToString());
        Facade.Instance.RemoveMediator(MediatorEnum.show_info_mediator.ToString());
    }
}
