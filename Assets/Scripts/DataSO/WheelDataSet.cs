using UnityEngine;
using System.Collections.Generic;
using TMPro;

[CreateAssetMenu(menuName = "Wheel/WheelDataSet")]
public class WheelDataSet : ScriptableObject
{
    public string displayName;              
    public Sprite wheelSprite;              
    public List<SliceData> sliceItems;
    public Sprite indicator;
    public Color stageTextColor = Color.white;
}
