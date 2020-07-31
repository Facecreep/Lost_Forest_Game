using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 1;
    float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int value)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - value, 0, maxHealth);

        if (_currentHealth == 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
