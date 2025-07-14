using UnityEngine;

[CreateAssetMenu(fileName = "NewRelic", menuName = "Relics/New Relic")]
public class Relic : ScriptableObject
{
    public string relicName;
    [TextArea] public string description;
    public Sprite icon;

    public RelicEffectType effectType;
}
