using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;

public class PanZoom : MonoBehaviour
{
    private Camera cam;

    private bool moveAllowed;
    private Vector3 touchPos;

    private Vector3 dragOrigin;
    private Vector3 dragOriginWorld;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        if (Input.touchCount == 2)
    //        {
    //            //zooming
    //        }
    //        else
    //        {
    //            Touch touch = Input.GetTouch(0);

    //            switch (touch.phase)
    //            {
    //                case TouchPhase.Began:
    //                    {
    //                        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    //                        {
    //                            moveAllowed = false;
    //                        }
    //                        else
    //                        {
    //                            moveAllowed = true;
    //                        }

    //                        touchPos = cam.ScreenToWorldPoint(touch.position);
    //                        break;
    //                    }
    //                case TouchPhase.Moved:
    //                    {
    //                        if (moveAllowed)
    //                        {
    //                            Vector3 direction = touchPos - cam.ScreenToWorldPoint(touch.position);
    //                            cam.transform.position += direction;
    //                        }
    //                        break;
    //                    }
    //            }
    //        }
    //    }
    //}

    private void Update()
    {
        // Mouse down
        if (Input.GetMouseButtonDown(0))
        {
            // nếu đang bấm UI thì không drag
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                moveAllowed = false;
            }
            else
            {
                moveAllowed = true;
                float zDistance = Mathf.Abs(cam.transform.position.z); // khoảng cách camera -> plane z=0
                dragOriginWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            }
        }

        // Mouse drag
        if (Input.GetMouseButton(0) && moveAllowed)
        {
            float zDistance = Mathf.Abs(cam.transform.position.z);
            Vector3 currentWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            Vector3 diff = dragOriginWorld - currentWorld;

            // chỉ di chuyển X,Y, giữ nguyên Z của camera
            cam.transform.position += new Vector3(diff.x, diff.y, 0f);
        }

        // Scroll zoom
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (Mathf.Abs(scroll) > 0.0001f)
        //{
        //    cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
        //}
    }
}
