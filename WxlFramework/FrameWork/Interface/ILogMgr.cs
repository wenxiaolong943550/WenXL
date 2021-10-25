using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public interface ILogMgr
    {
        void OnGuiLogShow(bool show);
        void LogShow(bool show, bool save);
        void Log(string data);
        void LogError(string data);
    }
}

