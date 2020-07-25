using UnityEngine;

public class ShieldUI : MonoBehaviour
{

    [SerializeField] private RectTransform _healthBar;

    private float _maxWidth;

    private void OnEnable()
    {
        GameEventManager.OnTakeDamage += UpdateShieldDisplay;
    }

    private void OnDisable()
    {
        GameEventManager.OnTakeDamage -= UpdateShieldDisplay;
    }

    private void Awake()
    {
        _maxWidth = _healthBar.rect.width;
    }

    private void UpdateShieldDisplay(float percentDamage)
    {
        var percentHealthRemaining = 1 - percentDamage;
        _healthBar.sizeDelta = new Vector2(_maxWidth * percentHealthRemaining, _healthBar.rect.height);
    }
}
