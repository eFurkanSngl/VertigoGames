using TMPro;
using UnityEngine;


public class WheelResultView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;

    public void ShowReward(SliceData data)
    {
        if(_resultText != null)
        {
            _resultText.text = $"Up To Rewards {data._sliceIcon.name} {data._baseAmount}x In your inventory";
        }
    }


    public void Clear()
    {
        if (_resultText == null) return;
        _resultText.text = string.Empty ;
        gameObject.SetActive(false) ;
    }
}