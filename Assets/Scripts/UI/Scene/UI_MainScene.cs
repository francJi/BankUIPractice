using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainScene : UI_Scene
{
    enum Texts
    {
        MainNameText,
        CashBoxNameText,
        CashText,
        AccountNameText,
        AccountBalanceNameText,
        AccountBalanceText,
    }

    enum Buttons
    {

    }

    private void Start()
    {
        Init();
    }
    protected override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }
        //TODO
        BindText(typeof(Texts));

        GetTextMesh((int)Texts.MainNameText).text = "Sparta Bank\r\nATM";
        GetTextMesh((int)Texts.CashBoxNameText).text = "현금";
        GetTextMesh((int)Texts.CashText).text = "10000"; // 추후에 PlayerPrefs에서 잔액 받아와야함
        GetTextMesh((int)Texts.AccountNameText).text = "지민규";
        GetTextMesh((int)Texts.AccountBalanceNameText).text = "Balance";
        GetTextMesh((int)Texts.AccountBalanceText).text = "0"; // 추후에 PlayerPrefs에서 잔액 받아와야함
        return true;
    }
}
