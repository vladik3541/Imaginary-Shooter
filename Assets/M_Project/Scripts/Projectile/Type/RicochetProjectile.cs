using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetProjectile : BaseProjectile
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private int maxRicochets = 3;
    
    private int _ricochetCount = 0;
    private Transform _currentTarget;
    
    protected override void Hit()
    {
        base.Hit();

        _currentTarget = FindNextTarget(transform);
    
        if (_currentTarget != null)
        {
            StartCoroutine(Move());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Move()
    {
        while (_ricochetCount < maxRicochets && _currentTarget != null)
        {
            while (Vector3.Distance(transform.position, _currentTarget.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, speed * Time.deltaTime);
                yield return null;
            }

            transform.position = _currentTarget.position;
            HitRicochet();
            yield return null;
        }
    }
    void HitRicochet()
    {
        if (_currentTarget != null && _currentTarget.TryGetComponent(out Health healthComponent))
        {
            healthComponent.TakeDamage(damage);
            
            _ricochetCount++;
        }

        if (_ricochetCount > maxRicochets)
        {
            Destroy(gameObject);
            return;
        }

        Transform nextTarget = FindNextTarget(_currentTarget);
        if (nextTarget != null)
        {
            _currentTarget = nextTarget;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private Transform FindNextTarget(Transform from)
    {
        Collider[] hits = Physics.OverlapSphere(from.position, detectionRadius);
        List<Transform> validTargets = new List<Transform>();

        foreach (var hit in hits)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                validTargets.Add(enemy.transform);
            }
        }

        if (validTargets.Count == 0) return null;

        int randomIndex = Random.Range(0, validTargets.Count);
        return validTargets[randomIndex];
    }

   
}
