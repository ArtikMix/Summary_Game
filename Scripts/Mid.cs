using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid : MonoBehaviour
{
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject car;
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            car.SetActive(false);
            human.SetActive(true);
        }
    }
}
