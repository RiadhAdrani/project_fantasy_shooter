using UnityEngine;

public class Pistol : Weapon
{

    public void Start()
    {
        Constructor();
    }

    public override void Reload()
    {
        
    }

    public override void Shoot()
    {
        PlayMuzzleFlash();

        RaycastHit hit;
        Physics.Raycast(getShootingReference().transform.position, getShootingReference().transform.forward, out hit, getRange());

        if (hit.transform != null)
        {
            Enemy target = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage(getDamage());
            }
        }

    }

    
}
