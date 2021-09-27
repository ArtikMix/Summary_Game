using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private LayerMask layer;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * 10f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.55f, layer);
        if (colliders.Length > 1)
        {
            StartCoroutine(DestroyBullet());
        }
        //Debug.Log(colliders.Length);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
