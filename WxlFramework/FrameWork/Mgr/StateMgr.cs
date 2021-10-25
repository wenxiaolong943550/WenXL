using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public class StateMgr : IStateMgr
    {
        private IStateBase curState;
        public IStateBase CurState()
        {
            return curState;
        }

        public void ChangeState(IStateBase state)
        {
            if (curState != null)
            {
                if (curState == state)
                {
                    GameMgr.LogMgr.LogError("当前已经是状态：" + state.ToString() + " 不用切换");
                    return;
                }
                curState.StateOut();
            }
            state.StateEnter();
            curState = state;
        }
    }
}

