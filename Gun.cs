
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 1;
    public float range;
    public float fireRate;

    public Camera fpsCam;
    public ParticleSystem Fire;
    public GameObject impactEffect;
    public AudioSource soundShooting;
    public GameObject EnemyImpact;

    public MuniçãoTela munição;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && munição.ammoOnClip != 0)
        {            
            nextTimeToFire = Time.time + 5f / fireRate;
            Shoot();
            soundShooting.Play();
            
        }


    }
    void Shoot()
    {
        if (PauseMenu.IsPaused == false)
        {
            Fire.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if (hit.collider.gameObject.TryGetComponent(out Kibemonio kibe) == true)
                    {
                        Kibemonio target = hit.transform.GetComponent<Kibemonio>();
                        if (target != null)
                        {
                            target.TakeDamage(damage);
                            GameObject impactGOO = Instantiate(EnemyImpact, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impactGOO, 1f);
                        }
                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, 0.5f);
                    }
                    if(hit.collider.gameObject.TryGetComponent(out DiscoHamburgador disco) == true)
                    {                        
                        DiscoHamburgador target = hit.transform.GetComponent<DiscoHamburgador>();
                        if(target != null)
                        {
                            target.TakeDamage(damage);
                            GameObject impactGOO = Instantiate(EnemyImpact, hit.point, Quaternion.LookRotation(hit.normal));
                            Destroy(impactGOO, 1f);
                        }
                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, 0.5f);
                    }
                }
            }
        }
        else
        {
            return;
        }
    }
}
