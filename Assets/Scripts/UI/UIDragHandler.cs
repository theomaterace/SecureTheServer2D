using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Canvas canvas; // referencja do g³ównego canvasa
    public GameObject defensePrefab; // Prefab mechanizmu do rozmieszczenia
    public Camera mainCamera; // Potrzebna do konwersji pozycji

    private RectTransform dragRectTransform;
    private CanvasGroup canvasGroup;
    private GameObject draggedObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject = Instantiate(gameObject, transform.parent);
        draggedObject.name = gameObject.name + "_Drag";
        canvasGroup = draggedObject.GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }

        dragRectTransform = draggedObject.GetComponent<RectTransform>();
        UpdateDragPosition(eventData);
    }

    private void UpdateDragPosition(PointerEventData eventData)
    {
        if (dragRectTransform != null)
        {
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out globalMousePos))
            {
                dragRectTransform.position = globalMousePos;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateDragPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedObject != null)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(eventData.position);
            worldPos.z = 0f;

            if (defensePrefab != null)
            {
                GameObject instance = Instantiate(defensePrefab, worldPos, Quaternion.identity);
                Debug.Log($"[PLACEMENT] Rozstawiono: {instance.name} w {worldPos}");

            }
            Destroy(draggedObject);
        }
    }
}



