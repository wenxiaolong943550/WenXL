using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public interface IStateBase
    {
        void StateEnter();
        void StateOut();
        void StateUpdate();
    }
}
