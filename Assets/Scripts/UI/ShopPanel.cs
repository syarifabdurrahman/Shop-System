using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public ItemContainerSO itemContainer;
    [SerializeField] private List<ShopButton> buttons;

    private void Start()
    {
        SetIndex();
        ShowUI();
    }

    private void SetIndex()
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    private void ShowUI()
    {
        for (int i = 0; i < itemContainer.slots.Count; i++)
        {
            if (itemContainer.slots[i].itemDataSO == null)
            {
                buttons[i].Clean();
            }
            else
            {
                buttons[i].Set(itemContainer.slots[i]);
            }
        }
    }
}
