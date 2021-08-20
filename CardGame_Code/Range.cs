using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

    void OnClick(){
        DisplayRange();
    }
    
    public void DisplayRange(){
    //cast a Ray from the object's position shifted by 2.5 on the x-axis
    RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 2.5f, transform.position.y), Vector2.right, 2.5f);

    if(hitRight.collider != null) {
        if(hitRight.collider.tag == "Slot") {
            hitRight.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }  
    }
    //cast a Ray from the object's position shifted by 2.5 on the x-axis in negative direction
    RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 2.5f, transform.position.y), Vector2.right, 2.5f);

    if(hitLeft.collider != null) {
        if(hitLeft.collider.tag == "Slot") {
            hitLeft.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }  
    }
    //cast a Ray from the object's position shifted by 2.5 on the y-axis
    RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y + 2.5f), Vector2.right, 2.5f);
    
    if(hitUp.collider != null) {
        if(hitUp.collider.tag == "Slot") {
            hitUp.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }  
    }
    //cast a Ray from the object's position shifted by 2.5 on the y-axis in negative direction
    RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y - 2.5f), Vector2.right, 2.5f);
    
    if(hitDown.collider != null) {
        if(hitDown.collider.tag == "Slot") {
            hitDown.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }  
    }
    }
}
