using UnityEngine;

public class AssaultRifle : Weapon
{
    public override void Reload()
    {
        
    }

    public override void Shoot()
    {
        PlayMuzzleFlash();

        RaycastHit hit;
        Physics.Raycast(getShootingReference().transform.position, getShootingReference().transform.forward,out hit, getRange(), -5, QueryTriggerInteraction.Ignore);

        if (hit.transform != null)
        {
            Enemy target = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage(getDamage());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Constructor();
    }

}
