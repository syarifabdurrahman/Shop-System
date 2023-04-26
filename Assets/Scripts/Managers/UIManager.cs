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
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private GameObject invetoryPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTime(DayOfWeek dayOfWeek, string hour, string minute)
    {
        timeText.text = dayOfWeek.ToString().Substring(0, 3) + ", " + hour + ":" + minute;
    }

    public void InventoryOpen()
    {
        invetoryPanel.SetActive(true);
    }

    public void InventoryClose()
    {
        invetoryPanel.SetActive(false);
    }
}
