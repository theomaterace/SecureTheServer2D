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
    }
}