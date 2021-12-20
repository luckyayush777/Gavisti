using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board4Barrier : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private Transform _movementPointStart;
    [SerializeField]
    private Transform _movementPointEnd;

    private void Start()
    {
        _movementPointStart.position = transform.position;
        //print(_movementPointStart.position);
        //print(_movementPointEnd.position);
    }


    private void Update()
    {
        float time = Mathf.PingPong(Time.time * _movementSpeed, 1);
        transform.position = Vector3.Lerp(_movementPointStart.position, _movementPointEnd.position, time);
        //print(transform.position);
    }
}
