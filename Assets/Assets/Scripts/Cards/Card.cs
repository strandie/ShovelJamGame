using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/New Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int damageAmount;
    public Sprite artwork;
}
