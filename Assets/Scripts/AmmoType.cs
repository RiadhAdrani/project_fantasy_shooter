using UnityEngine;

public class AmmoType : MonoBehaviour
{
    public enum Type
            {
                // Knife, pistol, tommy gun, minigun
                HIT_SCAN,

                // shotgun, doubel barrel shotgun
                MULTIPLE_HIT_SCAN,

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
