using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private new Camera camera;
    [SerializeField]
    private float maxCameraView;
    [SerializeField]
    private float minCameraView;
    [SerializeField]
    private int xCameraMaxLimit;
    [SerializeField]
    private int xCameraMinLimit;
    [SerializeField]
    private int yCameraMaxLimit;
    [SerializeField]
    private int yCameraMinLimit;
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float moveXSpeed;
    [SerializeField]
    private float moveYSpeed;
    [SerializeField]
    private int xEdge;
    [SerializeField]
    private int yEdge;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            Zoom();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Zoom()
    {
        float newView = camera.fieldOfView - Input.mouseScrollDelta.y * scrollSpeed;
        camera.fieldOfView = Mathf.Clamp(newView, minCameraView, maxCameraView);
    }

    private void Move()
    {
        if (Input.mousePosition.x < xEdge)
        {
            if (transform.position.x == xCameraMinLimit)
                return;

            float newX = transform.position.x - moveXSpeed * Time.fixedDeltaTime;
            newX = Mathf.Max(newX, xCameraMinLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            return;
        }
        else if (Input.mousePosition.x > Screen.width - xEdge)
        {
            if (transform.position.x == xCameraMaxLimit)
                return;

            float newX = transform.position.x + moveXSpeed * Time.fixedDeltaTime;
            newX = Mathf.Min(newX, xCameraMaxLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            return;
        }
        else if (Input.mousePosition.y < yEdge)
        {
            if (transform.position.y == yCameraMinLimit)
                return;

            float deltaY = -moveYSpeed * Time.fixedDeltaTime;
            deltaY = Mathf.Max(deltaY, yCameraMinLimit - transform.position.y);
            transform.position += new Vector3(0, deltaY, deltaY);
            return;
        }
        else if(Input.mousePosition.y > Screen.height - yEdge)
        {
            if (transform.position.y == yCameraMaxLimit)
                return;

            float deltaY = moveYSpeed * Time.fixedDeltaTime;
            deltaY = Mathf.Min(deltaY, yCameraMaxLimit - transform.position.y);
            transform.position += new Vector3(0, deltaY, deltaY);
            return;
        }
    }
}
