
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public class StateMain : SingleNew<StateMain>, IStateBase
    {
        public void StateEnter()
        {
            GameMgr.LogMgr.Log("StateMain StateEnter ...");
            //GameMgr.StateMgr.ChangeState(new StateGameLaunch());
        }

        public void StateOut()
        {

        }

        public void StateUpdate()
        {

        }
    }
}
