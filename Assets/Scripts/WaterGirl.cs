using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class WaterGirl : Character
{
    protected override void Update(){
        if (Input.GetKey(KeyCode.RightControl))
        {
            if (HeldItem != null){
                Drop();
            }        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this._movementDirection > -1)
            {
                this._movementDirection -= 0.01f;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this._movementDirection < 1)
            {
                this._movementDirection += 0.01f;
            }
        }
        else
        {
            this._movementDirection = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            if (CanMoveRight())
            {
                _rb.velocity = new Vector2(this._movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if (CanMoveLeft())
            {
                _rb.velocity = new Vector2(this._movementDirection * _moveSpeed, _rb.velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        }
     
    }

    protected override void OnTriggerEnter2D(UnityEngine.Collider2D other){
        if (other.gameObject.CompareTag("Lava")){
                IsAlive = false;
        }
        base.OnTriggerEnter2D(other);
    }

}
