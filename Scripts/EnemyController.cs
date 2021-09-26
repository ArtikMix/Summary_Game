using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;
    private bool city = true;
    [SerializeField] private GameObject git, linked, death_GX;
    private Animator animator;
    PlayerChar player;
    private bool once = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerChar>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0.5f;
        agent.stoppingDistance = 0.2f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (city)
        {
            if (Vector3.Distance(transform.position, target.position) > 2f)
            {
                agent.SetDestination(target.position);
                animator.SetBool("attack", false);
                animator.SetBool("walk", true);
            }
            if (Vector3.Distance(transform.position, target.position) <= 2f)
            {
                if (once)
                {
                    once = false;
                    StartCoroutine(Attack());
                    Debug.Log("attack anim");
                    animator.SetBool("walk", false);
                    animator.SetBool("attack", true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Attack()
    {
        player.SetHealth(-50f);
        yield return new WaitForSeconds(1.5f);
        once = true;
    }

    IEnumerator Death()
    {
        Instantiate(death_GX, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        if (transform.name == "Enemy_Git")
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Instantiate(git, pos, transform.rotation);
            Destroy(gameObject);
        }
        if (transform.name == "Enemy_Linked")
        {
            Instantiate(linked, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
