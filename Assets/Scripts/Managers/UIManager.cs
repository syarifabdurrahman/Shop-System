using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private GameObject invetoryPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI moneyTextShop;
    public TextMeshProUGUI feedbackShopText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        invetoryPanel.SetActive(false);
        shopPanel.SetActive(false);
        feedbackShopText.text = "";
    }

    public void UpdateTime(DayOfWeek dayOfWeek, string hour, string minute)
    {
        timeText.text = dayOfWeek.ToString().Substring(0, 3) + ", " + hour + ":" + minute;
    }

    public void ToggleGameObject(GameObject gameObject, bool setActive)
    {
        gameObject.SetActive(setActive);
    }

    public void InventoryOpen()
    {
        ToggleGameObject(invetoryPanel, true);
        PlayerController.instance.canMove = false;
    }

    public void InventoryClose()
    {
        ToggleGameObject(invetoryPanel, false);
        PlayerController.instance.canMove = true;
    }

    public void ShopOpen()
    {
        ToggleGameObject(shopPanel, true);
        PlayerController.instance.canMove = false;
    }

    public void ShopClose()
    {
        ToggleGameObject(shopPanel, false);
        PlayerController.instance.canMove = true;
    }

    #region Coin
    public void UpdateCoinUI(int coin)
    {
        moneyText.text = coin.ToString() + " CN";
        moneyTextShop.text = moneyText.text;
    }
    #endregion
}
