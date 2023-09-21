using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DepositMenu : SelectMenu
{
    [SerializeField] private TMP_InputField DepositInput;
    public DepositMenu()
    {
        _selectMenu = base._selectMenu;
        _depositMenu = base._depositMenu;
        _withDrawMenu = base._withDrawMenu;
    }
    public void BackToMenu()
    {
        _selectMenu.SetActive(true);
        _depositMenu.SetActive(false);
    }

    public void Deposit10000()
    {
        Deposit(10000);
    }

    public void Deposit30000()
    {
        Deposit(30000);
    }

    public void Deposit50000()
    {
        Deposit(50000);
    }

    public void Deposit(int amount)
    {
        GameManager.Instance.Deposit(amount);
    }

    public void CustomDeposit()
    {
        int amount = int.Parse(DepositInput.GetComponent<TMP_InputField>().text);
        Debug.Log(amount);
        GameManager.Instance.Deposit(amount);
    }


}
