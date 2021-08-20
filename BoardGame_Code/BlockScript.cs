using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : CombatSystem
{   [SerializeField]
    private GameObject Player1;
    [SerializeField]
    private GameObject Player2;

private void OnMouseDown() {

    if(state == BattleState.PLAYER1PLACE){
        Instantiate1();
    }
    if(state == BattleState.PLAYER2PLACE){
        Instantiate2();
    }
}

void Instantiate1(){
        Vector3 InstantiatePos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        Instantiate(Player1, InstantiatePos, Quaternion.identity);

}

void Instantiate2(){
    Vector3 InstantiatePos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        Instantiate(Player2, InstantiatePos, Quaternion.identity);
        numOfFigures2++;

}

private void Update(){
    //nothing
}

}
