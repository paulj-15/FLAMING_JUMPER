using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBar : MonoBehaviour
{
    public static float health;
    public float MHealth = 100f;
    Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = MHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = health / MHealth;
        if (healthbar.fillAmount == 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}

