using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    public PlayerController player;
    private int weaponIndex = 0;
    public GameObject[] missileDirections = new GameObject[5];

    [SerializeField] private float nextTimeToFire;

    public Weapon[] wList = new Weapon[11];

    // Start is called before the first frame update
    void Start()
    {

        foreach (Weapon w in wList)
        {
            w.setShootingReference(player.getCamera());
        }

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

            for (int i = 0; i < wList.Length; i++)
            {
                if (i == index) wList[i].gameObject.SetActive(true);
                else wList[i].gameObject.SetActive(false);
            }

            // wList[weaponIndex].setShootingReference(player.getPlayerCamera());
        }       
    }
}