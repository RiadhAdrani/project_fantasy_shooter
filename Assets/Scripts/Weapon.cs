using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public GameObject missile = null;
    public float fireRatePerSecond = 1;
    public AmmoType.Type ammo = AmmoType.Type.HIT_SCAN;
    public int range = 100;
    public ParticleSystem muzzleFlash;
}