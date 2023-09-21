using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] protected GameObject _selectMenu;
    [SerializeField] protected GameObject _depositMenu;
    [SerializeField] protected GameObject _withDrawMenu;
    public void MoveToDeposit()
    {
        _selectMenu.SetActive(false);
        _depositMenu.SetActive(true);
    }

    public void MoveToWithDraw()
    {
        _selectMenu.SetActive(false);
        _withDrawMenu.SetActive(true);
    }
}
