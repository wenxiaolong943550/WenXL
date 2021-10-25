using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//明确有哪些接口，规范代码，模块易拓展，工程整洁易维护，接口清晰
namespace FrameWork
{
    //启动器
    public class Launch : MonoBehaviour
    {
        void Start()
        {
            GameMgr.Init();
            //日志模块状态
            GameMgr.LogMgr.OnGuiLogShow(true);
            GameMgr.LogMgr.LogShow(true, false);
            GameMgr.StateMgr.ChangeState(new StateInit());

        }

        void Update()
        {
            if (GameMgr.StateMgr.CurState() != null)
            {
                GameMgr.StateMgr.CurState().StateUpdate();
            }
        }
    }
}

