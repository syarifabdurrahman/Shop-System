using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemData/Item")]
public class ItemSO : ScriptableObject
{
    public string nameItem;
    public bool isStackable;
    public BodyPartSO bodyPart;
    public Sprite icon;
    public int buyPrice;
    public int sellPrice;
}
