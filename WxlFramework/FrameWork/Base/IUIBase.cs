using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public abstract class IUIBase
    {
        private Transform _Transform;

        public virtual void Init(Transform _Transform)
        {
            this._Transform = _Transform;
        }

        public virtual void Show()
        {
            
        }

        public virtual void Hide()
        {

        }

        public virtual void Out()
        {

        }

        List<Transform> allObj = new List<Transform>();
        //UGUI底层拓展，可以直接找到对应的组件
        public T Make<T>(string _Name) where T : Component
        {
            if (_Transform == null)
            {
                GameMgr.LogMgr.LogError("_Transform 不存在 ...");
                return null;
            }
            allObj.Clear();
            GetObjUseName(_Transform, _Name);
            if (allObj.Count != 0)
            {
                GameMgr.LogMgr.Log("相同名字组件个数：" + allObj.Count);
                foreach (Transform trs in allObj)
                {
                    if (trs.GetComponent<T>() != null)
                    {
                        allObj.Clear();
                        return trs.GetComponent<T>();
                    }
                }
            }
            allObj.Clear();
            GameMgr.LogMgr.LogError("--" + _Transform.name + " 无法找到组件 " + _Name);
            return null;
        }

        //利用名字找到所有物体
        public void GetObjUseName(Transform _Transform, string _Name)
        {
            foreach (Transform trs in _Transform)
            {
                if (trs.name == _Name)
                {
                    allObj.Add(trs);
                }
                if (trs.childCount != 0)
                {
                    GetObjUseName(trs, _Name);
                }
            }
        }
    }
}

