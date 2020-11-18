using UnityEngine;
using UnityEngine.AI;

public class FollowAI : MonoBehaviour
{
    public Character target;
    public NavMeshAgent navMeshAgent;
    public Enemy unit;
    public float checkRate;
    public float nextCheck;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        nextCheck = Time.time;

        target = UpdateTarget("Player").GetComponent<Character>();
        
        navMeshAgent.destination = target.transform.position;

        navMeshAgent.acceleration = unit.getRunSpeed();

        navMeshAgent.stoppingDistance = unit.getMeleeRange();

        navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            navMeshAgent.destination = target.transform.position;
            FollowTarget(target.transform);

            if (navMeshAgent.remainingDistance <= unit.getMeleeRange())
            {
                if (Time.time >= unit.getNextTimeToReload())
                {
                    if ( Vector3.Distance(transform.position,target.transform.position) <= unit.getMeleeRange())
                    {
                        unit.setNextTimeToAttack(Time.time + unit.getReloadTime());
                        unit.MeleeAttack(target);
                        Debug.Log("Attacked Player !!!");
                    }
                }
            }
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
