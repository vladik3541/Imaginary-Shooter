using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    public event Action OnShoot;
    
    [SerializeField] private Transform shootPointDirection;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private ProjectileFactory projectileFactory;
    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private LayerMask shootableMask;
    
    private float _lastShootTime;
    private ProjectileType _currentProjectileType = ProjectileType.Normal;
    public ProjectileType CurrentProjectileType { get { return _currentProjectileType; } }

    public void Use()
    {
        if (Time.time >= _lastShootTime )
        {
            OnShoot?.Invoke();
            Shoot();
            _lastShootTime = Time.time + shootCooldown;
        }
    }

    private void Shoot()
    {
        Vector3 direction = shootPointDirection.forward;
        if (Physics.Raycast(shootPointDirection.position, direction, out RaycastHit hit, float.MaxValue,
                shootableMask))
        {
            GameObject projectile = projectileFactory.CreateProjectile(_currentProjectileType);
            projectile.transform.position = projectileSpawnPoint.position;
            projectile.GetComponent<IProjectile>().Launch(hit);
        }
    }
    public void SetProjectileType(ProjectileType projectileType)
    {
        _currentProjectileType = projectileType;
    }
}
