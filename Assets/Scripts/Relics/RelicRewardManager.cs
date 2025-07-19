using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RelicRewardManager : MonoBehaviour
{
    public GameObject relicButtonPrefab; 
    public Transform rewardPanel; 
    public List<Relic> allRelics; 

    private System.Action onRelicSelectedCallback;

    public void ShowRelicRewards(int stage)
    {
        List<Relic> relicOptions = new List<Relic>();

        RelicEffectType effectTypeToShow = RelicEffectType.None;

        if (stage == 1)
            effectTypeToShow = RelicEffectType.Health;
        else if (stage == 2)
            effectTypeToShow = RelicEffectType.Damage;
        else if (stage == 3)
            effectTypeToShow = RelicEffectType.Draw;
        else
            effectTypeToShow = RelicEffectType.None; 

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

        // Hide rewards UI
        foreach (Transform child in rewardPanel)
        {
            Destroy(child.gameObject);
        }

        // Progress game (could call next enemy spawn here if needed)
    }
}
