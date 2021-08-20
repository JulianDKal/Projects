using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject Obstacle1, Obstacle2, Obstacle3;
    Rigidbody2D rb;
    bool rightServe = true;
    bool spielGestartet = false;

    //Die Spieler
    public float moveSpeed = 1;
    public float AImoveSpeed = 0.7f;
    public GameObject Player1;
    public GameObject Player2;

    //Der Score
    public Text player1Text;
    public Text player2Text;
    public static int player1Score = 0;
    public static int player2Score = 0;

    //Audio
    public AudioSource hitWall;
    public AudioSource hitPlayer;
    public AudioSource hitObstacle;

    //Szenencheck
    bool sceneIsAI = false;

    //Das Ende vom Spiel
    public GameObject Player1Wins;
    public GameObject Player2Wins;
    public GameObject Button;


    //Das Spiel wird beendet, sobald ein Spieler 10 Punkte erreicht hat
    void EndGame1(){
        Player1Wins.SetActive(true);
        Time.timeScale = 0f;
        Button.SetActive(true);

    }
    void EndGame2(){
        Player2Wins.SetActive(true);
        Time.timeScale = 0f;
        Button.SetActive(true);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetObstacles();

        spielGestartet = false;

        
        if(player2Score > player1Score){
            rightServe = false;
        }
        

        if(rightServe == true){
            transform.position = new Vector3(7.42f,0,0);
        }
        else {
            transform.position = new Vector3(-7.42f,0,0);
        }
        //Szenencheck
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Level01AI") {
            sceneIsAI = true;
        }

        //Die KI macht den Aufschlag automatisch
        if(sceneIsAI == true){
            if(rightServe == false){
                Invoke(nameof(Aufschlag), 1);
                }
        }

    }

    void Aufschlag(){
        rb.AddForce(new Vector2(200, 300));
        spielGestartet = true;
    }

    
    void Update()
    {
        //Aufschlag
        if(rb.velocity.x == 0){
            if(rightServe == true && Input.GetKeyDown(KeyCode.LeftArrow)){
                rb.AddForce(new Vector2(-200, 300));
                spielGestartet = true;
            }
            else if(rightServe == false && Input.GetKeyDown(KeyCode.D)){
                if(sceneIsAI == false){
                rb.AddForce(new Vector2(200, 300));
                spielGestartet = true;
            }   
            }
        }
        if(spielGestartet == true){
        //Bewegung des Spielers(Spieler2)
        
        if(Input.GetKey(KeyCode.UpArrow)){
            Player2.transform.position = new Vector2(Player2.transform.position.x, Player2.transform.position.y + moveSpeed * Time.deltaTime);
            //Checken, dass der Spieler nicht aus der Map geht(oben)
            if(Player2.transform.position.y >= 3.23f){
                Player2.transform.position = new Vector2(Player2.transform.position.x, 3.23f);
            }
        }
        
        if(Input.GetKey(KeyCode.DownArrow)){
            Player2.transform.position = new Vector2(Player2.transform.position.x, Player2.transform.position.y - moveSpeed * Time.deltaTime);
            //Checken, dass der Spieler nicht aus der Map geht(unten)
            if(Player2.transform.position.y <= -3.23f){
                Player2.transform.position = new Vector2 (Player2.transform.position.x, -3.23f);
            }
        }
        
        //Bewegung des Spielers(Spieler1)
        if(sceneIsAI == false){
        if(Input.GetKey(KeyCode.W)){
            Player1.transform.position = new Vector2(Player1.transform.position.x, Player1.transform.position.y + moveSpeed * Time.deltaTime);
             //Checken, dass der Spieler nicht aus der Map geht(oben)
            if(Player1.transform.position.y >= 3.23f){
                Player1.transform.position = new Vector2(Player1.transform.position.x, 3.23f);
            }
        }
        if(Input.GetKey(KeyCode.S)){
            Player1.transform.position = new Vector2(Player1.transform.position.x, Player1.transform.position.y - moveSpeed * Time.deltaTime);
           //Checken, dass der Spieler nicht aus der Map geht(unten)
            if(Player1.transform.position.y <= -3.23f){
                Player1.transform.position = new Vector2 (Player1.transform.position.x, -3.23f);
            }
        }
        }
        }
        //Spieler 1 führt einen Schlag aus
        if(sceneIsAI == false){
        if(Input.GetKeyDown(KeyCode.D)){
            StartCoroutine("Player1Hit");
        }
        }
        //Spieler 2 führt einen Schlag aus
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            StartCoroutine("Player2Hit");
        }
        

        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();

        //Code für die KI
        if(sceneIsAI == true){
            if(rb.velocity.x < 0){
                float yNeu = Player1.transform.position.y + AImoveSpeed * Time.deltaTime;

                if(yNeu > 3.23f) yNeu = 3.23f;
                Vector3 oben = new Vector3 (Player1.transform.position.x, yNeu, 0);

                yNeu = Player1.transform.position.y - AImoveSpeed * Time.deltaTime;
                if(yNeu < -3.23f) yNeu = -3.23f;
                Vector3 unten = new Vector3 (Player1.transform.position.x, yNeu, 0);

                if((oben - transform.position). magnitude < (unten - transform.position).magnitude){
                    Player1.transform.position = oben;
                }
                else{
                    Player1.transform.position = unten;
                }
            }
        }



    }

    //Der Ball trifft auf die rote Zone eines Spielers
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "redZone"){
            player2Score++;
            if(player2Score == 10){
                EndGame2();
            }
            Invoke(nameof(LoadScene), 0.6f);
        }
        if(other.gameObject.tag == "redZone2"){
            player1Score++;
            if(player1Score == 10){
                EndGame1();
            }
            Invoke(nameof(LoadScene), 0.6f);
        }
    }

    //Die Szene wird neu geladen
    void LoadScene() {
        if(sceneIsAI == false){
        SceneManager.LoadScene("Level01");
    }
        if(sceneIsAI == true){
            SceneManager.LoadScene("Level01AI");
        }
    }

    //Der Ball trifft auf einen der Spieler
      void OnCollisionEnter2D(Collision2D other)
     {
         if(other.gameObject.tag == "Player"){
             rb.velocity *= 1.05f;
             hitPlayer.Play();
         }
         if(other.gameObject.tag == "Wall"){
             hitWall.Play();
         }
         if(other.gameObject.tag == "Obstacle"){
             hitObstacle.Play();
         }
     }

    void SetObstacles(){
        Obstacle1.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.0f, 4.0f), 0);

        do {
            Obstacle2.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.0f, 4.0f), 0);
        }
        while ((Obstacle1.transform.position - Obstacle2.transform.position).magnitude < 1.5f );

        do
        {
            Obstacle3.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.0f, 4.0f), 0);
        } 
        while ((Obstacle3.transform.position - Obstacle2.transform.position).magnitude < 1.5f || (Obstacle3.transform.position - Obstacle1.transform.position). magnitude < 1.5f);
        
    }

    IEnumerator Player1Hit(){
        Player1.transform.Translate(0,-0.3f,0);
        yield return new WaitForSeconds(0.2f);
        Player1.transform.Translate(0,0.3f,0);
    }

    IEnumerator Player2Hit(){
        Player2.transform.Translate(0,0.3f,0);
        yield return new WaitForSeconds(0.2f);
        Player2.transform.Translate(0,-0.3f,0);
    }

    public void Exit(){
        SceneManager.LoadScene("MainMenu");
    }
}
