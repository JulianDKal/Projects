using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    bool isMoving = false;
    public GameObject CineMachine;


    void Update()
    {
         if(Input.GetMouseButton(1)){
            isMoving = true;
        }
        else isMoving = false;

        if(isMoving == false){
            CineMachine.SetActive(false);
        }
        else CineMachine.SetActive(true);
    }
}
