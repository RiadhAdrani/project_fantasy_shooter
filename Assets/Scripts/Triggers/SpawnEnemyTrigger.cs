
using UnityEngine;

public class SpawnEnemyTrigger : Trigger
{
    // Name of the trigger
    // used for debugging
    public string triggerName = "Spawn Enemy Trigger";

    // enemy list to be spawned @ spawn locations
    private Enemy[] enemyList;
            public void setEnemyList(Enemy[] list) { enemyList = list; }
            public Enemy[] getEnemyList() { return enemyList; }
            public Enemy[] mEnemyList = new Enemy[0];

    // spawn locations
    private Transform[] spawnLocations;
            public void setSpawnLocations(Transform[] locations) { spawnLocations = locations; }
            public Transform[] getSpawnLocations() { return spawnLocations; }
            public Transform[] mSpawnLocations = new Transform[0];

    // spawn delay
    private float spawnDelay;
            public void setSpawnDelay(float delay) { spawnDelay = delay; }
            public float getSpawnDelay() { return spawnDelay; }
            public float mSpawnDelay = 0.5f;

    // specific variable for this child class
    private bool isOK = false;
    private float nextTimeToSpawn;
    private int index = 0;

    // public constructor
    public void mConstructor()
    {
        Constructor();
        setEnemyList(mEnemyList);
        setSpawnDelay(mSpawnDelay);
        setSpawnLocations(mSpawnLocations);
        isOK = false;
        index = 0;
    }

    // setting the condition
    // This : the player pass through the trigger
    public override bool setCondition()
    {
        if (!getIsTriggered())
        {
            foreach (TriggerCollider t in getColliders())
            {
                if (t.getHasTriggered()) return true;
            }
        }
        return false;
    }

    // Send the OK confirmation to the function
    public override void setEvent()
    {
        
        Debug.Log("Started Event : "+triggerName);

        isOK = true;

        Debug.Log("Finished Event : " + triggerName);
    }

    // spawn enemies with a little delay between them
    public void spawnEnemies()
    {
        if (isOK && nextTimeToSpawn <= Time.time && index < enemyList.Length)
        {
            Instantiate(enemyList[index],
                    spawnLocations[Random.Range(0, spawnLocations.Length)],
                    false);

            nextTimeToSpawn = Time.time + spawnDelay;
            Debug.Log("Spawned Enemies :" + index + 1);
            index++;

            if (index >= enemyList.Length) { 
                isOK = false;
                setIsFinished(true);
            } 
        }
    }

    // Start is called before the first frame update
    // initiliazing the object
    void Start()
    {
        mConstructor();
    }

    // Update is called once per frame
    void Update()
    {
        startEvent();
        spawnEnemies();
    }

}
