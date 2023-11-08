using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    public bool isActivated;
    public float MaxHeight;
    public float MinimunHeight;

    private void Start()
    {
        isActivated = false;
    }

    private void Update()
    {
        if (isActivated)
        {
            if (transform.position.y < MaxHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y > MinimunHeight)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.005f, transform.position.z);
            }
        }
       
    }
  
}
