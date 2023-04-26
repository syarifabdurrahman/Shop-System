using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI textInfo;

    int myindex;

    public void SetIndex(int index)
    {
        myindex = index;
    }

    // Set Data
    public void Set(ItemSlot itemSlot)
    {
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = itemSlot.itemDataSO.icon;

        if (itemSlot.itemDataSO.isStackable)
        {
            textInfo.gameObject.SetActive(true);
            textInfo.text = itemSlot.count.ToString();
        }
        else
        {
            textInfo.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        iconImage.sprite = null;
        iconImage.gameObject.SetActive(false);

        textInfo.gameObject.SetActive(false);
    }

}
