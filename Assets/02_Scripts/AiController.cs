using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject player;

    private bool shouldFollow = false;
    private bool ret = false;

    private Transform startPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        startPos = agent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFollow)
        {
            agent.SetDestination(player.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else if (ret)
        {
            agent.SetDestination(player.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Front")
        {
            shouldFollow = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Front")
            ret = true;
    }
}
