using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera = null;
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    //private bool cursorLocked = true;
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
    [SerializeField]
    private float gravity = 13.0f;
    [SerializeField]
    private float jumpSpeed = 0.0f;
    float velocityY = 0.0f;

    [SerializeField]
    private Transform gunObject;
    [SerializeField]
    private float gunRotateSensitivity;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        //#if UNITY_STANDALONE && !UNITY_EDITOR
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //#endif
    }
    private void Update()
    {
        MouseUpdate();
        Movement();
        RotateGun();
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
        if (playerController.isGrounded)
            velocityY = 0.0f;
        velocityY -= gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            velocityY = jumpSpeed;
        }
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * movementSpeed + Vector3.up * velocityY;
        playerController.Move(velocity * Time.deltaTime);
    }

    private void RotateGun()
    {
        float gunRotateAmount;
        gunRotateAmount = -currentMouseDelta.y * gunRotateSensitivity;
        gunObject.Rotate(gunRotateAmount * new Vector3(0, 0, 1));
    }

    //IDEALLY THIS SHOULD BE TRIGGERED FROM THE PIECE SCRIPT, BUT LIMITATION OF CHARACTER CONTROLLER
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "droppablePiece" && !hit.gameObject.GetComponent<Puzzle3Piece>().IsPartOfPath)
        {
            hit.gameObject.GetComponent<Puzzle3Piece>().DropPiece();
        }
    }
}
