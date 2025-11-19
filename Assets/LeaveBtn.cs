using Zenject;

public class LeaveButton : UIBTN
{
    [Inject] private SignalBus _signalBus;

    protected override void OnClick()
    {
        _signalBus.Fire<LeaveSignal>();
    }
}