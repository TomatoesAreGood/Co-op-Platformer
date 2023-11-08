using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D _rb;
    protected float _moveSpeed;
    protected float _jumpHeight;
    public BoxCollider2D BoxColl;
    protected float _movementDirection;
    public Transform Hand;
    public LayerMask JumpableGround;
    public Collectable HeldItem;
    public bool IsAlive;
    public bool ExitLevel;


    private void Start(){
        _rb = GetComponent<Rigidbody2D>();
        BoxColl = GetComponent<BoxCollider2D>();
        _moveSpeed = 10f;
        _jumpHeight = 20f;
        HeldItem = null;
        Hand = transform.GetChild(0).transform;
        IsAlive = true;
        ExitLevel = false;
    }

    protected abstract void Update();
    protected abstract void OnTriggerEnter2D(UnityEngine.Collider2D collision);

    public void Drop()
    {
        HeldItem.NextTimePickup = Time.time + 1f;
        HeldItem.transform.parent = null;
        HeldItem = null;
    }

    protected bool CanJump(){
        return Physics2D.BoxCast(BoxColl.bounds.center, BoxColl.bounds.size, 0f, Vector2.down, 0.1f, JumpableGround);
    }

    protected bool CanMoveLeft()
    {
        return !Physics2D.BoxCast(BoxColl.bounds.center, BoxColl.bounds.size, 0f, Vector2.left, 0.01f, JumpableGround);
    }

    protected bool CanMoveRight()
    {
        return !Physics2D.BoxCast(BoxColl.bounds.center, BoxColl.bounds.size, 0f, Vector2.right, 0.01f, JumpableGround);
    }
 
}
