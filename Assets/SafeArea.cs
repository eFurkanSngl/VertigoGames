using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
    private RectTransform _panel;
    private Rect _lastSafeArea;
    private ScreenOrientation _lastOrientation;
    private Vector2Int _lastResolution;

    private void Awake()
    {
        _panel = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    private void Update()
    {
        if (Screen.safeArea != _lastSafeArea ||
            Screen.orientation != _lastOrientation ||
            Screen.width != _lastResolution.x ||
            Screen.height != _lastResolution.y)
        {
            ApplySafeArea();
        }
    }

    private void ApplySafeArea()
    {
        if (_panel == null)
            return;

        Rect safeArea = Screen.safeArea;
        _lastSafeArea = safeArea;
        _lastOrientation = Screen.orientation;
        _lastResolution = new Vector2Int(Screen.width, Screen.height);

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _panel.anchorMin = anchorMin;
        _panel.anchorMax = anchorMax;

        _panel.offsetMin = Vector2.zero;
        _panel.offsetMax = Vector2.zero;
    }
}
