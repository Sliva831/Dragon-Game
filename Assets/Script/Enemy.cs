using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
  //private Animator anim;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
     // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Анимация по получению урона 
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // Анимация смерти
            dead = true;
          //GetComponent<PlayerController>().enabled = false;
        }

    }

}
