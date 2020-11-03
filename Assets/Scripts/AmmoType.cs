using UnityEngine;

public class AmmoType : MonoBehaviour
{
    public enum Type
            {
                // Knife, pistol, shotgun, doubel barrel shotgun, tommy gun, minigun
                HIT_SCAN,

                // Rocket Launcher
                ROCKET,

                // Grenade Launcher
                GRENADE,

                // Lasergun
                LASER,

                // Cannon
                BALL
            };
}
