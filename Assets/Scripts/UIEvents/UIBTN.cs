using UnityEngine;
using UnityEngine.UI;

public abstract class UIBTN : EventListenerMono
{
    [SerializeField] private Button _button;

    protected abstract void OnClick();

    protected override void RegisterEvents()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected override void UnRegisterEvents()
    {
        _button.onClick.RemoveListener(OnClick);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_button == null)
            _button = GetComponent<Button>(); 
    }
#endif
}
