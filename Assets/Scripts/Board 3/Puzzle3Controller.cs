using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Controller : MonoBehaviour
{
    private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
    public static List<Puzzle3Piece> listOfPuzzlePieces = new List<Puzzle3Piece>();
    
    void Start()
    {
        InitPieceList();
        SetColorOfPiece();
        SetPuzzlePath();
    }
    void Update()
    {
        
    }

    private void InitPieceList()
    {
        int pieceIndex = 0;
        foreach (Puzzle3Piece puzzlePiece in GetComponentsInChildren<Puzzle3Piece>())
        {
            puzzlePiece.IndexOfPiece = ++pieceIndex;
            listOfPuzzlePieces.Add(puzzlePiece);
            //print(puzzlePiece.IndexOfPiece + " ");
        }
    }

    private void SetColorOfPiece()
    {
        foreach(Puzzle3Piece piece in listOfPuzzlePieces)
        {
            Color randomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
            
            piece.gameObject.GetComponent<MeshRenderer>().material.color = randomColor;
        }
    }

    private int[] ReturnRandomIndexes()
    {
        int[] indexes = new int[5];
        indexes[0] = Random.Range(1, 4);
        indexes[1] = Random.Range(5, 8);
        indexes[2] = Random.Range(9, 12);
        indexes[3] = Random.Range(13, 16);
        indexes[4] = Random.Range(17, 20);

        return indexes;
    }

    private void SetPuzzlePath()
    {
        int[] indexes = new int[5];
        indexes = ReturnRandomIndexes();
        int j = 0;
        foreach (Puzzle3Piece puzzlePiece in GetComponentsInChildren<Puzzle3Piece>())
        {
            if (j < 5 && puzzlePiece.IndexOfPiece == indexes[j])
            {
                puzzlePiece.IsPartOfPath = true;
                //print(j + " ");
                j += 1;

            }
        }
    }


}
