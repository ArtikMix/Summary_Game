using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChar : MonoBehaviour
{
    private float health = 100f;
    [SerializeField] private GameObject lose;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject[] gfx;

    private void Start()
    {
        slider.value = health;
    }

    public float SetHealth(float hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
            slider.value = health;
            return health;
        }
        if (health <= 0)
        {
            health = 0;
            slider.value = health;
            Death();
            return health;
        }
        return health;
    }

    private void Death()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<MouseLook>().enabled = false;
        foreach(GameObject g in gfx)
        {
            g.SetActive(false);
        }
        lose.SetActive(true);
    }
}
