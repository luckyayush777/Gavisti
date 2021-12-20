using UnityEngine;

public class Board4Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _rayObject;
    private Transform _rayTransform;
    [SerializeField]
    private float _attackOffsetSpeed;
    [SerializeField]
    private float _maxLength;
    [SerializeField]
    private float _attackSpeed;
    private Vector3 _initialPosition;
    private Vector3 _initialScale;
    private GameObject _player;
    [SerializeField]
    private float _movementSpeed;

    void Start()
    {
        _rayTransform = _rayObject.GetComponent<Transform>();
        _initialPosition = _rayTransform.position;
        _initialScale = _rayTransform.localScale;
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
            print("Couldn't find player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        if(Input.GetKey(KeyCode.E))
        {
            ShootRay();
        }   
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetRay();
        }
    }

    private void ShootRay()
    {
        if (_rayTransform.localScale.z <= _maxLength)
        {
            _rayTransform.localScale += new Vector3(0, 0, _attackSpeed);
            _rayTransform.position += new Vector3(0, 0, -0.5f * _attackOffsetSpeed);
        }
    }

    private void ResetRay()
    {
        _rayTransform.position = _initialPosition;
        _rayTransform.localScale = _initialScale;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 dirToMove = _player.transform.position - transform.position;
        


        transform.Translate(new Vector3(dirToMove.x, dirToMove.y, 0) * _movementSpeed * Time.deltaTime);
    }
}

