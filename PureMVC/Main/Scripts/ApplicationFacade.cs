using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine;

//全局控制类 把MVC关联起来
public class ApplicationFacade : Facade
{
    public ApplicationFacade(GameObject goRootNode)
    {
        //MVC 三层关联绑定
        //控制注册 消息与控制层绑定
        RegisterCommand("Reg_StartDataCommand", typeof(DataCommand));
        //视图注册到框架
        RegisterMediator(new DataMediator(goRootNode));
        //模型注册到框架
        RegisterProxy(new DataProxy());
    }
}
