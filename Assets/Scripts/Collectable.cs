using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected abstract void OnCollisionEnter2D(UnityEngine.Collision2D other);
}
