using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
//Die Variablen für das Draggen
    private Vector2 startPosition; 
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject DropZone;
    private Vector3 dragOffset;
    private Camera cam;

    [SerializeField] private float speed = 100;

//Die Slots grün erscheinen lassen, wenn die Karte über ihnen ist
    private SpriteRenderer SpriteRen;
    private int collCount = 0;

//Die Variablen für die Range der Karte
    private bool isInRange;
    private float rayRange;

    Rigidbody2D rb;

    //CardManager manager;
    //BattleState currentState;

    private void Awake() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        //currentState = manager.state;
    }

    private void Update() {
        if(isDragging == true) transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + dragOffset, speed * Time.deltaTime);
    } 

    public void OnBeginDrag(){
        startPosition = transform.position;
        dragOffset = transform.position - GetMousePos();
        isDragging = true;
        
    }

    public void OnEndDrag(){
        isDragging = false;
        if(isOverDropZone == false){
            transform.position = startPosition;
        }
        else if (isOverDropZone == true){
            transform.position = DropZone.transform.position;
        }
    }

    //die Position auf dem Bildschirm
    Vector3 GetMousePos(){
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    //wenn die Karte mit einem Slot kollidiert, wird der Slot als Dropzone zugewiesen. 
    //Außerdem wird die Zahl an Slots, mit denen die Karte gerade kollidiert, inkrementiert. 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Slot"){
            collCount++;
            isOverDropZone = true;
            DropZone = other.gameObject;
            
            
        }
    }
    //Solange die Karte auf dem Slot verbleibt und nur mit einem einzigen Slot kollidiert, wird die Farbe auf Grün gesetzt
        private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Slot"){
            if(collCount == 1){
            SpriteRen = DropZone.GetComponent<SpriteRenderer>();
            SpriteRen.color = Color.green;
            }
        }
    }
    //Die Farbe wird wieder auf weiß gesetzt und der Slot als Dropzone entfernt.
    //Außerdem wird die Zahl an Slots, mit denen die Karte gerade kollidiert, dekremtiert
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Slot"){
        collCount--;
        if(SpriteRen != null) SpriteRen.color = Color.white;
        if(collCount == 0) isOverDropZone = false;
        
        }
    }







}
