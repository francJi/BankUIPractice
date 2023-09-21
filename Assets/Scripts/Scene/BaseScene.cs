using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType = Define.Scene.Unknown;
    protected UIManager UIinstance;

    protected bool _init = false;

    private void Start()
    {
        Init();
    }
    protected virtual void Awake()
    {
        if (UIinstance == null)
        {
            UIinstance = UIManager.UIinstance;
        }
    }
    protected virtual bool Init()
    {
        if (_init)
        {
            return false;
        }
        _init = true;
        GameObject obj = GameObject.Find("EventSystem");
        if (obj == null)
        {
            Instantiate(Resources.Load<GameObject>("UI/EventSystem")).name = "@EventSystem";
        }

        return true;
    }
}
