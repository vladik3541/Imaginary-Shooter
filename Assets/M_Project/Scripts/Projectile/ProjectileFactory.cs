using UnityEngine;

public enum ProjectileType { Normal, Explosive, Ricochet }

[CreateAssetMenu(fileName = "Projectile", menuName = "Projectile")]
public class ProjectileFactory : ScriptableObject
{
    [SerializeField] private GameObject normalProjectilePrefab;
    [SerializeField] private GameObject explosiveProjectilePrefab;
    [SerializeField] private GameObject ricochetProjectilePrefab;
    public GameObject CreateProjectile(ProjectileType type)
    {
        GameObject go = null;
        switch (type)
        {
            case ProjectileType.Normal:
                go = Instantiate(normalProjectilePrefab);
                break;
            case ProjectileType.Explosive:
                go = Instantiate(explosiveProjectilePrefab);
                break;
            case ProjectileType.Ricochet:
                go = Instantiate(ricochetProjectilePrefab);
                break;
        }

        return go;
    }
}