using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float _yScale;
    [SerializeField] MoveablePlatform _platform;

    private void Start()
    {
        _yScale = transform.localScale.y;
    }


    private void OnTriggerEnter2D(){
        transform.localScale = new Vector3(transform.localScale.x,_yScale/2f,transform.localScale.z);
        _platform.isActivated = true;
      
    }
    private void OnTriggerExit2D(){
        transform.localScale = new Vector3(transform.localScale.x, _yScale, transform.localScale.z);
        _platform.isActivated = false;
       
    }
}
