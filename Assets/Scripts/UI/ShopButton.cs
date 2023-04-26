using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI textInfo;
    [SerializeField] private TextMeshProUGUI textBuyPrice;
    [SerializeField] private TextMeshProUGUI textSellPrice;

    int myindex;
    private ItemSlot slot;

    public void SetIndex(int index)
    {
        myindex = index;
    }

    public void Set(ItemSlot itemSlot)
    {
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = itemSlot.itemDataSO.icon;

        textInfo.text = itemSlot.itemDataSO.nameItem;
        textBuyPrice.text = "Buy " + itemSlot.itemDataSO.buyPrice.ToString();
        textSellPrice.text = "Sell " + itemSlot.itemDataSO.sellPrice.ToString();

        slot = itemSlot;
    }

    public void Clean()
    {
        iconImage.sprite = null;
        iconImage.gameObject.SetActive(false);

        textBuyPrice.gameObject.SetActive(false);
        textSellPrice.gameObject.SetActive(false);
    }

    public void Buy()
    {
        // Check price here

        if (InventoryPanel.instance.itemContainer != null)
        {
            InventoryPanel.instance.itemContainer.Add(slot.itemDataSO, 1);
        }
    }

    public void Sell()
    {
        // Check price here

        if (InventoryPanel.instance.itemContainer != null)
        {
            InventoryPanel.instance.itemContainer.Sell(slot.itemDataSO, 1);
        }
    }

}
