using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FireBoy : Character
{
    protected override void Update(){
        movementDirection = Input.GetAxis("Horizontal");

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
}
