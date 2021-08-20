using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float speed = 0.05f;
    public float range = 20;

    void Update()
    {
        
        Vector3 mousePos = Input.mousePosition;
        {
        if(mousePos.y > 1020) {
            float yNeu = transform.position.y + speed;
            if(yNeu > range) yNeu = range;
            transform.position = new Vector3(transform.position.x, yNeu, -10f);            
        }
        
        
        if(mousePos.y < 60){
            float yNeuUnten = transform.position.y - speed;
            if(yNeuUnten < -1.69f) yNeuUnten = -1.69f;
            transform.position = new Vector3(transform.position.x, yNeuUnten, -10f);
        }
        
    }
        
        
    }
}
