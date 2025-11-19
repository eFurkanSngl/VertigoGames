using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpinButton : UIBTN
{
    [Inject] private SignalBus _signalBus;
    protected override void OnClick()
    {
        Spin();
    }

    private void Spin()
    {
        _signalBus.Fire<SpinButtonSignal>();
    }
}
