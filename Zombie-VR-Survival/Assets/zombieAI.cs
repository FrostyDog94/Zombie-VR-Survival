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
    AudioSource[] audioSources;
    AudioSource clip1;
    AudioSource clip2;
    AudioSource clip3;

    float timer;

    int rand;

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
        timer = Random.Range(2, 10);
        audioSources = GetComponents<AudioSource>();
        clip1 = audioSources[0];
        clip2 = audioSources[1];
        clip3 = audioSources[2];

        
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
            clip1.enabled = false;
            clip2.enabled = false;
            clip3.enabled = false;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = Random.Range(5, 15);
            rand = Random.Range(1, 30);

            if (rand <= 10)
            {
                clip1.Play();
            } else if (rand > 10 && rand < 20)
            {
                clip2.Play();
            } else if (rand <= 20)
            {
                clip3.Play();
            }
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
