using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            }
            return _instance;
        }
    }

    private int cash;
    private int balance;

    [SerializeField] private GameObject CashText;
    [SerializeField] private GameObject AccountBalance;
    [SerializeField] private GameObject AccountName;
    [SerializeField] private GameObject DefficientPanel;
    
    private string cashText;
    private string balanceText;
    private string accountName;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("Cash"))
        {
            PlayerPrefs.SetInt("Cash", 100000);
            CashText.GetComponent<TextMeshProUGUI>().text = (100000).ToString();
        }
        if (!PlayerPrefs.HasKey("Balance"))
        {
            PlayerPrefs.SetInt("Balance", 0);
            AccountBalance.GetComponent<TextMeshProUGUI>().text = 0.ToString();
        }

        cash = PlayerPrefs.GetInt("Cash");
        balance = PlayerPrefs.GetInt("Balance");
        cashText = CashText.GetComponent<TextMeshProUGUI>().text;
        balanceText = AccountBalance.GetComponent<TextMeshProUGUI>().text;
        accountName = AccountName.GetComponent<TextMeshProUGUI>().text;
    }
    public void Deposit(int amount)
    {
        if (amount > 0 && cash >= amount)
        {
            cash -= amount;
            balance += amount;
            SaveData();
            UpdateUI();
        }
        else
        {
            DefficientPanel.SetActive(true);
        }
    }

    public void Withdraw(int amount)
    {
        if (amount > 0 && balance >= amount)
        {
            cash += amount;
            balance -= amount;

            SaveData();
            UpdateUI();
        }
    }

    public void AcceptDefficient()
    {
        DefficientPanel.SetActive(false);
    }
    private void UpdateUI()
    {
        cashText = "Cash: " + cash.ToString();
        balanceText = "Balance: " + balance.ToString();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Cash", cash);
        cashText = cash.ToString();
        CashText.GetComponent<TextMeshProUGUI>().text = cashText;
        PlayerPrefs.SetInt("Balance", balance);
        balanceText = balance.ToString();
        AccountBalance.GetComponent<TextMeshProUGUI>().text = balanceText;
        PlayerPrefs.Save();
    }

}
