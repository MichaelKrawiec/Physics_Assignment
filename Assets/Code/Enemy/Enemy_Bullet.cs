using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float laserSpeed;
    public float timer;
    public Rigidbody2D rb;
    Ship_Steering Ship_Steering;
    //public GameObject explosion;


    Ship_Steering target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ship_Steering = GameObject.Find("player").GetComponent<Ship_Steering>();
        target = GameObject.FindObjectOfType<Ship_Steering>();
        moveDirection = (target.transform.position - transform.position).normalized * laserSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void Update()
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;    //Rotates the object according to player pos

        timer += 1.0f * Time.deltaTime;
        if (timer >= 10.0f)
        {
            GameObject.Destroy(gameObject);
        }
        if (!Ship_Steering.isActiveAndEnabled)
        {
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //GameObject e = Instantiate(explosion) as GameObject; // Creates explosion on collision with player weapon
            //e.transform.position = transform.position;
            Destroy(gameObject); // Destroys bullet
        }
    }
}
