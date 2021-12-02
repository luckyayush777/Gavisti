using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Barrier : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private Vector3 _moveDirection;

    private void OnEnable()
    {
        BoardBehaviour.OnPatternMatch += MoveOnMatch;
    }

    private void OnDisable()
    {
        BoardBehaviour.OnPatternMatch -= MoveOnMatch;

    }

    private void MoveOnMatch()
    {
        //print("moving");
        transform.Translate(_moveSpeed * _moveDirection * Time.deltaTime);
    }
}
