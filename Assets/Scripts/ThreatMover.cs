using UnityEngine;

[RequireComponent(typeof(ThreatInstance))]

public class ThreatMover : MonoBehaviour
{
    private Threat threatData;
    private Vector3 moveDirection = Vector3.left;

    private void Start()
    {
        threatData = GetComponent<ThreatInstance>().threatData;

        if (threatData == null)
        {
            Debug.LogWarning("Brak danych zagro¿enia (Threat)!");
            enabled = false;
        }
    }

    private void Update()
    {
      transform.Translate(moveDirection * threatData.speed * Time.deltaTime);  
    }
}