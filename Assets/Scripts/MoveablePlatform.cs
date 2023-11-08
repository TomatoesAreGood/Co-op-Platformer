using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    public bool isActivated;
    private bool isRising;
    public float MaxHeight;
    public float MinimunHeight;

    private void Start()
    {
        isRising = true;
        isActivated = false;
    }

    private void Update()
    {
        if (isActivated){
            if (isRising){
                if (transform.position.y < MaxHeight){
                    transform.position = new Vector3(transform.position.x,transform.position.y + 0.002f,transform.position.z);
                }
            }else{
                if (transform.position.y > MinimunHeight){
                    transform.position = new Vector3(transform.position.x,transform.position.y - 0.002f,transform.position.z);
                }
            }
     
            if (transform.position.y >= MaxHeight){
                StartCoroutine(Pause());
                isRising = false;
            }
            if (transform.position.y <= MinimunHeight){
                StartCoroutine(Pause());
                isRising = true;
            }
        }
        
    }
    private IEnumerator Pause(){
        yield return new WaitForSeconds(2);
    }
}
