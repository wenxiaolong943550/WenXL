using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.UI;

//显示层
public class DataMediator : Mediator
{
    //声明本类名称，覆盖名称
    public new const string NAME = "DataMediator";
    //定义两个显示的控件
    private Text TextLevel;
    private Button BtnDisplayLevelNum;

    //确定根节点
    public DataMediator(GameObject goRootNode)
    {
        //确定控件
        TextLevel = goRootNode.transform.Find("Text").GetComponent<Text>();
        BtnDisplayLevelNum = goRootNode.transform.Find("Button").GetComponent<Button>();
        //注册按钮
        BtnDisplayLevelNum.onClick.AddListener(OnClickAddingLevelNumber);
    }

    //用户点击
    void OnClickAddingLevelNumber()
    {
        //定义消息 发送控制层。。执行Execute
        SendNotification("Reg_StartDataCommand");
    }

    //本视图层 允许接收的消息
    public override IList<string> ListNotificationInterests()
    {
        IList<string> listResult = new List<string>();
        //可以接收的消息集合
        listResult.Add("Msg_AddLevel");
        return listResult;
    }

    //处理所有其他类发给本类的允许处理的消息
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case "Msg_AddLevel":
                //把模型层发来的数据，显示给控件
                MyData myData = notification.Body as MyData;
                TextLevel.text = myData.Level.ToString();
                break;
            default:
                break;
        }
    }
}
