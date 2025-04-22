using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitView : MonoBehaviour
{
    [SerializeField] private Material mainMaterial;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private float timeViewHit;
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        health.OnHit += SetMaterial;
    }

    public void SetMaterial()
    {
        StartCoroutine(ViewHit());
    }

    private IEnumerator ViewHit()
    {
        foreach (var renderer in renderers)
        {
            renderer.material = hitMaterial;
        }
        yield return new WaitForSeconds(timeViewHit);
        foreach (var renderer in renderers)
        {
            renderer.material = mainMaterial;
        }
    }

    private void OnDisable()
    {
        health.OnHit += SetMaterial;
    }
    
}
