using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public class ResMgr : IResMgr
    {
        public GameObject LoadGameObject(string path)
        {
            return GameObject.Instantiate(Resources.Load<GameObject>(path));
        }
    }
}

