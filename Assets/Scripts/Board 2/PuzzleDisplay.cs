using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuzzleDisplay : MonoBehaviour
{

    [SerializeField]
    private Material _material;
    [SerializeField]
    private List<GameObject> _displayPieces = new List<GameObject>();
    private Piece _pieceToChange;
    private int _xCount = 1;
    private int _yCount = 1;
    private int _boardLength = 5;


    private void Awake()
    {
        InitiatePieces();
    }

    // Start is called before the first frame update
    void Start()
    {

        GetCenterAndSurroundingPiecesAndChangeColor();
        GetCenterAndSurroundingPiecesAndChangeColor();
        GetCenterAndSurroundingPiecesAndChangeColor();
        BoardBehaviour.listOfPuzzlePieces = _displayPieces;

    }

    private void InitiatePieces()
    {
        foreach (BoardPuzzleBehaviour childObject in GetComponentsInChildren<BoardPuzzleBehaviour>())
        {
            if (!childObject.GetComponent<BoardPuzzleBehaviour>()._isTarget)
            {
                childObject.xCoordinate = _xCount;
                childObject.yCoordinate = _yCount;
                _xCount++;
                if (_xCount > _boardLength)
                {
                    _yCount++;
                    _xCount = 1;
                }
                _displayPieces.Add(childObject.gameObject);
            }
        }
    }

    private Piece GetRandomIndexes()
    {
        Piece randomPiece = new Piece(Random.Range(2, BoardBehaviour.GetBoardLength() - 1), Random.Range(2, BoardBehaviour.GetBoardWidth() - 1));
        return randomPiece;
    }

    private Piece[] ReturnSurroundingPieceIndexes(Piece pieceToGetSurroundingPiecesFor)
    {
        Piece[] surroundingPieces = new Piece[4];
        for(int i = 0; i < 4; i++)
        {
            surroundingPieces[i] = new Piece();
        }
        if (pieceToGetSurroundingPiecesFor == null)
        {
            print("cant find neighbouring piece for a null piece");
            return surroundingPieces;
        }
        surroundingPieces[0].XCoordinate = pieceToGetSurroundingPiecesFor.GetXCoordinate() - 1;
        surroundingPieces[0].YCoordinate = pieceToGetSurroundingPiecesFor.GetYCoordinate();
        surroundingPieces[1].SetXCoordinate(pieceToGetSurroundingPiecesFor.GetXCoordinate() + 1);
        surroundingPieces[1].SetYCoordinate(pieceToGetSurroundingPiecesFor.GetYCoordinate());


        surroundingPieces[2].SetXCoordinate(pieceToGetSurroundingPiecesFor.GetXCoordinate());
        surroundingPieces[2].SetYCoordinate(pieceToGetSurroundingPiecesFor.GetYCoordinate() - 1);

        surroundingPieces[3].SetXCoordinate(pieceToGetSurroundingPiecesFor.GetXCoordinate());
        surroundingPieces[3].SetYCoordinate(pieceToGetSurroundingPiecesFor.GetYCoordinate() + 1);
        
        return surroundingPieces;
    }
    //Function too big, needs to be broken down
    private void GetCenterAndSurroundingPiecesAndChangeColor()
    {
        Piece randomPiece = GetRandomIndexes();
        Piece[] piecesSurroundingRandomPiece = ReturnSurroundingPieceIndexes(randomPiece);
        foreach (GameObject piece in _displayPieces)
        {
            if (piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
                randomPiece.GetXCoordinate() &&
                piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
                randomPiece.GetYCoordinate())
            {
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
                piece.GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = true;
            }

            if (piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
                piecesSurroundingRandomPiece[0].GetXCoordinate() &&
                piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
                piecesSurroundingRandomPiece[0].GetYCoordinate())
            {
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
                piece.GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = true;

            }

            if (piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
               piecesSurroundingRandomPiece[1].GetXCoordinate() &&
               piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
               piecesSurroundingRandomPiece[1].GetYCoordinate())
            {
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
                piece.GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = true;

            }

            if (piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
               piecesSurroundingRandomPiece[2].GetXCoordinate() &&
               piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
               piecesSurroundingRandomPiece[2].GetYCoordinate())
            {
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
                piece.GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = true;

            }

            if (piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
               piecesSurroundingRandomPiece[3].GetXCoordinate() &&
               piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
               piecesSurroundingRandomPiece[3].GetYCoordinate())
            {
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
                piece.GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = true;

            }
        }
    }
}
