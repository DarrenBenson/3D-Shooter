using UnityEngine;



public class Shield : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _regenerationAmount = 1;
    [SerializeField] private float _regenerationRate = 2f;

    private void Start()
    {
        _currentHealth = _maxHealth;
        InvokeRepeating("Regenerate", _regenerationRate, _regenerationRate);
    }

    private void Regenerate()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _regenerationAmount;
        }
        else if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }       
    }

    public void TakeDamage(int damageAmount =1)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        GameEventManager.TakeDamage(_currentHealth / (float)_maxHealth);
        if(_currentHealth <= 1)
        {
            Debug.Log("I B DED!");
        }
    }

}
