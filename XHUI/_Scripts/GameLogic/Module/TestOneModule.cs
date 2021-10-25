
using System;
using XHFrameWork;

public class TestOneModule : BaseModule
{
	public int Gold { get; private set; }

	public TestOneModule ()
	{
		this.AutoRegister = true;
	}

	protected override void OnLoad ()
	{
		MessageCenter.Instance.AddListener(MessageType.Net_MessageTestOne, UpdateGold);
		base.OnLoad ();
	}

	protected override void OnRelease ()
	{
		MessageCenter.Instance.RemoveListener(MessageType.Net_MessageTestOne, UpdateGold);
		base.OnRelease ();
	}

	private void UpdateGold(Message message)
	{
		int gold = (int) message["gold"];
		if (gold >= 0)
		{
			Gold = gold;
			Message temp = new Message("AutoUpdateGold", this);
			temp["gold"] = gold;
			temp.Send();
		}
	}
}

