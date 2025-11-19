using System.Collections.Generic;
using UnityEngine;

public class KnobStabilizer : IKnobStabilizer
{
    private readonly List<Quaternion> _initialWorldRotations = new();

    public void CacheInitialRotations(List<Transform> knobs)
    {
        _initialWorldRotations.Clear();
        foreach (var k in knobs)
            _initialWorldRotations.Add(k.rotation);
    }

    public void ApplyStabilization(List<Transform> knobs)
    {
        for (int i = 0; i < knobs.Count; i++)
            knobs[i].rotation = _initialWorldRotations[i];
    }

    public void ResetToInitial(List<Transform> knobs)
    {
        for (int i = 0; i < knobs.Count; i++)
            knobs[i].rotation = _initialWorldRotations[i];
    }
}
