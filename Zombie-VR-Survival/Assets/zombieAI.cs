using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieAI : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    public Animator anim;
    Collider col;
    Rigidbody rigidBody;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Reset", true);
        col = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        

        if (isDead)
        {
            anim.SetBool("Dead", true);
            GetComponent<NavMeshAgent>().speed = 0;
            Destroy(gameObject, 5);
            col.enabled = false;
            rigidBody.useGravity = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Terrain")
        {
            agent.enabled = true;
        }
    }
}
