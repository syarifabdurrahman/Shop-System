using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BodyPartData/Body Part")]
public class BodyPartSO : ScriptableObject
{
    public string bodyPartName;
    public int bodyPartAnimationID;
    public int bodyPartIndexSelectoer;

    // List Containing All Body Part Animations
    public List<AnimationClip> allBodyPartAnimations = new List<AnimationClip>();
}
