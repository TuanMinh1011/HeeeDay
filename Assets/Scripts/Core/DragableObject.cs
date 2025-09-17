using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private bool isDragging;

    [SerializeField] private GameObject building;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        // Nếu kéo mà không vào trigger thì reset về
        transform.position = startPos;
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDragging) return;

        transform.position = startPos;
        isDragging = false;

        BuildingSystem.Current.InitializeWithObject(building, Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, transform.position.y)));
    }
}
