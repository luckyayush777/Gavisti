using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{

    [SerializeField]
    List<GameObject> targets = new List<GameObject>();
    private List<GameObject> surroundingTargets = new List<GameObject>();
    public static List<GameObject> listOfPuzzlePieces = new List<GameObject>();
    private List<bool> listOfPatternBools = new List<bool>();
    private GameObject leftTarget;
    private GameObject rightTarget;
    private GameObject upTarget;
    private GameObject downTarget;

    private int xCount = 1;
    private int yCount = 1;
    public static GameObject currentShotInstance;
    private static int _boardLength = 5;
    private static int _boardWidth = 5;
    private bool patternMatched = false;

    public static event TargetHitScript.OnMatch OnPatternMatch;

    private void Awake()
    {
        
    }
    void Start()
    {
        SetupTargets();
        for (int i = 0; i < listOfPuzzlePieces.Count; i++)
        {
            //print(listOfPuzzlePieces.Count);
            listOfPatternBools.Add(listOfPuzzlePieces[i].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart);
        }
        print(listOfPatternBools.Count);    
        InvokeRepeating("CheckForMatchesWithDisplayBoard", 0.0f, 0.5f);
    }
    void Update()
    {
        TargetShot();
        
    }

    private void SetupTargets()
    {
        foreach (BoardPuzzleBehaviour boardTarget in GetComponentsInChildren<BoardPuzzleBehaviour>())
        {
            if (boardTarget._isTarget == true)
            {
                boardTarget.xCoordinate = xCount;
                boardTarget.yCoordinate = yCount;
                xCount++;
                if (xCount > 5)
                {
                    yCount++;
                    xCount = 1;
                }

                targets.Add(boardTarget.gameObject);

            }
        }
    }


    private void TargetShot()
    {
        if (currentShotInstance == null)
            return;
        if (currentShotInstance != null)
        {
            foreach (var target in targets)
            {
                if (LeftCondition(currentShotInstance, target) && !leftTarget)
                {
                    leftTarget = target;
                    //Debug.Log("left set");
                    Color leftTargetColor = target.GetComponent<MeshRenderer>().material.color ;
                    leftTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = leftTargetColor;
                    //target.GetComponent<BoardPuzzleBehaviour>().isShot = true;

                }
            }

            foreach (var target in targets)
            {
                if (RightCondition(currentShotInstance, target) && !rightTarget)
                {
                    rightTarget = target;
                    //Debug.Log("right set");
                    Color rightTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    rightTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = rightTargetColor;
                    //target.GetComponent<BoardPuzzleBehaviour>().isShot = true;

                }
            }
            foreach (var target in targets)
            {
                if (DownCondition(currentShotInstance, target) && !downTarget)
                {
                    downTarget = target;
                    //Debug.Log("down set");
                    Color downTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    downTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = downTargetColor;
                    //target.GetComponent<BoardPuzzleBehaviour>().isShot = true;

                }
            }
            foreach (var target in targets)
            {
                if (UpCondition(currentShotInstance, target) && !upTarget)
                {
                    upTarget = target;
                    Color upTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    upTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = upTargetColor;
                    //target.GetComponent<BoardPuzzleBehaviour>().isShot = true;

                }
            }
            CheckForMatchWithPuzzle();
            ResetCurrentShot();
        }

    
    }
    private void ResetCurrentShot()
    {
        
        currentShotInstance = null;
        leftTarget = null;
        rightTarget = null;
        upTarget = null;
        downTarget = null;
    }

    private void CheckForMatchWithPuzzle()
    {
        for(int i = 0; i < targets.Count; i++)
        {
            if(targets[i].GetComponent<BoardPuzzleBehaviour>().isShot)
            {
                print("checking" + targets[i].GetComponent<BoardPuzzleBehaviour>().xCoordinate
                    + " " + targets[i].GetComponent<BoardPuzzleBehaviour>().yCoordinate);
                listOfPuzzlePieces[i].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = false;
                listOfPuzzlePieces[i + _boardWidth].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = false;
                listOfPuzzlePieces[i - _boardWidth].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = false;
                listOfPuzzlePieces[i + 1].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = false;
                listOfPuzzlePieces[i - 1].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart = false;
                targets[i].GetComponent<BoardPuzzleBehaviour>().isShot = false;
                break;
            }
        }
    }

    private void CheckForMatchesWithDisplayBoard()
    {
        listOfPatternBools.Clear();
        for (int i = 0; i < listOfPuzzlePieces.Count; i++)
        {
            listOfPatternBools.Add(listOfPuzzlePieces[i].GetComponent<BoardPuzzleBehaviour>().isSpherePatternPart);
        }
        if (!listOfPatternBools.Contains(true))
        {
            //print("matched!");
            OnPatternMatch?.Invoke();
        }
    }

    private bool LeftCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if(objectToCheckFor == null)
        {
            Debug.Log("current shot instance not found");
            return false;
        }
        if (objectToCheckFor != null 
                  && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate - 1
                  == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate) 
                  && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate 
                  == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }

    private bool RightCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor == null)
        {
            Debug.Log("current shot instance not found");
            return false;
        }
        if (objectToCheckFor != null 
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate + 1
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate)
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate 
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }
    //TO DO
    // some accesor function which returns right left top and down objects

    private bool UpCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor == null)
        {
            Debug.Log("current shot instance not found");
            return false;
        }
        if (objectToCheckFor != null 
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                ==  objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate) 
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate - 1 
                ==  objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }


    private bool DownCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor == null)
        {
            Debug.Log("current shot instance not found");
            return false;
        }
        if (objectToCheckFor != null 
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate)
                && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate + 1 
                ==  objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }

    public static int GetBoardLength()
    {
        return _boardLength;    
    }

    public static int GetBoardWidth()
    {
        return _boardWidth;
    }
}
