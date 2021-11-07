using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    List<GameObject> targets = new List<GameObject>();
    private int xCount = 1;
    private int yCount = 1;
    void Start()
    {
        foreach(BoardPuzzleBehaviour boardTarget in GetComponentsInChildren<BoardPuzzleBehaviour>())
        {
            if(boardTarget._isTarget == true)
            {
                boardTarget.xCoordinate = xCount;
                boardTarget.yCoordinate = yCount;
                xCount++;
                if (xCount > 4)
                {
                    yCount++;
                    xCount = 1; 
                }                    
                
                targets.Add(boardTarget.gameObject);
                
            }
        }
        Debug.Log(targets.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
