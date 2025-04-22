using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectile
{
    protected override void Hit()
    {
        base.Hit();
        Destroy(gameObject);
    }
}
