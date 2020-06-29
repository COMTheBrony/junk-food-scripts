using CriarPersonagem.Jogador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DiscoHamburgador : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    public GameObject player;
    public JogadorStats stats;

    public GameObject dieEffect;

    private Animator anim;

    public GameObject[] kibes;

    public int destPoint = 0;
    public float health = 7;
    public float lookRadius = 5;
    private bool isInRadius = false;
    private bool hasBeenShot = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void Search()
    {
        //anim.Play();
        RaycastHit hit;
        if(Physics.SphereCast(gameObject.transform.position, 5, -gameObject.transform.up, out hit, lookRadius))
        {
            JogadorPrincipalMovimento target = hit.transform.GetComponent<JogadorPrincipalMovimento>();
            if (target != null)
                isInRadius = true;
        }
    }

    private void FixedUpdate()
    {
        Search();
        if((isInRadius == true) || (hasBeenShot == true))
        {
            //fazer os kibes caçarem o jogador
            foreach(GameObject kibe in kibes)
            {
                kibe.GetComponent<Kibemonio>();
                kibe.gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        //anim.Play();
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            //play som de morte
            Die();
        }
        hasBeenShot = true;
    }

    void Die()
    {
        GameObject dieGo = Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(dieGo);
        Destroy(gameObject);
    }
}
