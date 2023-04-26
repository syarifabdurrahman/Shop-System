using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="CharacterBodyData/Character Part")]
public class CharacterBodyPartSO : ScriptableObject
{
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodyPartName;
    public BodyPartSO bodyPart;
}
