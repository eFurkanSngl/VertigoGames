using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWheelAnim 
{
    bool IsSpinning {  get; }

    /// <summary>
    /// sliceCount = wheel üzerinde ki slice
    /// onCompleted = spin bitince hangi index de 
    /// </summary>

    public void Spin(int sliceCount, Action<int> onCompleted = null);     
}
