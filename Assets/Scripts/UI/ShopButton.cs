using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        if (CurrencyManager.instance.coin > slot.itemDataSO.buyPrice)
        {
            if (InventoryPanel.instance.itemContainer != null)
            {
                InventoryPanel.instance.itemContainer.Add(slot.itemDataSO, 1);
            }

            CurrencyManager.instance.coin -= slot.itemDataSO.buyPrice;

            StartCoroutine(DelayOnOff($"You Bough Some {slot.itemDataSO.nameItem}"));

            if (slot.itemDataSO.bodyPart != null)
            {
                BodyPartsSelector.Instance.NextBodyPart(slot.itemDataSO.bodyPart.bodyPartIndexSelectoer);
                PlayerController.instance.gameObject.GetComponent<BodyPartsManager>().UpdateBodyParts();
                BodyPartsManager.instance.UpdateBodyParts();
            }
        }
        else
        {
            StartCoroutine(DelayOnOff("Not Enough Coin!"));
        }
    }

    public void Sell()
    {
        // Check price here

        ItemSlot itemSlot = InventoryPanel.instance.itemContainer.slots.Find(x => x.itemDataSO == slot.itemDataSO);

        if (itemSlot != null && itemSlot.count >= 0)
        {
            if (InventoryPanel.instance.itemContainer != null)
            {
                InventoryPanel.instance.itemContainer.Sell(slot.itemDataSO, 1);
            }

            StartCoroutine(DelayOnOff($"You Sell Some {slot.itemDataSO.nameItem}"));

            CurrencyManager.instance.coin += slot.itemDataSO.sellPrice;

            if (slot.itemDataSO.bodyPart != null)
            {
                BodyPartsSelector.Instance.PreviousBody(slot.itemDataSO.bodyPart.bodyPartIndexSelectoer);
                PlayerController.instance.gameObject.GetComponent<BodyPartsManager>().UpdateBodyParts();
                BodyPartsManager.instance.UpdateBodyParts();
            }
        }
        else
        {
            StartCoroutine(DelayOnOff($"You don't have {slot.itemDataSO.nameItem}"));
        }


    }

    private IEnumerator DelayOnOff(string info)
    {
        StopCoroutine(DelayOnOff(info));

        UIManager.Instance.feedbackShopText.text = info;

        yield return new WaitForSeconds(.5f);

        UIManager.Instance.feedbackShopText.text = "";
    }

}
