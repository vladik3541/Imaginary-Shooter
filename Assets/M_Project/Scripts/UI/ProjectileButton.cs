using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileButton : MonoBehaviour
{
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private ProjectileType projectileTypeIndex;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    private Image _imageButton;
    private void Start()
    {
        _imageButton = GetComponent<Image>();
        if (projectileTypeIndex == ProjectileType.Normal)
        {
            _imageButton.color = activeColor;
        }
    }

    public void OnButtonClick()
    {
        weaponController.CurrentWeapon.SetProjectileType(projectileTypeIndex);
    }

    private void Update()
    {
        if (projectileTypeIndex == weaponController.CurrentWeapon.CurrentProjectileType)
        {
            _imageButton.color = activeColor;
        }
        else
        {
            _imageButton.color = inactiveColor;
        }
    }
}
