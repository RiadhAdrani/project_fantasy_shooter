using UnityEngine;

public class Enemy : Character,IEnemy
{
    private float meleePower;
            public float mMeleePower;
            public void setMeleePower(float power) { meleePower = power; }
            public float getMeleePower() { return meleePower; }

    private float meleeRange;
            public float mMeleeRange;
            public void setMeleeRange(float range) { meleeRange = range; }
            public float getMeleeRange() { return meleeRange; }

    private float reloadTime;
            public float mReloadTime;
            public void setReloadTime(float time) { reloadTime = time; }
            public float getReloadTime() { return reloadTime; }

    private float nextTimeToAttack = 0f;
            public void setNextTimeToAttack(float time) { nextTimeToAttack = time; }
            public float getNextTimeToReload() { return nextTimeToAttack; }

    public void MeleeAttack(Character unit)
    {
        unit.TakeDamage(meleePower);
        Debug.Log("Target HP Left: " + unit.getHitPoint());
    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAwake()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeath()
    {
        DestroyObject();
    }

    public override void ApplyGravity()
    {
        throw new System.NotImplementedException();
    }

    public void eConstructor()
    {
        Constructor();
        setMeleePower(mMeleePower);
        setMeleeRange(mMeleeRange);
        setNextTimeToAttack(0);
        setReloadTime(mReloadTime);
    }

    public void rConstructor()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        eConstructor();
    }

    private void Update()
    {
        Run();
    }


}
