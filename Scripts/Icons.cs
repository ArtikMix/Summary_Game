using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position)>=5f)
            transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (transform.name == "GitHub")
                Application.OpenURL("https://github.com/ArtikMix");
            if (transform.name == "LinkedIn")
                Application.OpenURL("https://www.linkedin.com/in/artsemi-katkovski-48ba81210/");
        }
    }
}
