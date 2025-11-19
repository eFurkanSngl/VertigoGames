using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardItemUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _nameText;

    public void SetData(Sprite icon, int amount, string name)
    {
        _icon.sprite = icon;
        _nameText.text = name;
    }
}
