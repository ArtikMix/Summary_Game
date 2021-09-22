using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCar : MonoBehaviour
{
    private Vector3 up = new Vector3(0, 1, 0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().AddForce(up, ForceMode.Impulse);
        }
    }
}
