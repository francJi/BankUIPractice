using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DepositPopup : UI_Popup
{
    private int amount;
    enum Buttons
    {
        Deposit10000Button,
        Deposit30000Button,
        Deposit50000Button,
        DepositButton,
        BackButton,
    }
    enum GameObjects
    {
        DepositInputField,
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
        BindButton(typeof(Buttons));
        BindObject(typeof(GameObjects));

        //_parentObject = GetButton((int)Buttons.DepositMenuButton).gameObject.transform.parent.gameObject;
        //GetButton((int)Buttons.Deposit10000Button).gameObject.BindEvent((() => OnClickedDepositButton(10000)));
        //GetButton((int)Buttons.Deposit30000Button).gameObject.BindEvent((() => OnClickedDepositButton(30000)));
        //GetButton((int)Buttons.Deposit50000Button).gameObject.BindEvent((() => OnClickedDepositButton(50000)));

        //GetObject((int)GameObjects.DepositInputField).GetComponentInChildren<TMP_InputField>().text = amount.ToString(); // GameManager와 연동시켜야함.
        //GetButton((int)Buttons.DepositButton).gameObject.BindEvent(() => OnClickedDepositButton(amount));

        GetButton((int)Buttons.Deposit10000Button).gameObject.BindEvent(() => { OnClickedDepositButton(10000); });
        GetButton((int)Buttons.BackButton).gameObject.BindEvent(OnClickedBackButton);
        return true;
    }

    void OnClickedBackButton()
    {
        Debug.Log("Close");
        //UIManager.UIinstance.ClosePopupUI(this);
        //UIManager.UIinstance.ShowSceneUI<UI_MainScene>().gameObject.SetActive(true);
    }

    void OnClickedDepositButton(int amount)
    {
        //GameManager.Instance.Cash
        //GameManager.Instance.Balance
        //balance < amount 면, defficientPanel
        //balance >= amount 면, GameManager.Instance.Cash 에 반영
    }
}
