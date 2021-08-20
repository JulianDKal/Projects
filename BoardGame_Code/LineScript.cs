using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    LineRenderer lr;
    Vector3 StartPos;
    Vector3 endPos;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        StartPos = transform.position;
        

        if(Input.GetKeyDown(KeyCode.Space)){
            lr.enabled = true;
            lr.SetPosition(0, StartPos);
            lr.SetPosition(1, endPos);
        }
    }
}
