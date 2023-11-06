using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{


    private void OnCollisionEnter2D(UnityEngine.Collision2D other){
        if (other.gameObject.GetComponent<FireBoy>() != null || other.gameObject.GetComponent<WaterGirl>() != null){
            GameManager.Coins += 5;
            Destroy(gameObject);
        }
    }

}
