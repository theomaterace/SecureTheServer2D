using UnityEngine;

public class ServerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"[SERVER] Otrzymano obra¿enia: {amount} | Pozosta³e HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.LogWarning("[SERVER] Serwer zosta³ zniszczony!");
            // Mo¿na tu dodaæ Game Over, animacje itd.
        }
    }

}
