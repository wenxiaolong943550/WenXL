using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWork
{
    public static class GameMgr
    {
        public static IDataMgr DataMgr = null;
        public static IGameObjMgr GameObjMgr = null;
        public static IHttpMgr HttpMgr = null;
        public static IIEnumeratorMgr IEnumeratorMgr = null;
        public static ILogMgr LogMgr = null;
        public static INetMgr NetMgr = null;
        public static IPathMgr PathMgr = null;
        public static IPoolMgr PoolMgr = null;
        public static IResMgr ResMgr = null;
        public static ISaveMgr SaveMgr = null;
        public static ISceneMgr SceneMgr = null;
        public static ISoundMgr SoundMgr = null;
        public static IStateMgr StateMgr = null;
        public static IUIMgr UIMgr = null;

        public static void Init()
        {
            DataMgr = new DataMgr();
            GameObjMgr = new GameObjMgr();
            HttpMgr = new HttpMgr();
            IEnumeratorMgr = new IEnumeratorMgr();
            LogMgr = new LogMgr();
            NetMgr = new NetMgr();
            PathMgr = new PathMgr();
            PoolMgr = new PoolMgr();
            ResMgr = new ResMgr();
            SaveMgr = new SaveMgr();
            SceneMgr = new SceneMgr();
            SoundMgr = new SoundMgr();
            StateMgr = new StateMgr();
            UIMgr = new UIMgr();
        }
    }
}
