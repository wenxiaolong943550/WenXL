using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using XHFrameWork;

public class TestOne : BaseUI
{
    private TestOneModule oneModule;

    private Button btn;
    private Text text;

    public override EnumUIType GetUIType()
    {
        return EnumUIType.TestOne;
    }

    void Start()
    {
        text = transform.Find("Panel/Text").GetComponent<Text>();
        oneModule = ModuleManager.Instance.Get<TestOneModule>();
        text.text = "Gold: " + oneModule.Gold;

        EventTriggerListener listener = EventTriggerListener.Get(transform.Find("Panel/Button").gameObject);
        listener.SetEventHandle(EnumTouchEventType.OnClick, Close, 1, "1234");
    }

    protected override void OnAwake()
    {
        MessageCenter.Instance.AddListener("AutoUpdateGold", UpdateGold);
        base.OnAwake();
    }

    protected override void OnRelease()
    {
        MessageCenter.Instance.RemoveListener("AutoUpdateGold", UpdateGold);
        base.OnRelease();
    }

    private void UpdateGold(Message message)
    {
        int gold = (int)message["gold"];
        Debug.Log("TestOne UpdateGold : " + gold);
        text.text = "Gold: " + gold;
    }

    private void Close(GameObject _listener, object _args, params object[] _params)
    {
        int i = (int)_params[0];
        string s = (string)_params[1];
        Debug.Log(i);
        Debug.Log(s);
        UIManager.Instance.OpenUICloseOthers(EnumUIType.TestTwo);
    }
}

