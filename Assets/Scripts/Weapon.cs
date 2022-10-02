using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    float damage = 30f;

    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] GameObject hitEffect;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
        Shoot();
        }
    }
    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
    }
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void ProcessRayCast()
    {
        RaycastHit hit;
        {
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                Debug.Log("I hit" + hit.transform.name);
                CreateHitEffect(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target == null) return;
                target.TakeDamage(damage);
            }
            else
            {
                return;
            }
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact,.1f);
    }
}
