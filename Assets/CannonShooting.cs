using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    public GameObject AimingPoint;
    public GameObject CannonBullet;

    private float time = 0.0f;
    public float period = 5f;

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (time >= period)
        {
            time = 0.0f;

            // bullet position
            GameObject bulletObject = Instantiate(CannonBullet);
            bulletObject.transform.position = AimingPoint.transform.position;

            // initial force
            Rigidbody rb = bulletObject.GetComponent<Rigidbody>();
            rb.AddForce(-AimingPoint.transform.forward * 20, ForceMode.Impulse);
            //Debug.Log(transform.forward * 100);

        }
    }
}
