using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class FireBoy : Character
{
    protected override void Update(){
        if (Input.GetKey(KeyCode.Q))
        {
            if (HeldItem != null){
                Drop();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (this._movementDirection > -1f) {
                this._movementDirection -= 0.01f;
            } 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (this._movementDirection < 1f) {
                this._movementDirection += 0.01f;
            }
        }
        else { 
            this._movementDirection = 0;
        }

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

    protected override void OnTriggerEnter2D(UnityEngine.Collider2D other){
        if (other.gameObject.CompareTag("Water")){
                IsAlive = false;
        }
        base.OnTriggerEnter2D(other);
    }

}
