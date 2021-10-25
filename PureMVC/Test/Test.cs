using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class Test : MonoBehaviour
{
    private int hp = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hp++;
            //在没有SendNotification的脚本中发送消息必须这样发。通过Facad外观发送消息。
            Facade.Instance.SendNotification(NotificationString.HPCHANGE, hp);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            hp--;
            Facade.Instance.SendNotification(NotificationString.HPCHANGE, hp);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Facade.Instance.SendNotification(NotificationString.HPVIEWOPEN);
        }
    }
}
