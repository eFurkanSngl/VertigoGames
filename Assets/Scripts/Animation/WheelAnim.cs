using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WheelAnim : MonoBehaviour, IWheelAnim
{
    [Header("References")]
    [SerializeField] private Transform _visualRoot;

    [Header("Slices")]
    [SerializeField] private int _defaultSliceCount = 8;

    [SerializeField] private List<Transform> _knobItems = new();
    private IKnobStabilizer _stabilizer;

    [Header("Anim")]
    [SerializeField] private float _spinDuration = 2.1f;
    [SerializeField] private int _minFullTurns = 3;
    [SerializeField] private int _maxFullTurns = 4;

    [Inject] SignalBus _signalBus;
    private bool _isSubscribed;

    private Tween _spinTween;
    private Action<int> _onSpinCompleted;

    [SerializeField] private bool _slotsClockwise = true;      
    [SerializeField] private float _startOffsetDeg = 0f;
    [SerializeField] private Transform _indicator;

    public bool IsSpinning {  get; private set; }


#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_visualRoot == null)
        {
            var t = transform.Find("UI_sping_bronze_base");
            if (t != null)
                _visualRoot = t;
        }
    }
#endif
    private void Awake()
    {
        _stabilizer = new KnobStabilizer();

        if (_visualRoot != null)
            _visualRoot.localRotation = Quaternion.identity;
    }

    private void OnEnable()
    {
        if(_signalBus != null && !_isSubscribed)
        {
            _signalBus.Subscribe<SpinButtonSignal>(OnSpiRequested);
            _isSubscribed = true;
        }
    }

    private void OnDisable()
    {
        if (_signalBus != null && _isSubscribed)
        {
            _signalBus.TryUnsubscribe<SpinButtonSignal>(OnSpiRequested);
            _isSubscribed = false;
        }
    }

    private void OnSpiRequested()
    {
        if (IsSpinning) return;

        Spin(_defaultSliceCount, index =>
        {
           
        });
    }
    private int GetIndexUnderIndicator()
    {
        if (_indicator == null || _visualRoot == null || _knobItems == null || _knobItems.Count == 0)
        {
            return 0;
        }

        Vector3 center = _visualRoot.position;
        Vector2 dirIndicator = ((Vector2)(_indicator.position - center)).normalized;

        float bestAngle = float.MaxValue;
        int bestIndex = 0;

        for (int i = 0; i < _knobItems.Count; i++)
        {
            Transform knob = _knobItems[i];
            if (knob == null) continue;

            Vector2 dirKnob = ((Vector2)(knob.position - center)).normalized;

            float angle = Vector2.Angle(dirIndicator, dirKnob);

            if (angle < bestAngle)
            {
                bestAngle = angle;
                bestIndex = i;
            }
        }

        return bestIndex;
    }
    public void Spin(int sliceCount, Action<int> onCompleted = null)
    {
        if (IsSpinning)
            return;

        IsSpinning = true;

        if (sliceCount <= 0)
            sliceCount = _defaultSliceCount;

        _stabilizer.CacheInitialRotations(_knobItems);

        float anglePerSlice = 360f / sliceCount;
        int visualIndex = UnityEngine.Random.Range(0, sliceCount);
        int fullTurns = UnityEngine.Random.Range(_minFullTurns, _maxFullTurns + 1);
        float targetAngle = fullTurns * 360f + visualIndex * anglePerSlice;

        _spinTween?.Kill(false);

        _spinTween = _visualRoot
            .DOLocalRotate(new Vector3(0, 0, -targetAngle), _spinDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic)
            .OnUpdate(() =>
            {
                _stabilizer.ApplyStabilization(_knobItems);
            })
            .OnComplete(() =>
            {
                IsSpinning = false;

                int winnerIndex = GetIndexUnderIndicator();

                _stabilizer.ResetToInitial(_knobItems);

                _onSpinCompleted?.Invoke(winnerIndex);
                _signalBus.Fire(new SpinCompletedSignal(winnerIndex));

                onCompleted?.Invoke(winnerIndex);
            });
    }



    private void OnDestroy()
    {
        _spinTween.Kill(false);
    }

}
