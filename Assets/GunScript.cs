using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCamp;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamp.transform.position, fpsCamp.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TageDamage(damage);
            }
            if (hit.transform.tag != "monster" && hit.transform.tag != "Player")
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
