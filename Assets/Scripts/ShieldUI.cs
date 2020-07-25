using UnityEngine;

public class ShieldUI : MonoBehaviour
{

    [SerializeField] private RectTransform _healthBar;

    private float _maxWidth;

    private void OnEnable()
    {
        GameEventManager.OnUpdateHealthBar += UpdateHealthBar;
    }

    private void OnDisable()
    {
        GameEventManager.OnUpdateHealthBar -= UpdateHealthBar;
    }

    private void Awake()
    {
        _maxWidth = _healthBar.rect.width;
    }

    private void UpdateHealthBar(float percentHealthRemaining)
    {
        _healthBar.sizeDelta = new Vector2(_maxWidth * percentHealthRemaining, _healthBar.rect.height);
    }
}
