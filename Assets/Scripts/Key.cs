using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum Colors{
    Red,
    Blue
}
public class Key : Collectable
{
    public Colors _color;

    protected override void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<FireBoy>() != null && _color == Colors.Red && Time.time > NextTimePickup || other.gameObject.GetComponent<WaterGirl>() != null && _color == Colors.Blue && Time.time > NextTimePickup){
            if (other.gameObject.GetComponent<Character>().HeldItem != null)
            {
                other.gameObject.GetComponent<Character>().Drop();
            }
            other.gameObject.GetComponent<Character>().HeldItem = this;
            transform.position = other.gameObject.GetComponent<Character>().Hand.position;
            transform.SetParent(other.gameObject.GetComponent<Character>().Hand);
        }
    }

}
