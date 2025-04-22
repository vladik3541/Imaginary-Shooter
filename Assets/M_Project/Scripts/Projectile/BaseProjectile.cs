using System;
using System.Collections;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour, IProjectile
{
    public event Action OnHit;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    private float _radiusDetectin = 0.05f;

    public void Launch(RaycastHit hit)
    {
        StartCoroutine(MoveProjectile(hit));

    }
    private IEnumerator MoveProjectile(RaycastHit hit)
    {
        Vector3 startPosition = transform.position;
        float distance = Vector3.Distance(transform.position, hit.point);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            transform.position = Vector3.Lerp(startPosition, hit.point, 1 - (remainingDistance / distance));

            remainingDistance -= speed * Time.deltaTime;

            yield return null;
        }
        transform.position = hit.point;
        OnHit?.Invoke();
        Hit();
        
    }

    protected virtual void Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusDetectin);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Health healthComponent))
            {
                healthComponent.TakeDamage(damage);
                return;
            }
        }
    }
}
