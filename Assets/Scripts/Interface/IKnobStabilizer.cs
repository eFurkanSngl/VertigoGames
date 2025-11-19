using System.Collections.Generic;
using UnityEngine;

public interface IKnobStabilizer
{
    void CacheInitialRotations(List<Transform> knobs);
    void ApplyStabilization(List<Transform> knobs);
    void ResetToInitial(List<Transform> knobs);
}