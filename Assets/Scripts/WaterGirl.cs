using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class WaterGirl : Character
{
    protected override void Update(){
        _movementDirection = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow)){
            if (CanMoveRight())
            {
                _rb.velocity = new Vector2(_movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if (CanMoveLeft())
            {
                _rb.velocity = new Vector2(_movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        }
    
    }

}
