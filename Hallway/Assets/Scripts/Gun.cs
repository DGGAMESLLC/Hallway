using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate;
    private float nextFire;

    public Camera fpsCam;

    private AudioManager audioManager;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        void Shoot ()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Gravity_One target = hit.transform.GetComponent<Gravity_One>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
