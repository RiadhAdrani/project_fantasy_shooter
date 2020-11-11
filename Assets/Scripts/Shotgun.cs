using UnityEngine;

public class Shotgun : Weapon
{
    private int spreadNumber = 1;
            public int getSpreadNumber() { return spreadNumber; }
            public void setSpreadNumber(int spreadNumber) { this.spreadNumber = spreadNumber; }

    private float spreadAngle = 0.5f;
            public float getSpreadAngle() { return spreadAngle; }
            public void setSpreadAngle(float spreadAngle) { this.spreadAngle = spreadAngle; }


    public int mSpreadNumber = 1;
    public float mSpreadAngle = 0.5f;

    private void ShotgunConstructor() {
        Constructor();
        setSpreadNumber(mSpreadNumber);
        setSpreadAngle(mSpreadAngle);
    }

    private void Start()
    {
        ShotgunConstructor();
    }

    public override void Reload()
    {
        
    }

    public override void Shoot()
    {

        for (int i = 0; i < spreadNumber; i++)
        {
            PlayMuzzleFlash();

            float x = Random.Range(-spreadAngle, spreadAngle);
            float y = Random.Range(-spreadAngle, spreadAngle);

            RaycastHit hit;
            Physics.Raycast(getShootingReference().transform.position, getShootingReference().transform.forward + new Vector3(x,y,0), out hit, getRange());

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
}
