using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{
    public static RelicManager Instance { get; private set; }

    public List<Relic> collectedRelics = new List<Relic>();

    public bool health = false;
    public bool draw = false;
    public bool damage = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // for staying across across scenes idk if we need this
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// call this when the player selects a relic.
    public void AddRelic(Relic relic)
    {
        if (collectedRelics.Contains(relic))
            return;

        collectedRelics.Add(relic);
        ApplyRelicEffect(relic);
    }

    private void ApplyRelicEffect(Relic relic)
    {
        switch (relic.effectType)
        {
            case RelicEffectType.Health:
                health = true;
                Debug.Log("HP system enabled!");
                break;

            case RelicEffectType.Damage:
                damage = true;
                Debug.Log("Damage idk.");
                break;

            case RelicEffectType.Draw:
                draw = true;
                Debug.Log("You can draw cards now");
                break;

            default:
                Debug.LogWarning("This shouldn't happen: " + relic.effectType);
                break;
        }
    }
}
