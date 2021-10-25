using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public interface IStateMgr
    {
        IStateBase CurState();
        void ChangeState(IStateBase state);
    }
}