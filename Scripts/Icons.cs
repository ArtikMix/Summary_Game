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
        if (Vector3.Distance(transform.position, target.position)>=5f && transform.name!="PlayMarket")
            transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            if (transform.name == "GitHub(Clone)")
                Application.OpenURL("https://github.com/ArtikMix");
            if (transform.name == "LinkedIn(Clone)")
                Application.OpenURL("https://www.linkedin.com/in/artsemi-katkovski-48ba81210/");
        }
        if (other.tag == "Bullet")
        {
            if (transform.name == "PlayMarket")
            {
                Application.OpenURL("https://play.google.com/store/search?q=NotSeriousGames");//вставить ссылку на плеймаркет
            }
        }
    }
}
