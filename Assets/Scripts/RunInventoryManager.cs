using System.Collections.Generic;
using Zenject;

public class RunInventoryManager
{
    private List<SliceData> _collectedRewards = new();

    public IReadOnlyList<SliceData> Rewards => _collectedRewards;

    public void AddReward(SliceData data)
    {
        _collectedRewards.Add(data);
    }

    public void Clear()
    {
        _collectedRewards.Clear();
    }

    public bool HasRewards => _collectedRewards.Count > 0;
}
