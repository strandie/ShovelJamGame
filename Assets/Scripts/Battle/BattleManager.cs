using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    public Enemy enemy;                        
    public Transform handZone;                 
    public GameObject cardUIPrefab;            
    public Card[] startingCards;               

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
    }
}
