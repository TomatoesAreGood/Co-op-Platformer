using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Key : Collectable
{
    protected override void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.GetComponent<FireBoy>() != null || other.gameObject.GetComponent<WaterGirl>() != null) {
            print("Collide");
            other.gameObject.GetComponent<Character>().HeldItem = this;
            transform.position = other.gameObject.GetComponent<Character>().Hand.position;
            transform.SetParent(other.gameObject.GetComponent<Character>().Hand);
        }
    }
}
