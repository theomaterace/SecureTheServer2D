using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Waves/Wave Config")]

public class WaveConfig : ScriptableObject
{
    [Header("Opis fali")]
    public string waveName = "Nowa fala";

    [Header("Zagro¿enia w tej fali")]
    public List<GameObject> threats;

    [Header("Czas opóŸnieñ miêdzy spawnami (sekundy)")]
    public List<float> spawnDelays;
}


