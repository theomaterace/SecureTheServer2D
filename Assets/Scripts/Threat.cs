using UnityEngine;


[CreateAssetMenu(fileName = "NewThreat", menuName = "Threats/Threat")]

public class Threat : ScriptableObject
{

    [Header("Podstawowe informacje")]

    public string threatName;
    public Sprite icon;
    public int damageValue;

    [Header("Parametry dodatkowe")]

    public float speed;

    public AttackType attackType;

    public enum AttackType
    {
        Standard,
        DDOS,
        Boss
    }
}
