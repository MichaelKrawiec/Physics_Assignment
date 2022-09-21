using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Controls : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 MoveDirection;


    //public GameObject explosion;


    private bool onRangeChase = false;
    public float rangeChase = 10f;

    public enum EnemyState
    {
        CHASE,
        IDLE,
    };

    public EnemyState currentState = EnemyState.IDLE;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (onRangeChase)
        {
            currentState = EnemyState.CHASE;
        }
        else
        {
            currentState = EnemyState.IDLE;
        }


        onRangeChase = Vector3.Distance(transform.position, player.position) < rangeChase;


        switch (currentState)
        {
            case EnemyState.CHASE:
                CHASE();
                break;
            case EnemyState.IDLE:
                IDLE();
                break;
        }
        /*if (currentHealth <= 0)
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            GameObject s = Instantiate(star);
            s.transform.position = transform.position;
            Destroy(this.gameObject);
            //playerControl.currentHealth += 40f;
        }*/

        
    }
    void CHASE()
    {
        Vector3 clampedPosition = transform.position;
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        if (MoveDirection.magnitude < 1)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
    void IDLE()
    {
        //Do nothing
    }
}
