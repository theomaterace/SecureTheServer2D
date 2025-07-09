using UnityEngine;

[CreateAssetMenu(fileName = "DefenseMechanism", menuName = "Defenses/DefenseMechanism")]
public class DefenseMechanism : ScriptableObject
{
    [Header("Podstawowe informacje")]
    public string defenseName;
    public Sprite icon;
    public string description;

    [Header("Statystyki dzia³ania")]
    public float activationTime; // czas aktywacji w sekundach
    public float range; // zasiêg dzia³ania (jednostki siatki)
    public int cost; // koszt wystawienia

    [Header("Efekt dzia³ania")]
    public EffectType effect;

    public enum EffectType
    {
        DestroyThreat,
        SlowThreat,
        ShieldServer
    }
}
