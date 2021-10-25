using UnityEngine;
using System.Collections;

public class DeactiveForTime : MonoBehaviour {


    void OnEnable()
    {
        Invoke("Deactive", 3);
    }

    void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
