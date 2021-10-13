using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera = null;
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private bool cursorLocked = true;
    private float cameraPitch;
    [SerializeField]
    private float mouseSmoothTime = 0.03f;
    private Vector2 currentMouseDelta = Vector2.zero;
    private Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private CharacterController playerController;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float smoothTime = 0.3f;
    private Vector2 currentDir = Vector2.zero;
    private Vector2 currentDirVelocity = Vector2.zero;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        MouseUpdate();
        Movement();
    }

    private void MouseUpdate()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraPitch -= currentMouseDelta.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(currentMouseDelta.x * mouseSensitivity * Vector3.up);
    }

    private void Movement()
    {
        Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDirection.Normalize();
        currentDir = Vector2.SmoothDamp(currentDir, targetDirection, ref currentDirVelocity, smoothTime);
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed;
        playerController.Move(velocity * Time.deltaTime);
    }
}
