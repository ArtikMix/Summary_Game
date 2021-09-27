 using UnityEngine;
using System.Collections;
public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private Animator animator;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("walking", false);
            animator.SetBool("right", false);
            animator.SetBool("idle", false);
            animator.SetBool("left", false);
            animator.SetBool("shoot", true);
            Vector3 point = new Vector3(_camera.pixelWidth / 2 - 12/4, _camera.pixelHeight / 2 - 12/2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Shoot(hitObject);
            }
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size * 2;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private void Shoot(GameObject hited)
    {
        GameObject b = Instantiate(bullet, gun.position, gun.rotation);
    }
}