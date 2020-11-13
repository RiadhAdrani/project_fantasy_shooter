using UnityEngine;

public class TriggerCollider : MonoBehaviour
{

    public bool hasTriggered = false;

    public string tagged = "";

    public bool getHasTriggered() { return hasTriggered; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagged)) hasTriggered = true;
    }
}