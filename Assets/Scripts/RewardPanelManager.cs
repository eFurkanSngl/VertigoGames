using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RewardPanelManager : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;
    [Inject] private RunInventoryManager _inventory;

    [Header("Panels")]
    [SerializeField] private GameObject _wheelPanel;
    [SerializeField] private GameObject _rewardPanel;

    [Header("Reward UI")]
    [SerializeField] private Transform _rewardContainer;
    [SerializeField] private RewardItemUI _rewardItemPrefab;

    private void Awake()
    {
        _signalBus.Subscribe<LeaveSignal>(OnLeaveRequested);
    }

    private void OnDestroy()
    {
        _signalBus.TryUnsubscribe<LeaveSignal>(OnLeaveRequested);
    }

    private void OnLeaveRequested()
    {
        Debug.Log("Leave Signal Received → Showing rewards");
        ShowRewards();
    }

    private void ShowRewards()
    {
        _wheelPanel.SetActive(false);
        _rewardPanel.SetActive(true);

        foreach (Transform child in _rewardContainer)
            Destroy(child.gameObject);

        foreach (SliceData data in _inventory.Rewards)
        {
            RewardItemUI item = Instantiate(_rewardItemPrefab, _rewardContainer);
            item.SetData(data._sliceIcon, data._baseAmount, data._sliceIcon.name);
        }
    }
}
