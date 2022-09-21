using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public Healthbar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // Makes sure health stays above 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth <= 0)
        {
            print("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sObjects")
        {
            TakeDamage(20);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }
}
