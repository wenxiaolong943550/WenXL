using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public class UIMgr : IUIMgr
    {
        private IUIBase curUI;
        public IUIBase CurUI()
        {
            return curUI;
        }

        public void ChangeUI(IUIBase ui)
        {
            if (curUI != null)
            {
                if (curUI == ui)
                {
                    GameMgr.LogMgr.LogError("当前已经是UI：" + curUI.ToString() + " 不用切换");
                    return;
                }
                curUI.Hide();
            }
            ui.Show();
            curUI = ui;
        }
    }
}
