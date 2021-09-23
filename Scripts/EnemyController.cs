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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5f;
        agent.stoppingDistance = 0.2f;
    }

    void Update()
    {
        if (city)
        {
            //agent.SetDestination(target.position);//ошибка
            //agent.Move(target.position);//ошибка
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
            Instantiate(git, transform.position, transform.rotation);
        if (transform.name == "Enemy_Linked")
            Instantiate(linked, transform.position, transform.rotation);
    }
}
