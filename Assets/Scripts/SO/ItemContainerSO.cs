using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public ItemSO itemDataSO;
    public int count;
}
[CreateAssetMenu(menuName = "ContainerData/Container")]
public class ItemContainerSO : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(ItemSO item, int count = 1)
    {
        if (item.isStackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.itemDataSO == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            else
            {
                itemSlot = slots.Find(x => x.itemDataSO == null);
                if (itemSlot != null)
                {
                    itemSlot.itemDataSO = item;
                    itemSlot.count = count;
                }
            }
        }
        else
        {

            // adding non stackable item
            ItemSlot itemSlot = slots.Find(x => x.itemDataSO == null);
            if (itemSlot != null)
            {
                itemSlot.itemDataSO = item;
            }
        }
    }

    public void Sell(ItemSO item, int count = 1)
    {
        if (item.isStackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.itemDataSO == item);
            if (itemSlot != null)
            {
                itemSlot.count -= count;

                if (itemSlot.count <= 0)
                {
                    itemSlot.itemDataSO = null;
                    itemSlot.count = 0;
                }
            }
            else
            {
                itemSlot = slots.Find(x => x.itemDataSO == null);
                if (itemSlot != null)
                {
                    itemSlot.count = count;
                }
            }
        }
        else
        {
            // removing non stackable item
            ItemSlot itemSlot = slots.Find(x => x.itemDataSO == null);
            if (itemSlot != null)
            {
                itemSlot.itemDataSO = null;
            }
        }
    }
}
