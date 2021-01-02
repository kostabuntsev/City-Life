using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class Bazooka : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject AimingPoint;
    public GameObject Bullet;

    public Text bazookaAmmoLeftValueText;
    public Text bazookaOutOfAmmoText;

    public float shootingCooldown = 1.5f;
    private float cooldownTimeLeft = 0f;
    public float ammoLeft = 10f;

    void Update()
    {
        cooldownTimeLeft = cooldownTimeLeft - Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimeLeft <= 0f && ammoLeft > 0f)
        {
            // bullet position
            GameObject bulletObject = Instantiate(Bullet);
            bulletObject.transform.position = AimingPoint.transform.position;

            // initial force
            Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
            rb.AddForce(fpsCam.transform.forward * 20, ForceMode.Impulse);

            cooldownTimeLeft = shootingCooldown;

            ammoLeft = ammoLeft - 1f;
            bazookaAmmoLeftValueText.text = Convert.ToString(ammoLeft);

            if (ammoLeft <= 0)
            {
                bazookaOutOfAmmoText.text = "Bazooka out of ammo!";
            }
            else
            {
                bazookaOutOfAmmoText.text = "";
            }
        }
    }
}
