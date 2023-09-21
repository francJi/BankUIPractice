using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WithDrawMenu : SelectMenu
{
    [SerializeField] private TMP_InputField WithDrawInput;
    public WithDrawMenu()
    {
        _selectMenu = base._selectMenu;
        _depositMenu = base._depositMenu;
        _withDrawMenu = base._withDrawMenu;
    }
    public void BackToMenu()
    {
        _selectMenu.SetActive(true);
        _withDrawMenu.SetActive(false);
    }

    public void WithDraw10000()
    {
        WithDraw(10000);
    }

    public void WithDraw30000()
    {
        WithDraw(30000);
    }

    public void WithDraw50000()
    {
        WithDraw(50000);
    }

    public void WithDraw(int amount)
    {
        GameManager.Instance.Withdraw(amount);
    }

    public void CustomWithDraw()
    {
        int amount = int.Parse(WithDrawInput.GetComponent<TMP_InputField>().text);
        Debug.Log(amount);
        GameManager.Instance.Withdraw(amount);
    }
}

