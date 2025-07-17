using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicButtonUI : MonoBehaviour
{
    public Image iconImage;
    public Text nameText;
    public Text descriptionText;
    private Relic relic;
    private System.Action<Relic> onSelectCallback;

    public void Setup(Relic relic, System.Action<Relic> onSelect)
    {
        this.relic = relic;
        onSelectCallback = onSelect;

        iconImage.sprite = relic.icon;
        nameText.text = relic.relicName;
        descriptionText.text = relic.description;

        GetComponent<Button>().onClick.AddListener(() => onSelectCallback?.Invoke(relic));
    }
}
