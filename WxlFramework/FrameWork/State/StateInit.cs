using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public class StateInit : SingleNew<StateInit>, IStateBase
    {
        public void StateEnter()
        {
            GameMgr.LogMgr.Log("StateInit StateEnter ...");
            GameMgr.StateMgr.ChangeState(StateMain.Instance);
        }

        public void StateOut()
        {

        }

        public void StateUpdate()
        {

        }
    }
}
