using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : CombatSystem
{
    public GameObject circle;
    Rigidbody rb;
    int numOfClicks;
    bool clickable = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag == "Cube"){
        rb.constraints = RigidbodyConstraints.FreezeAll;

        circle.SetActive(true);
    }
}

private void OnMouseDown() {
    if(clickable == true){
    numOfClicks++;
    transform.rotation = Quaternion.Euler(0, numOfClicks * 90, 0);
    }
}

private void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){
        clickable = false;
        circle.SetActive(false);
    }
}
}
