using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectWeapon : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlashPrefab;
    [SerializeField] private Transform muzzleFlashTransform;
    [SerializeField] private Weapon weapon;
    
    private ParticleSystem _muzzleFlash;
    // Start is called before the first frame update
    private void Start()
    {
        _muzzleFlash = Instantiate(muzzleFlashPrefab).GetComponent<ParticleSystem>();
        _muzzleFlash.transform.SetParent(muzzleFlashTransform);
        _muzzleFlash.transform.rotation = muzzleFlashPrefab.transform.rotation;
        _muzzleFlash.transform.localPosition = Vector3.zero;
        weapon.OnShoot += PlayMuzzleFlash;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Emit(1);
    }

    private void OnDestroy()
    {
        weapon.OnShoot -= PlayMuzzleFlash;
    }
}
