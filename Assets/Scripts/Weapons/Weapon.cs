using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public float mDamage = 1.0f;
    public int mRange = 10;
    public int mMagazineSize = -1;
    public ParticleSystem mMuzzleFlash = null;
    public float mFireRatePerSecond;
    public GameObject mShootingReference = null;

    public void Constructor()
    {
        setDamage(mDamage);
        setRange(mRange);
        setMagazineSize(mMagazineSize);
        setMuzzleFlash(mMuzzleFlash);
        setFireRatePerSecond(mFireRatePerSecond);
        setShootingReference(mShootingReference);
        setSfx(mSfx);
    }

    // How much damage is dealt by the weapon
    private float damage;
            public float getDamage() { return damage; }
            public void setDamage(float damage) { this.damage = damage; }

    // For How much long can the weapon missile reach 
    private int range;
            public int getRange() { return range; }
            public void setRange(int range) { this.range = range; }

    // Capacity of the magazine
    private int magazineSize;
            public int getMagazineSize() { return magazineSize; } 
            public void setMagazineSize(int magazineSize) { this.magazineSize = magazineSize; }
     
    // Muzzle Flash played
    private ParticleSystem muzzleFlash;
            public ParticleSystem getMuzzleFlash() { return muzzleFlash; }
            public void setMuzzleFlash(ParticleSystem muzzleFlash) { this.muzzleFlash = muzzleFlash; }

    // Fire rate per second
    private float fireRatePerSecond;
            public float getFireRatePerSecond() { return fireRatePerSecond; }
            public void setFireRatePerSecond(float fireRatePerSecond) { this.fireRatePerSecond = fireRatePerSecond; }

    // Shooting reference. generaly the player camera
    private GameObject shootingReference;
            public GameObject getShootingReference() { return shootingReference; }
            public void setShootingReference(GameObject shootingReference) { this.shootingReference = shootingReference; }

    private AudioClip sfx;
            public AudioClip mSfx;
            public AudioClip getSfx() { return sfx; }
            public void setSfx(AudioClip sfx) { this.sfx = sfx; }

    public abstract void Shoot();
    public abstract void Reload();
    public void PlayMuzzleFlash()
    {
        if (muzzleFlash != null) muzzleFlash.Play();
    }

}