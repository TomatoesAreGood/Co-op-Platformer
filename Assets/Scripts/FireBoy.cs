using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FireBoy : Character
{
    protected override void Update(){
        _movementDirection = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D)){
            if (CanMoveRight()) {
                _rb.velocity = new Vector2(_movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.A)){
            if (CanMoveLeft()){
                _rb.velocity = new Vector2(_movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && CanJump())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        }
    
    }
}
