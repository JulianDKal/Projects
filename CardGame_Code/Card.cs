using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public int health;
    public int range;

    public Sprite cardImage;

    
}
