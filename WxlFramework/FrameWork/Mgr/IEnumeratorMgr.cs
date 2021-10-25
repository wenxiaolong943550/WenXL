
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FrameWork
{
    public class IEnumeratorMgr : IIEnumeratorMgr
    {
        private IEnumeratorMonoBehaviour _IEnumeratorMonoBehaviour = null;

        public Coroutine Run(IEnumerator ie)
        {
            if (_IEnumeratorMonoBehaviour == null)
            {
                GameObject obj = new GameObject("_IEnumeratorMonoBehaviour");
                if (Application.isPlaying)
                    GameObject.DontDestroyOnLoad(obj);
                _IEnumeratorMonoBehaviour = obj.AddComponent<IEnumeratorMonoBehaviour>();
            }
            return _IEnumeratorMonoBehaviour.StartCoroutine(ie);
        }

        public void Run(float time, Action callBack)
        {
            Run(WaitingToDo(time, callBack));
        }

        public void Stop(Coroutine con)
        {
            if (con != null && _IEnumeratorMonoBehaviour != null)
            {
                _IEnumeratorMonoBehaviour.StopCoroutine(con);
            }
        }

        IEnumerator WaitingToDo(float time, Action callBack)
        {
            yield return new WaitForSeconds(time);
            callBack?.Invoke();
        }
    }

    public class IEnumeratorMonoBehaviour : MonoBehaviour
    {

    }
}

