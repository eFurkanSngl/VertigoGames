using UnityEngine;
using UnityEngine.UI;


public enum SliceType
{
    Reward,
    Bomb
}

[CreateAssetMenu(menuName ="SliceData")]
public class SliceData : ScriptableObject
{
    public string _id;
    public SliceType _sliceType;
    public int _baseAmount;
    public Sprite _sliceIcon;
}
