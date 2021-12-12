using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Display : MonoBehaviour
{
    // Start is called before the first frame update
    public static Color[] colors = new Color[5];
    List<Puzzle3DisplayPiece> _puzzle3DisplayPieces = new List<Puzzle3DisplayPiece>();
    void Start()
    {
        foreach(Puzzle3DisplayPiece puzzle3DisplayPiece in GetComponentsInChildren<Puzzle3DisplayPiece>())
        {
            _puzzle3DisplayPieces.Add(puzzle3DisplayPiece);
        }
        StartCoroutine("InitDisplay");
       
    }

    IEnumerator InitDisplay()
    {
        yield return new WaitForSeconds(0.25f);
        int i = 0;
        foreach (Puzzle3Piece puzzle3Piece in Puzzle3Controller.listOfPuzzlePieces)
        {
            
            if (puzzle3Piece.IsPartOfPath)
            {
                //  print("changing color" + i);
                _puzzle3DisplayPieces[i++].gameObject.GetComponent<MeshRenderer>().material.color
                    = puzzle3Piece.gameObject.GetComponent<MeshRenderer>().material.color;
            }
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
