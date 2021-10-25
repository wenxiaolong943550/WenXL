﻿
using UnityEngine;
using System.Collections;

//一些全局的内容
namespace XHFrameWork
{
    public delegate void StateChangedEvent(object sender, EnumObjectState newState, EnumObjectState oldState);
    public delegate void MessageEvent(Message message);
    public delegate void OnTouchEventHandle(GameObject _listener, object _args, params object[] _params);
    public delegate void PropertyChangedHandle(BaseActor actor, int id, object oldValue, object newValue);
    //public delegate void OnTouchEventHandle(EventTriggerListener _listener, object _args, params object[] _params);

    //对象当前状态 
    public enum EnumObjectState
    {
        None,
        Initial,
        Loading,
        Ready,
        Disabled,
        Closing
    }

    //UI面板类型
    public enum EnumUIType : int
    {
        None = -1,
        Canvas,
        TestOne,
        TestTwo,
    }

    //触控类型
    public enum EnumTouchEventType
    {
        OnClick,
        OnDoubleClick,
        OnDown,
        OnUp,
        OnEnter,
        OnExit,
        OnSelect,
        OnUpdateSelect,
        OnDeSelect,
        OnDrag,
        OnDragEnd,
        OnDrop,
        OnScroll,
        OnMove,
    }

    public enum EnumPropertyType : int
    {
        RoleName = 1, // 角色名
        Sex,     // 性别
        RoleID,  // Role ID
        Gold,    // 宝石(元宝)
        Coin,    // 金币(铜板)
        Level,   // 等级
        Exp,     // 当前经验

        AttackSpeed,//攻击速度
        HP,     //当前HP
        HPMax,  //生命最大值
        Attack, //普通攻击（点数）
        Water,  //水系攻击（点数）
        Fire,   //火系攻击（点数）
    }

    public enum EnumActorType
    {
        None = 0,
        Role,
        Monster,
        NPC,
    }

    public enum EnumSceneType
    {
        None = 0,
        StartGame,
        LoadingScene,
        LoginScene,
        MainScene,
        CopyScene,
        PVPScene,
        PVEScene,
    }

    /// <summary>
    /// 路径定义。
    /// </summary>
    public static class UIPathDefines
    {
        /// <summary>
        /// UI预设。
        /// </summary>
        public const string UI_PREFAB = "Prefabs/";
        /// <summary>
        /// UI小控件预设。
        /// </summary>
        public const string UI_CONTROLS_PREFAB = "UIPrefab/Control/";
        /// <summary>
        /// ui子页面预设。
        /// </summary>
        public const string UI_SUBUI_PREFAB = "UIPrefab/SubUI/";
        /// <summary>
        /// icon路径
        /// </summary>
        public const string UI_IOCN_PATH = "UI/Icon/";

        public static string GetPrefabPathByType(EnumUIType _uiType)
        {
            string _path = string.Empty;
            switch (_uiType)
            {
                case EnumUIType.TestOne:
                    _path = UI_PREFAB + "TestUIOne";
                    break;
                case EnumUIType.TestTwo:
                    _path = UI_PREFAB + "TestUITwo";
                    break;
                default:
                    Debug.Log("Not Find EnumUIType! type: " + _uiType.ToString());
                    break;
            }
            return _path;
        }

        public static System.Type GetUIScriptByType(EnumUIType _uiType)
        {
            System.Type _scriptType = null;
            switch (_uiType)
            {
                case EnumUIType.TestOne:
                    _scriptType = typeof(TestOne);
                    break;
                case EnumUIType.TestTwo:
                    _scriptType = typeof(TestTwo);
                    break;
                default:
                    Debug.Log("Not Find EnumUIType! type: " + _uiType.ToString());
                    break;
            }
            return _scriptType;
        }
    }
}
