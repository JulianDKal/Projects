using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text healthText;
    public TMP_Text descriptionText;

    public Image cardImage;

    private void Awake() {
        DisplayCards();
        GetComponent<DragDropScript>().enabled = false;
    }

    public void DisplayCards()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;

        costText.text = card.cost.ToString();
        powerText.text = card.power.ToString();
        healthText.text = card.health.ToString();

        cardImage.sprite = card.cardImage;

        
    }


}
