using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGem : MonoBehaviour
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D other){
        if (other.gameObject.GetComponent<FireBoy>() != null){
            GameManager.Coins += 10;
            Destroy(gameObject);
        }
    }
}
