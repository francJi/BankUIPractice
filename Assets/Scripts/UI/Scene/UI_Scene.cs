using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    UIManager UIinstance;

    protected override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        UIinstance.SetCanvas(gameObject, false);
        return true;
    }
    private void Awake()
    {
        if (UIinstance == null)
        {
            UIinstance = UIManager.UIinstance;
        }
    }
}
