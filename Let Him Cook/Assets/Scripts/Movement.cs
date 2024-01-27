using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Movement : MonoBehaviour
{
    public float movementSpeed, mouseSensitivity;
    Transform cam;
    CharacterController characterController;
    float xRot,yRot;
    void Start()
    {
        cam = transform.GetChild(0);
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        DirectionalMovement();
        CameraRotation();
    }
    void DirectionalMovement()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");
        Vector3 right = transform.right;
        Vector3 forward = Vector3.Cross(right, Vector3.up);
        Vector3 movedir3d = hori * right +verti*forward;
        Vector3 movedir = new Vector3(movedir3d.x, 0,movedir3d.z).normalized;
        characterController.Move(movedir * movementSpeed * Time.deltaTime);
    }
    void CameraRotation()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;
        yRot += mouseDelta.x;
        xRot += mouseDelta.y;
        yRot %= 360;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0, yRot, 0);
        cam.localRotation = Quaternion.Euler(xRot, cam.rotation.y, cam.rotation.z);
    }
}
