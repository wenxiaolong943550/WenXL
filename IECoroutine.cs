
using System.Collections;
using UnityEngine;
using System;

public static class IECoroutine
{
    private static IEnumeratorMonoBehaviour _IEnumeratorMonoBehaviour = null;

    public static Coroutine Run(IEnumerator ie)
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

    public static void Run(float time, Action callBack)
    {
        Run(WaitingToDo(time, callBack));
    }

    public static void Stop(Coroutine con)
    {
        if (con != null && _IEnumeratorMonoBehaviour != null)
        {
            _IEnumeratorMonoBehaviour.StopCoroutine(con);
        }
    }

    static IEnumerator WaitingToDo(float time, Action callBack)
    {
        yield return new WaitForSeconds(time);
        callBack?.Invoke();
    }
}

public class IEnumeratorMonoBehaviour : MonoBehaviour
{

}
