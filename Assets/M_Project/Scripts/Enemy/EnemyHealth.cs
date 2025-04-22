using System;
using UnityEngine;
public class EnemyHealth : Health
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private Animator animator;
    [SerializeField] private string animatorTrigger = "Die";
    protected override void OnDeath()
    {
        animator.SetTrigger(animatorTrigger);
        Destroy(gameObject, timeToDestroy);
    }
}
