using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float moveSpeed;
    protected float jumpHeight;
    protected BoxCollider2D boxColl;
    public LayerMask jumpableGround;
    protected float movementDirection;
    protected List<Collectable> inventory;

    protected void Start(){
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        moveSpeed = 10f;
        jumpHeight = 20f;
        inventory = new List<Collectable>();
    }

    protected abstract void Update();

    protected bool CanJump(){
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    protected bool CanMoveLeft()
    {
        return !Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.left, 0.01f, jumpableGround);
    }

    protected bool CanMoveRight()
    {
        return !Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.right, 0.01f, jumpableGround);
    }
}
