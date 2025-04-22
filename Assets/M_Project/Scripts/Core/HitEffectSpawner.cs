using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectExplosionPrefab;
    [SerializeField] private float lifeTimeExplosiontEffect;
    [SerializeField] private BaseProjectile projectile;

    private void OnEnable()
    {
        projectile.OnHit += SpawnEffectExplosion;
    }

    private void SpawnEffectExplosion()
    {
        if (hitEffectExplosionPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(effect, lifeTimeExplosiontEffect);
        }
    }

    private void OnDisable()
    {
        projectile.OnHit -= SpawnEffectExplosion;
    }
}
