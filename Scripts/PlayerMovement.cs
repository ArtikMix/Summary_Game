using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 10f;
    //private float turning = 60f;
    [SerializeField] Animator animator;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * 6f * Time.deltaTime;
        //transform.Rotate(0, horizontal, 0);
        transform.position = new Vector3(transform.position.x, 6.63f, transform.position.z);
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, vertical);
        AnimationCheck(horizontal, vertical);
    }

    private void AnimationCheck(float hor, float ver)
    {
        if (ver > 0 || ver < 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("walking", true);
        }
        else if (ver == 0 && hor == 0)
        {
            animator.SetBool("walking", false);
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("idle", true);
        }
        if (hor < 0)
        {
            animator.SetBool("walking", false);
            animator.SetBool("right", false);
            animator.SetBool("idle", false);
            animator.SetBool("left", true);
        }
        if (hor > 0)
        {
            animator.SetBool("walking", false);
            animator.SetBool("left", false);
            animator.SetBool("idle", false);
            animator.SetBool("right", true);
        }
        if (hor == 0 && ver == 0)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", false);
            animator.SetBool("walking", false);
            animator.SetBool("idle", true);
        }
    }
}
