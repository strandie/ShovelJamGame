using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RelicRewardManager : MonoBehaviour
{
    public GameObject relicButtonPrefab; 
    public Transform rewardPanel; 

    public List<Relic> allRelics; 

    private System.Action onRelicSelectedCallback;

    public Transform collectedRelicsPanel;  
    public GameObject collectedRelicIconPrefab;  


    public void ShowRelicRewards(int stage)
    {
        rewardPanel.gameObject.SetActive(true);

        List<Relic> relicOptions = new List<Relic>();

        RelicEffectType effectTypeToShow = RelicEffectType.None;

        if (stage == 1)
            effectTypeToShow = RelicEffectType.Health;
        else if (stage == 2)
            effectTypeToShow = RelicEffectType.Damage;
        else if (stage == 3)
            effectTypeToShow = RelicEffectType.Draw;
        else
            effectTypeToShow = RelicEffectType.None; // any new types or random

        if (effectTypeToShow != RelicEffectType.None)
        {
            relicOptions = allRelics
                .Where(r => r.effectType == effectTypeToShow)
                .OrderBy(r => Random.value)
                .Take(3)
                .ToList();
        }
        else
        {
            relicOptions = allRelics
                .Where(r => r.effectType == RelicEffectType.None) 
                .OrderBy(r => Random.value)
                .Take(3)
                .ToList();
        }

        DisplayRelicOptions(relicOptions);
    }

    private void DisplayRelicOptions(List<Relic> relics)
    {
        // Clear previous options
        foreach (Transform child in rewardPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Relic relic in relics)
        {
            GameObject relicButton = Instantiate(relicButtonPrefab, rewardPanel);
            RelicButtonUI buttonUI = relicButton.GetComponent<RelicButtonUI>();
            buttonUI.Setup(relic, OnRelicSelected);
        }
    }

    private void OnRelicSelected(Relic selectedRelic)
    {
        RelicManager.Instance.AddRelic(selectedRelic);
        Debug.Log($"Selected Relic: {selectedRelic.relicName}");

        /* Hide rewards UI
        foreach (Transform child in rewardPanel)
        {
            Destroy(child.gameObject);
        }*/

        // Add to collected relics display
        GameObject relicIcon = Instantiate(collectedRelicIconPrefab, collectedRelicsPanel);
        Image iconImage = relicIcon.GetComponent<Image>();
        iconImage.sprite = selectedRelic.icon;

        // Hide rewards UI
        rewardPanel.gameObject.SetActive(false);
    
        // Progress game (could call next enemy spawn here if needed)
    }
}
