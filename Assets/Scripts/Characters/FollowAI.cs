using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navMeshAgent;
    public float checkRate;
    public float nextCheck;

    // Start is called before the first frame update
    void Start()
    {
        nextCheck = Time.time;

        target = UpdateTarget("Player");
        
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = target.position;

        navMeshAgent.acceleration = GetComponent<Character>().getRunSpeed();

        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            navMeshAgent.destination = target.transform.position;
            FollowTarget(target);
        }
        
    }

    private void FollowTarget(Transform target)
    {
        navMeshAgent.transform.LookAt(target);
    }

    private Transform UpdateTarget(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag).transform;
    }

}
