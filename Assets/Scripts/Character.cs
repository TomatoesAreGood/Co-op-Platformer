using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected float _moveSpeed;
    protected float _jumpHeight;
    protected BoxCollider2D _boxColl;
    protected float _movementDirection;
    public Transform Hand;
    public LayerMask JumpableGround;
    public Collectable HeldItem;


    private void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _boxColl = GetComponent<BoxCollider2D>();
        _moveSpeed = 10f;
        _jumpHeight = 20f;
        HeldItem = null;
        Hand = transform.GetChild(0).transform;
    }

    protected abstract void Update();
    protected abstract void OnTriggerEnter2D(UnityEngine.Collider2D collision);

    protected bool CanJump(){
        return Physics2D.BoxCast(_boxColl.bounds.center, _boxColl.bounds.size, 0f, Vector2.down, 0.1f, JumpableGround);
    }

    protected bool CanMoveLeft()
    {
        return !Physics2D.BoxCast(_boxColl.bounds.center, _boxColl.bounds.size, 0f, Vector2.left, 0.01f, JumpableGround);
    }

    protected bool CanMoveRight()
    {
        return !Physics2D.BoxCast(_boxColl.bounds.center, _boxColl.bounds.size, 0f, Vector2.right, 0.01f, JumpableGround);
    }
 
}
