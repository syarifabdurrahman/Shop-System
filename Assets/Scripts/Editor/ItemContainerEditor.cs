using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ItemContainerSO))]
public class ItemContainerEditor : Editor
{
    public override void onInspectorGUI()
    {
        ItemContainerSO container = target as ItemContainerSO;

        if (GUILayout.Button("Clear Container"))
        {
            for (int i = 0; i < container.slots.Count; i++)
            {
                container.slots[i].itemDataSO = null;
                container.slots[i].count = 0;
            }
        }
    }
}
