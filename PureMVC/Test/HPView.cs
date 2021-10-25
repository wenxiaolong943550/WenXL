using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPView : MonoBehaviour
{
    public Image hpImage;

    public void ShowHP(int hp)
    {
        hpImage.fillAmount = hp / 100f;
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
