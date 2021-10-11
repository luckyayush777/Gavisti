using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float sensitivity;
    private Camera _mainCamera;
    [SerializeField]
    private GameObject _gunObject;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * _movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.back * _movementSpeed * Time.deltaTime);
        }
        float xMouseValue = Input.GetAxis("Mouse X");
        float yMouseValue = Input.GetAxis("Mouse Y");
        if (xMouseValue != 0 || yMouseValue != 0)
        {
            //Debug.Log(xMouseValue);
            //Debug.Log(" " + yMouseValue);
            //if(transform.rotation.)
            //transform.Rotate(new Vector3(0.0f, xMouseValue * sensitivity * Time.deltaTime, yMouseValue * sensitivity * Time.deltaTime));
            _mainCamera.transform.Rotate(new Vector3(0.0f, xMouseValue * sensitivity * Time.deltaTime, yMouseValue * sensitivity * Time.deltaTime));
            _gunObject.transform.Rotate(new Vector3(0.0f, xMouseValue * sensitivity * Time.deltaTime, yMouseValue * sensitivity * Time.deltaTime));
        }

    }
}
