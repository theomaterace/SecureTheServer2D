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
        Debug.Log($"[SERVER] Otrzymano obra�enia: {amount} | Pozosta�e HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.LogWarning("[SERVER] Serwer zosta� zniszczony!");
            // Mo�na tu doda� Game Over, animacje itd.
        }
    }

}
