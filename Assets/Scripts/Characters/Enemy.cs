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

    public void MeleeAttack()
    {

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
