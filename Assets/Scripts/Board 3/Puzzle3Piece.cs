using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Puzzle3Piece : MonoBehaviour
{
    private int _indexOfPiece;
    public int IndexOfPiece
    {
        get
        {
            return _indexOfPiece;
        }

        set
        {
            _indexOfPiece = value;
        }
    }

    public bool IsPartOfPath = false;
    [SerializeField]
    private float fallingSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            print("Hit Player");
        }
    }
    public void DropPiece()
    {
        transform.Translate(fallingSpeed * new Vector3(0, -1, 0) * Time.deltaTime);
    }
}
