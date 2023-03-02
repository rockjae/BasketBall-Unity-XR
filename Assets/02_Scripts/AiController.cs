using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 180,0);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
