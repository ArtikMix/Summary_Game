using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform _camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x_Rot = Input.GetAxis("Mouse X") * 2f;
        float y_Rot = Input.GetAxis("Mouse Y") * 2f;
        player.Rotate(player.rotation.x, x_Rot, player.rotation.z);
        _camera.Rotate(x_Rot, 0f, 0f);
    }

    private void OnDrawGizmos()
    {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Vector3 size = new Vector3(1, 1, 1);
        Gizmos.DrawCube(center, size);
    }
}
