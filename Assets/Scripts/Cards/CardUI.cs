using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI cost;
    public Button playButton;
    public Image artworkImage;

    private Card cardData;
    private Enemy target;
    private Action<Card> onCardSelected;

    public void Initialize(Card card, Enemy enemy, Action<Card> selectionCallback = null)
    {
        cardData = card;
        target = enemy;
        onCardSelected = selectionCallback;

        nameText.text = card.cardName;
        descriptionText.text = card.cardEffect;
        cost.text = card.cost;

        if (artworkImage != null && card.artwork != null)
            artworkImage.sprite = card.artwork;

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(OnPlay);
    }

    private void OnPlay()
    {
        Debug.Log($"Played card: {cardData.cardName} for {cardData.damageAmount} damage");

        if (target != null)
        {
            target.TakeDamage(cardData.damageAmount);
        } else
        {
            onCardSelected?.Invoke(cardData);
        }

        Destroy(gameObject);
    }
}
