using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWeapon : MonoBehaviour
{
    [SerializeField]private Animator animator;

    [SerializeField] private Weapon weapon;
    [SerializeField] private string animationShoot = "Shoot";
    void Start()
    {
        weapon.OnShoot += PlayShoot;
    }

    private void PlayShoot()
    {
        animator.SetTrigger(animationShoot);
    }

    private void OnDestroy()
    {
        weapon.OnShoot -= PlayShoot;
    }
}
