using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class WheelResultHandler : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    [Inject] private SliceManager _sliceManager;
    [Inject] private WheelResultView _wheelResultView;
    [Inject] private SpinStageManager _stageManager;
    [Inject] private WheelUIManager _wheelUIManager;
    [Inject] private RunInventoryManager _inventory;

    [SerializeField] private GameObject _wheelCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    private bool _isSubscribed;

    private void Start()
    {
        _signalBus.Subscribe<SpinCompletedSignal>(OnSpinCompleted);
    }

    private void OnDisable()
    {
        if (_signalBus != null && _isSubscribed)
        {
            _signalBus.TryUnsubscribe<SpinCompletedSignal>(OnSpinCompleted);
            _isSubscribed = false;
        }
    }

    private void OnSpinCompleted(SpinCompletedSignal signal)
    {
        var data = _sliceManager.GetSliceAt(signal._index);

        if(data == null)
        {
            Debug.Log("SLice data yok");
            return;

        }

        if(data._sliceType == SliceType.Bomb)
        {
            Debug.Log("Game Over");
            _stageManager.OnBombHit();
            _wheelUIManager.RefreshUI();
            _wheelCanvas.SetActive(false);
            _gameOverCanvas.SetActive(true);
            _inventory.Clear();
        }

        else
        {
            _wheelResultView.ShowReward(data);

            bool stageChanged = _stageManager.OnRewardSpin();
            if (stageChanged)
            {
                _wheelUIManager.RefreshUI();

            }
            _inventory.AddReward(data);
            Debug.Log("ödül alındı");

        }
    }
}
