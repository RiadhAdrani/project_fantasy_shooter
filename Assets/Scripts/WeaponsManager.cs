using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    public PlayerController player;

    private int weaponIndex = 0;

    private float nextTimeToFire;

    public Weapon[] wList = new Weapon[11];

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeToFire = Time.time;

        SelectWeapon(0);

        audioSource.clip = wList[weaponIndex].getSfx();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwitch();
    }

    public void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            wList[weaponIndex].Shoot();
            audioSource.Play();
            nextTimeToFire = Time.time + (1.0f / wList[weaponIndex].getFireRatePerSecond()) ;
        }
    }

    private void WeaponSwitch()
    {
        
        // Weapon 1
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);

        // Weapon 2
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);

        // Weapon 3
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);

        // Weapon 4
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectWeapon(3);

        // Weapon 5
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectWeapon(4);

        // Weapon 6
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectWeapon(5);

        // Weapon 7
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectWeapon(6);

    }

    private void SelectWeapon(int index)
    {
        if (index <= wList.Length - 1)
        {
            weaponIndex = index;

            wList[weaponIndex].setShootingReference(player.getCamera());
            audioSource.clip = wList[weaponIndex].getSfx();

            for (int i = 0; i < wList.Length; i++)
            {
                if (i == index) wList[i].gameObject.SetActive(true);
                else wList[i].gameObject.SetActive(false);
            }

        }       
    }
}