public enum SpinStage
{
    Bronze,
    Silver,
    Gold
}
public class SpinStageManager
{
    public SpinStage CurrentStage { get; private set; } = SpinStage.Bronze;

    private int _spinCount;

    public bool OnRewardSpin()
    {
        _spinCount++;

        var oldStage = CurrentStage;

    
        if (_spinCount == 5)
        {
            CurrentStage = SpinStage.Silver;
        }
        else if (_spinCount == 30)
        {
            CurrentStage = SpinStage.Gold;
        }
        else
        {
            CurrentStage = SpinStage.Bronze;
        }

        return oldStage != CurrentStage;
    }

    public void OnBombHit()
    {
        _spinCount = 0;
        CurrentStage = SpinStage.Bronze;
    }
}
