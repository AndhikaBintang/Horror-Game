using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private state_machine Statemachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnownPos;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Path path;
    public Vector3 LastKnowPos { get => lastKnownPos; set => lastKnownPos = value; }

    [Header("Sight Value")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    [Header("Weapon value")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]
    public float fireRate;

    [SerializeField]
    public string currentState;
    // Start is called before the first frame update
    void Start()
    {
        Statemachine = GetComponent<state_machine>();
        agent = GetComponent<NavMeshAgent>();
        Statemachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = Statemachine.Activestate.ToString();
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPLayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPLayer >= -fieldOfView && angleToPLayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up*eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo,sightDistance)) 
                    {
                        if(hitInfo.transform.gameObject==player)
                        {
                            return true;
                        }
                    }

                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }

        }
        return false;
    }
}
