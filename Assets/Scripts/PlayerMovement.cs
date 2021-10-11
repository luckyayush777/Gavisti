using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _movementSpeed;
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
            Debug.Log(xMouseValue);
            Debug.Log(" " + yMouseValue);
            //if(transform.rotation.)
            transform.Rotate(new Vector3(0.0f, xMouseValue, yMouseValue));
        }

    }
}
