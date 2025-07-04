using UnityEngine;

public class ThreatSpawner : MonoBehaviour
{
    [Header("Prefab zagro¿enia")]
    public GameObject threatPrefab;

    [Header("Punkt pocz¹tkowy spawnu")]
    public Transform spawnPoint;

    [Header("Czas miêdzy spawnami (sekundy)")]
    public float spawnInterval = 2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            SpawnThreat();
            timer = 0f;
        }
    }

    private void SpawnThreat()
    {
        if (threatPrefab != null && spawnPoint != null)
        {
            Instantiate(threatPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Spawner: Brakuje prefab'u lub punktu startowego!");
        }

    }





}