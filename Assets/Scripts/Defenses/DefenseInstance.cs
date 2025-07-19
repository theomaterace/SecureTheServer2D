using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


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

#if UNITY_EDITOR

    [SerializeField]
    private bool showDebugRange = true;

    private void OnDrawGizmosSelected()
    {
        if (!showDebugRange || data == null) return;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, data.range);

        GUIStyle style = new GUIStyle
        {
            normal = { textColor = Color.white },
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };
        

        Vector3 labelPos = transform.position + Vector3.up * 0.5f;
        Handles.Label(labelPos, $"Zasiêg: {data.range}", style);

    }

#endif

}

