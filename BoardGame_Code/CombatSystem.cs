using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public static int numOfFigures2 = 0;

    public enum BattleState
    {
        PLAYER1PLACE,
        PLAYER2PLACE,
        PLAYER1TURN,
        PLAYER2TURN,
        END
    }

    public static BattleState state;

    private void Start() {
        state = BattleState.PLAYER1PLACE;
        numOfFigures2 = 0;
    }

    private void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){

        if(state == BattleState.PLAYER1PLACE) {
            state = BattleState.PLAYER2PLACE;
            return;
        }
        if(state == BattleState.PLAYER2PLACE) {
            //numOfFigures2++;

            if(numOfFigures2 == 3)
            {state = BattleState.PLAYER1TURN;}
            if(numOfFigures2 != 3){
            state = BattleState.PLAYER1PLACE; 
                }
        } 
        
    }
}
}
