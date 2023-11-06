using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class WaterGirl : Character
{
    protected override void Update(){
        movementDirection = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow)){
            if (CanMoveRight())
            {
                rb.velocity = new Vector2(movementDirection * moveSpeed, rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if (CanMoveLeft())
            {
                rb.velocity = new Vector2(movementDirection * moveSpeed, rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    
    }

}
