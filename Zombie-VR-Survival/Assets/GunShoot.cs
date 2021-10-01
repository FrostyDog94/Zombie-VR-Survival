using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public AudioSource gunShot;
    public GameObject muzzleFlash;
    public Transform BarrelTransform;
    public GameObject bulletImpact;

    public void Shoot()
    {
        //Create muzzle flash
        GameObject mf = Instantiate(muzzleFlash, BarrelTransform.position, transform.rotation);
        mf.transform.parent = gameObject.transform;
        gunShot.Play();
        Destroy(mf, 0.08f);

        //Create bullet impact
        RaycastHit hit;
        Physics.Raycast(BarrelTransform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
        GameObject bi = Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bi, 3);

        //Kill enemy
        if (hit.transform.GetComponent<zombieAI>() != null)
        {
            hit.transform.GetComponent<zombieAI>().isDead = true;
        }
    }
}
