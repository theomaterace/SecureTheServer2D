using UnityEngine;

public class ThreatInstance : MonoBehaviour
{
    public Threat threatData;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
       if (threatData != null)
        {
            spriteRenderer.sprite = threatData.icon;
            gameObject.name = threatData.threatName;

        }
        else
        {
            Debug.LogWarning("Brak przypisanego ScriptableObject Threat!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ServerHealth server = other.GetComponent<ServerHealth>();

        if (server != null)
        {
            server.TakeDamage(threatData.damageValue);
            Destroy(gameObject);
        }

        DefenseInstance defense = other.GetComponent<DefenseInstance>();

        if (defense != null && defense.data != null)
        {
            switch (defense.data.effect)
            {
                case DefenseMechanism.EffectType.DestroyThreat:
                    Debug.Log($"[OBRONA] {defense.name} zniszczy³a {name}.");
                    Destroy(gameObject);
                    break;

                case DefenseMechanism.EffectType.SlowThreat:
                    Debug.Log($"[OBRONA] {defense.name} spowolni³a {name}");
                    ThreatMover mover = GetComponent<ThreatMover>();

                    if (mover != null && threatData != null)
                    {
                        threatData.speed *= 0.5f;
                    }
                    break;

                case DefenseMechanism.EffectType.ShieldServer:
                    Debug.Log($"[OBRONA] {defense.name} - efekt tarczy, brak reakcji na zagro¿enie.");
                    break;

            }
        }
    }
}