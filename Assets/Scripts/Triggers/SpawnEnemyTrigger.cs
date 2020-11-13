
using UnityEngine;

public class SpawnEnemyTrigger : Trigger
{
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

    public override void setEvent()
    {
        Debug.Log("Triggered !");
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Contructor();
    }

    // Update is called once per frame
    void Update()
    {
        startEvent();
    }
}
