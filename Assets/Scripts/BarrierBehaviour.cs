using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private Vector3 _moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        TargetHitScript.OnColorMatch += MoveBarrierOnColorMatch;
    }

    private void OnDisable()
    {
        TargetHitScript.OnColorMatch -= MoveBarrierOnColorMatch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveBarrierOnColorMatch()
    {
        transform.Translate(_moveSpeed * _moveDirection * Time.deltaTime);
    }
}
