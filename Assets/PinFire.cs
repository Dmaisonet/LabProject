using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject pinPrefab;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(pinPrefab, firePoint.position, firePoint.rotation);
    }
}
