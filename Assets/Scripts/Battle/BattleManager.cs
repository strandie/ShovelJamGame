using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    public Enemy enemy;                        
    public Transform handZone;                 
    public GameObject cardUIPrefab;            
    public List<Card> startingCards;   

    public List<Card> allAvailableCards;  // Master card list    
    public GameObject cardSelectionPanel; // Reference to the selection UI panel       
    public Transform selectionCardParent; // Where to instantiate the card options 

    private void Start()
    {
        SpawnStartingCards();
    }

    private void SpawnStartingCards()
    {
        foreach (Card card in startingCards)
        {
            GameObject cardGO = Instantiate(cardUIPrefab, handZone);
            CardUI cardUI = cardGO.GetComponent<CardUI>();
            cardUI.Initialize(card, enemy);
        }
    }

    public void OnEnemyDefeated()
    {
        Debug.Log("Enemy defeated! The game will now progress to the next stage.");
        ShowCardSelectionUI();

    }

    public void ShowCardSelectionUI()
    {

        // hide and show ui
        cardSelectionPanel.SetActive(true);
        handZone.gameObject.SetActive(false);

        // Remove any previous cards
        foreach (Transform child in selectionCardParent)
        {
            Destroy(child.gameObject);
        }

        // Pick 3 random cards (you can add uniqueness check if needed)
        List<Card> choices = new List<Card>();
        while (choices.Count < 3)
        {
            Card randomCard = allAvailableCards[Random.Range(0, allAvailableCards.Count)];
            if (!choices.Contains(randomCard)) // ensure uniqueness
                choices.Add(randomCard);
        }

        foreach (Card card in choices)
        {
            GameObject cardGO = Instantiate(cardUIPrefab, selectionCardParent);
            CardUI cardUI = cardGO.GetComponent<CardUI>();

            // Pass the callback that handles reward selection
            cardUI.Initialize(card, null, OnCardSelected);
        }

    }

    private void OnCardSelected(Card selectedCard)
    {
        Debug.Log($"Player selected: {selectedCard.cardName}");

        startingCards.Add(selectedCard);
        cardSelectionPanel.SetActive(false);

        enemy.Respawn();

        // ✅ Clear existing hand
        foreach (Transform child in handZone)
        {
            Destroy(child.gameObject);
        }

        // ✅ Show hand again
        handZone.gameObject.SetActive(true);

        // ✅ Spawn new hand
        SpawnStartingCards();
    }

}
