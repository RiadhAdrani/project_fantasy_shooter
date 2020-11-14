using UnityEngine;

public abstract class Trigger : MonoBehaviour
{

    // condition to start the event
    private bool isTriggered = false;
            public void setIsTriggered(bool state) { isTriggered = state; }
            public bool getIsTriggered() { return isTriggered; }
            public bool mIsTriggered = false;

    // indicate the end of the event
    private bool isFinished = false;
            public void setIsFinished(bool state) { isFinished = state; }
            public bool getIsFinished() { return isFinished; }
            public bool mIsFinished = false;

    // indicates more conditions need to start the event
    private Trigger[] conditions;
            public void setConditions(Trigger[] conditions) { this.conditions = conditions; }
            public Trigger[] getConditions() { return conditions; }
            public Trigger[] mConditions = new Trigger[0];

    // triggers that will be activated when this trigger completed his event
    private Trigger[] childTriggers;
            public void setChildTriggers(Trigger[] childTriggers) { this.childTriggers = childTriggers; }
            public Trigger[] getChildTriggers() { return childTriggers; }
            public Trigger[] mChildTriggers = new Trigger[0];

    // trigger area
    private TriggerCollider[] colliders;
            public void setColliders(TriggerCollider[] colliders) { this.colliders = colliders; }
            public TriggerCollider[] getColliders() { return colliders; }
            public TriggerCollider[] mColliders;

    // public constructor
    public void Constructor()
    {
        setIsTriggered(mIsTriggered);
        setIsFinished(mIsFinished);
        setConditions(mConditions);
        setChildTriggers(mChildTriggers);
        setColliders(mColliders);
    }

    // event to be executed
    // this function will be executed in startEvent
    public abstract void setEvent();

    // condition allowing the event to be executed
    // return boolean
    public abstract bool setCondition();

    // start the event if the condition is met
    // call the condition in Update()
    public void startEvent() {
        if (setCondition() && !isTriggered && !isFinished) {
            setIsTriggered(true);
            setEvent(); 
        }
    }

    // trigger any child trigger
    // this will start the event
    public void triggerChildTriggers()
    {
        foreach (Trigger t in childTriggers)
        {
            t.setIsTriggered(true);
        }
    }

    // activate the gameObject of the child trigger
    // if the gameObject of trigger is not set to active,
    // the script won't start
    public void activateChildTriggers()
    {
        foreach (Trigger t in childTriggers)
        {
            t.gameObject.SetActive(true);
        }
    }

    // disable the gameObject of the child trigger
    // if the gameObject of trigger is not set to active,
    // the script won't start
    public void disableChildTriggers()
    {
        foreach (Trigger t in childTriggers)
        {
            t.gameObject.SetActive(false);
        }
    }

    // disable the gameObject of any linked TriggerCollider
    public void disableTriggerCollider()
    {
        foreach(TriggerCollider t in colliders)
        {
            t.gameObject.SetActive(false);
        }
    }
}
