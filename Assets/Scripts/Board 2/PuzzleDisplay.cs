using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuzzleDisplay : MonoBehaviour
{

    [SerializeField]
    private Material _material;
    [SerializeField]
    readonly List<GameObject> displayPieces = new List<GameObject>();
    Piece _pieceToChange;
    private int _xCount = 1;
    private int _yCount = 1;
    private int _boardLength = 5;
    private int _boardWidth = 5;
    private void Awake()
    {
        InitiatePieces();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Piece randomPiece = GetRandomIndexes();
        //Debug.Log(randomPiece.GetXCoordinate() + " " + randomPiece.GetYCoordinate());
        foreach(GameObject piece in displayPieces)
        {
            //print(piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate +
            //    " " + piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate);
            if(piece.GetComponent<BoardPuzzleBehaviour>().xCoordinate ==
                randomPiece.GetXCoordinate() &&
                piece.GetComponent<BoardPuzzleBehaviour>().yCoordinate == 
                randomPiece.GetYCoordinate())
            {
                //print("found tile");
                piece.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
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
                displayPieces.Add(childObject.gameObject);
            }
        }
    }

    private Piece GetRandomIndexes()
    {
        Piece randomPiece = new Piece(Random.Range(2, BoardBehaviour.GetBoardLength() - 1), Random.Range(2, BoardBehaviour.GetBoardWidth() - 1));
        return randomPiece;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   


    public Mesh GenerateQuad()
    {
        Mesh newMesh = new Mesh();
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];
        vertices[0] = new Vector3(0, 1);
        vertices[1] = new Vector3(1, 1);
        vertices[2] = new Vector3(1, 0);
        vertices[3] = new Vector3(0, 0);
        uv[0] = new Vector2(0, 1);
        uv[1] = new Vector2(1, 1);
        uv[2] = new Vector2(1, 0);
        uv[3] = new Vector2(0, 0);
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 3;
        triangles[3] = 3;
        triangles[4] = 1;
        triangles[5] = 2;
        newMesh.vertices = vertices;
        newMesh.uv = uv;
        newMesh.triangles = triangles;
        return newMesh;
    }
}
