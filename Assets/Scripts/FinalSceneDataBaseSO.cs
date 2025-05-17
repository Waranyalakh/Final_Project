using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FinalSceneDataBaseSO : ScriptableObject
{
    public List<Sprite> framesList = new();
    public List<Sprite> rankList = new();
    [TextArea(3,5)]
    public List<string> victoryTextList = new();

}
