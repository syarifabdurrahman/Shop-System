using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemData/Item")]
public class ItemSO : ScriptableObject
{
    public string nameItem;
    public bool isStackable;
    public Sprite icon;
    public float buyPrice;
    public float sellPrice;
}
