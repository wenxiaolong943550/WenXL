using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public interface IUIMgr
    {
        IUIBase CurUI();
        void ChangeUI(IUIBase ui);
    }
}
