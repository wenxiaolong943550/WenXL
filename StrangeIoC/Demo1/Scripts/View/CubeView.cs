using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public AudioManager audioManager { get; set; }

    private Text scoreText;
    /// <summary>
    /// 做初始化
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
        //Debug.Log(audioManager);
    }

    void Update()
    {
        transform.Translate(new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2)) * .2f);
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetInst("Bullet");
        }
    }

    void OnMouseDown()
    {
        //加分
        Debug.Log("OnMouseDown");
        audioManager.Play("Hit");
        //触发事件
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}