using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Collectable
{
    protected override void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.GetComponent<FireBoy>() != null || other.gameObject.GetComponent<WaterGirl>() != null)
        {
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
