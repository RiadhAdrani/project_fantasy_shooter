using System.Collections;
using System.Transactions;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    public Player player;
    private int weaponIndex = 0;
    public GameObject[] missileDirections = new GameObject[5];

    [SerializeField] private float nextTimeToFire;

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

    public void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            wList[weaponIndex].Shoot();
            nextTimeToFire = Time.time + (1.0f / wList[weaponIndex].getFireRatePerSecond()) ;
        }
          
    }

    private void WeaponSwitch()
    {
        
        // knife

        // pistol
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);

        // pump action shotun
        // if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);

        // double barrel shotgun

        // tommy gun
        // if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);

        // minigun

        // tommy gun skin
        // if (Input.GetKeyDown(KeyCode.Alpha4)) SelectWeapon(3);

        // if (Input.GetKeyDown(KeyCode.Alpha5)) SelectWeapon(4);

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
}