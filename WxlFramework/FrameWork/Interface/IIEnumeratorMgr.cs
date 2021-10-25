
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public interface IIEnumeratorMgr
    {
        Coroutine Run(IEnumerator ie);
        void Run(float time, Action callBack);
        void Stop(Coroutine con);
    }
}

