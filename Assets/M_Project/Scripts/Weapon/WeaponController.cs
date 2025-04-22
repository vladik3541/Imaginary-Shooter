using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon currentWeapon;
    public Weapon CurrentWeapon
    {
        get { return currentWeapon; }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentWeapon.Use();
        }
    }
}
