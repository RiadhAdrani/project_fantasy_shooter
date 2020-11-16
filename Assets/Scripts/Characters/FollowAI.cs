using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public Transform target;
    public Character character;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        navMeshAgent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        character.Run();

        Vector3 lookPos;
        Quaternion targetRotation;

        setDestination(target);

        character.setVelocity(navMeshAgent.desiredVelocity);

        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = false;

        lookPos = target.position - transform.position;
        
        lookPos.y = 0;
        
        targetRotation = Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, 
                                              targetRotation, 
                                              Time.deltaTime * character.getWalkSpeed()
                                              );

        character.getController().Move(character.getVeclocity().normalized * character.getRunSpeed() * Time.deltaTime);

        navMeshAgent.velocity = character.getController().velocity;

    }

    private void setDestination(Transform target)
    {
        navMeshAgent.destination = target.position;
    }

    private void FollowTarget(Transform target)
    {
        navMeshAgent.transform.LookAt(target);
        setDestination(target);
    }
}
