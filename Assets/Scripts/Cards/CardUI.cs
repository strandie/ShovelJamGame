using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI cost;
    public Button playButton;
    public Image artworkImage;

    private Card cardData;
    private Enemy target;

    public void Initialize(Card card, Enemy enemy)
    {
        cardData = card;
        target = enemy;

        nameText.text = card.cardName;
        descriptionText.text = card.cardEffect;
        cost.text = card.cost;

        if (artworkImage != null && card.artwork != null)
            artworkImage.sprite = card.artwork;

        playButton.onClick.AddListener(OnPlay);
    }

    private void OnPlay()
    {
        Debug.Log($"Played card: {cardData.cardName} for {cardData.damageAmount} damage");

        if (target != null)
        {
            target.TakeDamage(cardData.damageAmount);
        }

        Destroy(gameObject);
    }
}
