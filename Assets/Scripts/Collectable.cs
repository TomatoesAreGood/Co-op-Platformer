using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected abstract void OnTriggerEnter2D(UnityEngine.Collider2D collision);
}
