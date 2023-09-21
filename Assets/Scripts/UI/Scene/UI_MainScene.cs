using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainScene : UI_Scene
{
    [SerializeField] private GameObject _parentObject;
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
        DepositMenuButton,
        WithDrawMenuButton,
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
        BindButton(typeof(Buttons)); 

        GetTextMesh((int)Texts.MainNameText).text = "Sparta Bank\r\nATM";
        GetTextMesh((int)Texts.CashBoxNameText).text = "����";
        GetTextMesh((int)Texts.CashText).text = "10000"; // ���Ŀ� PlayerPrefs���� �ܾ� �޾ƿ;���
        GetTextMesh((int)Texts.AccountNameText).text = "���α�";
        GetTextMesh((int)Texts.AccountBalanceNameText).text = "Balance";
        GetTextMesh((int)Texts.AccountBalanceText).text = "0"; // ���Ŀ� PlayerPrefs���� �ܾ� �޾ƿ;���

        _parentObject = GetButton((int)Buttons.DepositMenuButton).gameObject.transform.parent.gameObject;
        GetButton((int)Buttons.DepositMenuButton).gameObject.BindEvent(OnClickedDepositMenuButton);
        GetButton((int)Buttons.WithDrawMenuButton).gameObject.BindEvent(OnClickedWithdrawMenuButton);
        return true;
    }

    void OnClickedDepositMenuButton()
    {
        _parentObject.SetActive(false);
        UIManager.UIinstance.ShowPopupUI<UI_DepositPopup>();
    }

    private void OnClickedWithdrawMenuButton()
    {
        _parentObject.SetActive(false);
        UIManager.UIinstance.ShowPopupUI<UI_WithDrawPopup>();
    }
}
