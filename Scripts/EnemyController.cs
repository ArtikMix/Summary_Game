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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 0.5f;
        agent.stoppingDistance = 0.2f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (city)
        {
            if (Vector3.Distance(transform.position, target.position) > 1f)
            {
                agent.SetDestination(target.position);
                animator.SetBool("attack", false);
                animator.SetBool("walk", true);
            }
            else /*if (Vector3.Distance(transform.position, target.position) <= 1f)*/
            {
                Debug.Log("attack anim");
                animator.SetBool("walk", false);
                animator.SetBool("attack", true);
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

    IEnumerator Death()
    {
        Instantiate(death_GX, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        if (transform.name == "Enemy_Git")
        {
            Instantiate(git, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (transform.name == "Enemy_Linked")
        {
            Instantiate(linked, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
