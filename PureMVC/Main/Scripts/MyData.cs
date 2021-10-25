using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//原始数据，不继承任何命名空间
public class MyData
{
    //等级
    private int _Level = 0;
    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }
}
