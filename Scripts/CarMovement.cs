using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement = new Vector3(0,0,0);
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement = new Vector3(movement.x, movement.y, 1);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            movement = new Vector3(movement.x, movement.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movement = new Vector3(movement.x, movement.y, -1);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            movement = new Vector3(movement.x, movement.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement = new Vector3(-1, movement.y, movement.z);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movement = new Vector3(0, movement.y, movement.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movement = new Vector3(1, movement.y, movement.z);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movement = new Vector3(0, movement.y, movement.z);
        }
    }

    private void FixedUpdate()
    {
        if (movement.z!=0)
            transform.Translate(movement*Time.deltaTime * speed);
    }
}
