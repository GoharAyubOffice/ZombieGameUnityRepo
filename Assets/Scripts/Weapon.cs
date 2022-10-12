using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlots;
    [SerializeField] AmmoType ammoType;

    [SerializeField] TextMeshProUGUI ammoText;
    public bool canShoot = true;

    [SerializeField] float timeBetweenShots = 0.5f;

    private void OnEnable() 
    {
        canShoot = true;
    }

    private void Update()
    {
        DisplayAmmoText();

        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
        StartCoroutine(Shoot());
        }
    }

    private void DisplayAmmoText()
    {
        int currenAmmo = ammoSlots.GetCurrentAmmo(ammoType);
        ammoText.text = currenAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlots.GetCurrentAmmo(ammoType) > 0)
        {
        PlayMuzzleFlash();
        ProcessRayCast();
        ammoSlots.ReduceCurrentAmmo(ammoType);
        }
       yield return new WaitForSeconds(timeBetweenShots);
       canShoot = true;
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
