using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI textInfo;
    [SerializeField] private GameObject holder;

    int myindex;
    private ItemSlot slot;

    private void Awake()
    {
        holder.SetActive(false);
    }

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

        slot = itemSlot;
    }

    public void Clean()
    {
        iconImage.sprite = null;
        iconImage.gameObject.SetActive(false);

        textInfo.gameObject.SetActive(false);
    }

    public void GoToHolder()
    {
        if (slot.itemDataSO.bodyPart != null)
        {
            holder.SetActive(true);
        }
    }

    public void BackFromHolder()
    {
        holder.SetActive(false);
    }

    public void UseItem()
    {
        BodyPartsSelector.Instance.NextBodyPart(slot.itemDataSO.bodyPart.bodyPartIndexSelectoer);
        PlayerController.instance.gameObject.GetComponent<BodyPartsManager>().UpdateBodyParts();
        BodyPartsManager.instance.UpdateBodyParts();
    }

    public void NotUse()
    {
        BodyPartsSelector.Instance.PreviousBody(slot.itemDataSO.bodyPart.bodyPartIndexSelectoer);
        PlayerController.instance.gameObject.GetComponent<BodyPartsManager>().UpdateBodyParts();
        BodyPartsManager.instance.UpdateBodyParts();
    }

}
