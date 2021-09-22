using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject message;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            message.SetActive(false);
        }
    }
}
