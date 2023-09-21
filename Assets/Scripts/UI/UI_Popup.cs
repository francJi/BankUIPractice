using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    UIManager UIinstance;
    private void Awake()
    {
        if (UIinstance == null)
        {
            UIinstance = UIManager.UIinstance;
        }
    }
    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        UIinstance.SetCanvas(gameObject, true);
        RectTransform _rectTransform = gameObject.GetComponent<RectTransform>();
        _rectTransform = transform as RectTransform;

        return true;
    }
}
