using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.MainScene;
        UIManager.UIinstance.ShowSceneUI<UI_MainScene>();
        return true;
    }

    protected override void Awake()
    {
       base.Awake();
    }
}
