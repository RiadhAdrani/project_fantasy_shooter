using System.Transactions;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    public Player player;
    public int weaponIndex = 0;
    public Weapon[] wList = new Weapon[11];

    // Start is called before the first frame update
    void Start()
    {
        player.currentWeapon = wList[1];
    }

    // Update is called once per frame
    void Update()
    {
        WeaponSwitch();
    }

    private void WeaponSwitch()
    {
        // case skinned tommy gun
        if (Input.GetKeyDown(KeyCode.E)) SelectWeapon(0);

        // case tommy gun
        if (Input.GetKeyDown(KeyCode.R)) SelectWeapon(1);

    }

    private void SelectWeapon(int index)
    {
        player.currentWeapon = wList[index];

        for (int i =0; i < wList.Length; i++)
        {
            if (i == index) wList[i].gameObject.SetActive(true);
            else wList[i].gameObject.SetActive(false);
        }
    }
}
