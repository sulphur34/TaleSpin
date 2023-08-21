using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Collider2D _planeCollider;
    private int _maxHealth;
    private int _currentHealth;
    private int _minHealth;
    private Coroutine _coroutine;

    public void Init(int minHealth, int maxHealth, Collider2D planeCollider)
    {
        _minHealth = minHealth;
        _maxHealth = maxHealth;
        _planeCollider = planeCollider;
        _currentHealth = maxHealth;
    }        

    public void DecreaseHealth(int damageValue)
    {
        _currentHealth -= damageValue;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
        {
            _planeCollider.enabled = false;
            var coroutine = Crash();
            _coroutine = StartCoroutine(coroutine);
        }
    }

    public void IncreaseHealth(HealthIncreaser healthIncreaser)
    {
        _currentHealth += healthIncreaser.HealthAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }
    
    private IEnumerator Crash()
    {
        Vector3 originalScale = transform.localScale;
        float targetScale = originalScale.y / 2;
        float crashTime = 0f;
        float crashDuration = 2f;

        while (crashTime < crashDuration)
        {
            float normalizedTime = crashTime / crashDuration;
            transform.localScale = Vector3.Lerp(originalScale, new Vector3(targetScale, targetScale, targetScale), normalizedTime);
            crashTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
