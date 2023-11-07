using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Checkpoint : MonoBehaviour
{
    public Vector3 Pos;

    void Start()
    {
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(UnityEngine.Collision2D other){
        if (other.gameObject.GetComponent<FireBoy>() != null || other.gameObject.GetComponent<WaterGirl>() != null){
            GameManager.Checkpoint = this;
            GetComponent<SpriteRenderer>().color = new Color(0 , 255, 0, 255);
        }
    }
    private void Activate(){

    }
}
