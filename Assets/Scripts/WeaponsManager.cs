using System.Collections;
using System.Transactions;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    public Player player;
    public int weaponIndex = 0;
    public GameObject[] missileDirections = new GameObject[5];

    public float nextTimeToFire;

    public Weapon[] wList = new Weapon[11];

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToFire = Time.time;
        SelectWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwitch();
    }

    private void WeaponSwitch()
    {
        
        // knife

        // pistol
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);

        // pump action shotun
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);

        // double barrel shotgun

        // tommy gun
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);

        // minigun

        // tommy gun skin
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectWeapon(3);

        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectWeapon(4);

    }

    private void SelectWeapon(int index)
    {
        weaponIndex = index;

        for (int i =0; i < wList.Length; i++)
        {
            if (i == index) wList[i].gameObject.SetActive(true);
            else wList[i].gameObject.SetActive(false);
        }
    }

    // Shoot
    public void Shoot()
    {
        if (nextTimeToFire < Time.time)
        {
            switch (wList[weaponIndex].ammo)
            {
                case AmmoType.Type.HIT_SCAN: HitScanShoot(); break;
                case AmmoType.Type.MULTIPLE_HIT_SCAN: MultipleHitScanShoot(); break;
            }

            wList[weaponIndex].muzzleFlash.Play();

            nextTimeToFire = Time.time + 1 / wList[weaponIndex].fireRatePerSecond;
        }
        
    }

    // Shoot with a single bullet weapon 
    public void HitScanShoot()
    {
        RaycastHit hit;
        Physics.Raycast(missileDirections[0].transform.position, missileDirections[0].transform.forward, out hit, wList[weaponIndex].range);
        
        if (hit.transform != null)
        {
            Enemy target = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.TakeDamage(wList[weaponIndex].damage);
            }
        }
        
    }

    // Shoot with a multiple bullet weapon
    public void MultipleHitScanShoot()
    {
        RaycastHit[] hits = new RaycastHit[missileDirections.Length];
        Enemy[] targets = new Enemy[missileDirections.Length];

        for (int i = 0; i < missileDirections.Length; i++)
        {
            Physics.Raycast(missileDirections[i].transform.position, missileDirections[i].transform.forward, out hits[i], wList[weaponIndex].range);

            if (hits[i].transform != null)
            {
                // Display hit target in the console
                Debug.Log(hits[i].transform.name);

                targets[i] = hits[i].transform.GetComponent<Enemy>();

                if (targets[i] != null)
                {
                    targets[i].TakeDamage(wList[weaponIndex].damage);
                }
            }
        }
        
    }
}
