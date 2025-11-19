using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;

public class WheelUIManager : MonoBehaviour
{
    [Inject] private SpinStageManager _stageManager;

    [SerializeField] private WheelDataSet bronzeSet;
    [SerializeField] private WheelDataSet silverSet;
    [SerializeField] private WheelDataSet goldSet;

    [Header("References")]
    [SerializeField] private UnityEngine.UI.Image wheelBase;
    [SerializeField] private SliceManager sliceManager;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private Image _indicatorBase;
 


    public void RefreshUI()
    {
        WheelDataSet dataSet = bronzeSet;

        switch (_stageManager.CurrentStage)
        {
            case SpinStage.Silver:
                dataSet = silverSet;
                break;
            case SpinStage.Gold:
                dataSet = goldSet;
                break;
        }

        wheelBase.sprite = dataSet.wheelSprite;
        _indicatorBase.sprite = dataSet.indicator;

        if(stageText !=null)
        {
            stageText.text = dataSet.displayName;
            stageText.color = dataSet.stageTextColor;
        }


        sliceManager.SetSlices(dataSet.sliceItems,0);
    }
}
