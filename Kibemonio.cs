using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using CriarPersonagem.Jogador;

public class Kibemonio : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    public GameObject DieEffect;
    public AudioSource soundDie;
    public GameObject Player;
    public JogadorStats stats;

    public int destPoint = 0;
    public float health = 3;
    public float lookRadius = 10;
    public float damage = 20;
    //public static bool isDead;
    private bool hasBeenShot = false;

    private Animator anim;

    private bool isInRadius = false;

    [SerializeField]
    private int numberOfAttacksMade = 0;

    [SerializeField]
    private WaitForSeconds waitForAttack = new WaitForSeconds(1f);

    //Collider[] hitCollider;
     void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void Search()
    {
        anim.Play("Walk");
        RaycastHit hit;
        if (Physics.SphereCast(gameObject.transform.position, 5, gameObject.transform.forward, out hit, lookRadius))
        {
            JogadorPrincipalMovimento target = hit.transform.GetComponent<JogadorPrincipalMovimento>();
            if (target != null)
                isInRadius = true;
        }
    }

    private void FixedUpdate()
    {
        Search();

        if ((isInRadius != false) || (hasBeenShot == true))
            gameObject.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        anim.Play("Walk");
        if (points.Length == 0)
            return;
        agent.destination = RandomPoint().position;
        destPoint = (destPoint + 1) % points.Length;
    }

    Transform RandomPoint()
    {
        int valorMax = points.Length;
        int valorSorteado = Random.Range(0, valorMax);
        return points[valorSorteado];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0 )
        {
            soundDie.Play();
            Die();
        }
        hasBeenShot = true;
    }

    public void Die()
    {
        GameObject DieGO = Instantiate(DieEffect, transform.position, Quaternion.identity);
        Destroy(DieGO, 2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (stats == null) 
            {
                stats = other.GetComponent<JogadorStats>();
            }
            if (numberOfAttacksMade <= 0)
            {
                StartCoroutine(Attack());
                numberOfAttacksMade = +1;

            }
        }
    }

    private IEnumerator Attack()
    {
        stats.TakeDamage(damage);
        yield return waitForAttack;
        numberOfAttacksMade = 0;
    }
}
