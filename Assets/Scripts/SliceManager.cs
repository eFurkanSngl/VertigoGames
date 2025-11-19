using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SliceManager : MonoBehaviour
{
    [Header("Slice Slot Ref")]
    [SerializeField] private List<WheelSlotView> _slots;

    private List<SliceData> _allSlices;
    public int SlotCount => _slots.Count;

    [Inject]
    private void Const(List<SliceData> allSlices)
    {
        _allSlices = allSlices;
    }

    private void Start()
    {
        InitializeSlots(0);
    }

    public SliceData GetSliceAt(int index)
    {
        if(index < 0 || index >= _slots.Count) return null;

        return _slots[index].CurrentData;
    }
    public WheelSlotView GetSlot(int index)
    {
        if (index < 0 || index >= _slots.Count)
            return null;

        return _slots[index];
    }
    public void InitializeSlots(int zoneIndex)
    {
        if(_allSlices == null || _allSlices.Count == 0)
        {
            Debug.Log("SliceManager empty");
            return;
        }

        for(int i = 0; i < _slots.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0,_allSlices.Count);
            var sliceData = _allSlices[randomIndex];

            _slots[i].SetData(sliceData,zoneIndex);
        }
    }
    public void SetSlices(List<SliceData> dataList, int zoneIndex = 0)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].SetData(dataList[i], zoneIndex);
        }
    }

}
