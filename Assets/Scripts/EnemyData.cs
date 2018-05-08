using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void LoseHealth(float value)
    {
        currentHealth -= value;
        if(currentHealth <= 0.0f)
        {
            Destroy(this.gameObject);
        }
        else
        {
            UpdateHealthSlider();
        }
    }
    void UpdateHealthSlider()
    {
        this.transform.GetComponentInChildren<Slider>().value = currentHealth / maxHealth;
    }
}
