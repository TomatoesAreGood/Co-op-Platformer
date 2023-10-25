using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float maxMoveSpeed;
    private float moveSpeed;
    private float jumpHeight;
    private BoxCollider2D bottomCollider;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        bottomCollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        maxMoveSpeed = 10f;
        moveSpeed = 7f;
        jumpHeight = 20f;
    }


    void Update(){
        if (rb.velocity.magnitude < maxMoveSpeed)
        {

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * moveSpeed);

            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left, ForceMode2D.Impulse);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right, ForceMode2D.Impulse);
            }
            if (bottomCollider) { 
            }
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
