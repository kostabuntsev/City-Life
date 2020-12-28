using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooter : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject AimingPoint;
    public GameObject CannonBullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {

            // bullet position
            GameObject bulletObject = Instantiate(CannonBullet);
            bulletObject.transform.position = AimingPoint.transform.position;

            // initial force
            Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
            rb.AddForce(fpsCam.transform.forward * 20, ForceMode.Impulse);
            Debug.Log(fpsCam.transform.forward);
        }
    }
}
