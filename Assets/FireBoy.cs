using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FireBoy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpHeight;
    private BoxCollider2D boxColl;
    [SerializeField] LayerMask jumpableGround;
    private float movementDirection;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        moveSpeed = 10f;
        jumpHeight = 20f;
    }

    private void Update(){
        movementDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.R)){
            transform.position = new Vector3(0f,0f,0f);
        }

        if (Input.GetKey(KeyCode.D)){
            if (CanMoveRight()) {
                rb.velocity = new Vector2(movementDirection * moveSpeed, rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.A)){
            if (CanMoveLeft()){
                rb.velocity = new Vector2(movementDirection * moveSpeed, rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && CanJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    
    }

    private bool CanJump(){
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    private bool CanMoveLeft()
    {
        return !Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.left, 0.1f, jumpableGround);
    }

    private bool CanMoveRight()
    {
        return !Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.right, 0.1f, jumpableGround);
    }



}
