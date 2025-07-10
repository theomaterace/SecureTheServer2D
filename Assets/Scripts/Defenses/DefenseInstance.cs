using UnityEngine;

public class DefenseInstance : MonoBehaviour
{
    public DefenseMechanism data;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (data != null)
        {
            spriteRenderer.sprite = data.icon;
            gameObject.name = data.defenseName;
        }
        else
        {
            Debug.LogWarning("Brak przypisanego DefenseMechanism!");
        }
    }

}

