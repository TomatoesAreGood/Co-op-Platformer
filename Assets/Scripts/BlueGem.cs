using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D other){
        if (other.gameObject.GetComponent<WaterGirl>() != null){
            GameManager.Coins += 10;
            Destroy(gameObject);
        }
    }
}
