using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController2 : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public GameObject player;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        /*if (player.transform.localPosition.z > 10.32756 && player.transform.localPosition.z < 15.77759)
        {
            agent.SetDestination(player.transform.position);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            agent.SetDestination(startPos);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }*/
    }

}
