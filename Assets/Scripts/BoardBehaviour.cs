using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    List<GameObject> targets = new List<GameObject>();
    private List<GameObject> surroundingTargets = new List<GameObject>();
    private GameObject leftTarget;
    private GameObject rightTarget;
    private GameObject upTarget;
    private GameObject downTarget;
    private bool _targetsSet = false;

    private int xCount = 1;
    private int yCount = 1;
    public static GameObject currentShotInstance;
    void Start()
    {
        SetupTargets();
    

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
                if (xCount > 4)
                {
                    yCount++;
                    xCount = 1;
                }

                targets.Add(boardTarget.gameObject);

            }
        }
    }
    void Update()
    {
        TargetShot();
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
                    target.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }

            foreach (var target in targets)
            {
                if (RightCondition(currentShotInstance, target) && !rightTarget)
                {
                    rightTarget = target;
                    Debug.Log("right set");
                    target.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            foreach (var target in targets)
            {
                if (DownCondition(currentShotInstance, target) && !downTarget)
                {
                    downTarget = target;
                    Debug.Log("down set");
                    target.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            foreach (var target in targets)
            {
                if (UpCondition(currentShotInstance, target) && !upTarget)
                {
                    upTarget = target;
                    Debug.Log("up set");
                    target.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            if(leftTarget && rightTarget && upTarget && downTarget)
            {
                ResetCurrentShot();
            }
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

  

    private void ChangeSurroundingTargets()
    {
        
    }



   


}
