using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState{ START, PLAYERMOVE, ENEMYMOVE, PLAYERATTACK, ENEMYATTACK }

public class CardManager : MonoBehaviour
{   
    //Deck
    public List<GameObject> Deck = new List<GameObject>();

    public GameObject Hand;
    public GameObject EnemyHand;

    public GameObject Dragon;
    public GameObject Warrior;
    public GameObject Elf;

    public BattleState state = BattleState.START;

    private void Start() {
        Transform handTransform = Hand.GetComponent<RectTransform>();
        Transform enemyHandTr = EnemyHand.GetComponent<RectTransform>();

        for (int i = 0; i < 5; i++)
        {
            Deck.Add(Warrior);
            Deck.Add(Dragon);
            Deck.Add(Elf);
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject newCard = Instantiate(Deck[Random.Range(0, 15)], Vector3.zero, Quaternion.identity);
            newCard.transform.SetParent(handTransform, false);

            GameObject newEnemyCard = Instantiate(Deck[Random.Range(0, 15)], Vector3.zero, Quaternion.identity);
            newEnemyCard.transform.Rotate(0, 0, 180);
            newEnemyCard.transform.SetParent(enemyHandTr, false);
        }

        state = BattleState.PLAYERMOVE;
        Debug.Log(state);

    }

}
