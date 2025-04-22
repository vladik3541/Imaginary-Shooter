using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : BaseProjectile
{
    [SerializeField] private float radiusExplosion;
    private HitEffectSpawner _hitEffectSpawner;
    protected override void Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Health healthComponent))
            {
                healthComponent.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
