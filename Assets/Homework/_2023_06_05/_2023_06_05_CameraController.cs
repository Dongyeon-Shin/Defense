using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _2023_06_05_CameraController : MonoBehaviour
{
    private Vector2 moveDirection;
    private float zoomScroll;
    [SerializeField]
    private float cameraMoveSpeed;
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float padding;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void LateUpdate()
    {
        Zoom(zoomScroll);
        CameraMove();
    }
    private void CameraMove()
    {
        transform.Translate(Vector3.forward * moveDirection.y * cameraMoveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDirection.x * cameraMoveSpeed * Time.deltaTime, Space.World);
    }
    private void OnPointer(InputValue value)
    {
        Vector2 mousePosition = value.Get<Vector2>();
        if (mousePosition.x <= padding)
        {
            moveDirection.x = -1;
        }
        else if (mousePosition.x >= Screen.width - padding)
        {
            moveDirection.x = 1;
        }
        else
        {
            moveDirection.x = 0;
        }
        if (mousePosition.y <= padding)
        {
            moveDirection.y = -1;
        }
        else if (mousePosition.y >= Screen.height - padding)
        {
            moveDirection.y = 1;
        }
        else
        {
            moveDirection.y = 0;
        }
    }
    public void Zoom(float scroll)
    {
        transform.Translate(Vector3.forward * scroll * zoomSpeed * Time.deltaTime, Space.Self);
    }
    private void OnZoom(InputValue value)
    {
        zoomScroll = value.Get<Vector2>().y;
    }
}
