using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{

    [SerializeField]
    List<GameObject> targets = new List<GameObject>();
    private List<GameObject> surroundingTargets = new List<GameObject>();
    private GameObject leftTarget;
    private GameObject rightTarget;
    private GameObject upTarget;
    private GameObject downTarget;

    private int xCount = 1;
    private int yCount = 1;
    public static GameObject currentShotInstance;
    private static int _boardLength = 5;
    private static int _boardWidth = 5;
    void Start()
    {
        SetupTargets();
    

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
        
        if (currentShotInstance != null)
        {
            foreach (var target in targets)
            {
                if (LeftCondition(currentShotInstance, target) && !leftTarget)
                {
                    leftTarget = target;
                    Debug.Log("left set");
                    Color leftTargetColor = target.GetComponent<MeshRenderer>().material.color ;
                    leftTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = leftTargetColor;

                }
            }

            foreach (var target in targets)
            {
                if (RightCondition(currentShotInstance, target) && !rightTarget)
                {
                    rightTarget = target;
                    Debug.Log("right set");
                    Color rightTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    rightTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = rightTargetColor;
                }
            }
            foreach (var target in targets)
            {
                if (DownCondition(currentShotInstance, target) && !downTarget)
                {
                    downTarget = target;
                    Debug.Log("down set");
                    Color downTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    downTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = downTargetColor;
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
                }
            }
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
