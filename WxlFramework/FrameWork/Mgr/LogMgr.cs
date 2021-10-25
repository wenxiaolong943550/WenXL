using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dragon;

namespace FrameWork
{
    public class LogMgr : ILogMgr
    {
        private bool isInit = false;
        public void OnGuiLogShow(bool show)
        {
            if (!isInit)
            {
                isInit = true;
                WOnGUILog.Init();
            }
            WOnGUILog.debugdrGUI.IsShowLog = show;
        }

        public void LogShow(bool show, bool save)
        {
            WDebug.Init(show, save);
        }

        public void Log(string data)
        {
            WDebug.Log(data);
        }

        public void LogError(string data)
        {
            WDebug.LogError(data);
        }
    }
}
