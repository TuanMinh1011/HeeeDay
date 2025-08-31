using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 startPos;
    private float deltaX, deltaY;

    private void Start()
    {
        //startPos = Input.mousePosition;
        //startPos.z = 10;
        //startPos = Camera.main.ScreenToWorldPoint(startPos);

        //deltaX = startPos.x - transform.position.x;
        //deltaY = startPos.y - transform.position.y;
    }

    private void Update()
    {
        Vector3 d = Input.mousePosition;
        d.z = 10;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(d);
        Vector3 pos = new Vector3(mousePos.x, mousePos.y);

        Vector3Int cellPos = BuildingSystem.Current.GridLayout.WorldToCell(pos);
        transform.position = BuildingSystem.Current.GridLayout.CellToLocalInterpolated(cellPos);
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponent<PlaceableObject>().CheckPlacement();
            Destroy(this);
        }
    }
}
