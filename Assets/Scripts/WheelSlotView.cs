using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelSlotView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _amountText_value;

    public SliceData CurrentData {  get; private set; }
    public void SetData(SliceData data , int zoneIndex)
    {
        CurrentData = data;

        if(_iconImage != null)
        {
            _iconImage.sprite = data._sliceIcon;

        }

        if (_amountText_value == null) return;

        if(data._sliceType == SliceType.Bomb)
        {
            _amountText_value.text = "1";
        }
        else
        {
            int finalAmount = data._baseAmount;
            _amountText_value.text = finalAmount + "x";
        }
    }
}
