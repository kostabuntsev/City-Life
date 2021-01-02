using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem mazzleFlash;
    public GameObject impactEffect;
    public float impactForce = 70f;
    public float fireRate = 15f;

    private float nttf = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2") && Time.time >= nttf)
        {
            nttf = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        mazzleFlash.Play();

        RaycastHit hitInfo;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            GameObject impactGameObject = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGameObject, 2f);
        }
    }

}
