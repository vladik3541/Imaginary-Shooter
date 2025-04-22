using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public event Action OnHit;
    [SerializeField] protected float maxHealth;
    protected float _health;

    public float MaxHealth { get { return maxHealth; } }
    public float CurrentHealth { get { return _health; } } 

    protected virtual void Start()
    {
        _health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        OnHit?.Invoke();
        if (_health <= 0)
        {
            OnDeath();
        }
    }
    protected abstract void OnDeath();
}
