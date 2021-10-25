using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfoView : MonoBehaviour
{
    public Text hpText;
    public RawImage hpBar;

    public void ShowHP(int hp)
    {
        hpText.text = hp.ToString();
        hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(hp, 20);
    }

    public void OpenView()
    {
        this.gameObject.SetActive(true);
    }
    public void CloseView()
    {
        this.gameObject.SetActive(false);
    }
}
