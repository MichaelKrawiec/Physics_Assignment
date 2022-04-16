using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector2 movement;


    [SerializeField]
    float dirX, dirY;

    public bool left = false;
    public bool right = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        MovePlayer(movement);
        rb.velocity = new Vector2(dirX, dirY);
    }

    void MovePlayer(Vector2 direction)
    {
        //float xPos = animator.transform.position.x;
        //float yPos = animator.transform.position.y;

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // Change sprite to right
        {

            animator.SetBool("left", false);
            animator.SetBool("right", true);

            left = false;
            right = true;

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // Change sprite to left
        {

            animator.SetBool("left", true);
            animator.SetBool("right", false);

            left = true;
            right = false;

        }
    }
}
