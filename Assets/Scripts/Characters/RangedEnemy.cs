using UnityEngine;

public class RangedEnemy : Enemy,IEnemy
{

    private float missilePower;
            public float mMissilePower;
            public void setMissilePower(float power) { missilePower = power; }
            public float getMissilePower() { return missilePower; }

    private float missileRange;
            public float mMissileRange;
            public void setMissileRange(float range) { missileRange = range; }
            public float getMissileRange() { return missileRange; }

    private new void rConstructor()
    {
        eConstructor();
        setMissilePower(mMissilePower);
        setMissileRange(mMissileRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        rConstructor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
