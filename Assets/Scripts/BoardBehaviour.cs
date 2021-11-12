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
    [SerializeField]
    private float _targetSurroundObjectRedIncrease;
    [SerializeField]
    private float _targetSurroundObjectGreenIncrease;
    [SerializeField]
    private float _targetSurroundingObjectBlueIncrease;
    [SerializeField]
    private Color testColor;
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
                if (xCount > 4)
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
                    /*if (leftTargetColor.r >= 0.0f)
                        leftTargetColor.r += _targetSurroundObjectRedIncrease;
                    else if (leftTargetColor.r >= 1.0f)
                        leftTargetColor.g += _targetSurroundObjectGreenIncrease;
                    else if (leftTargetColor.r >= 1.0f && leftTargetColor.g >= 1.0f)
                        leftTargetColor.b += _targetSurroundingObjectBlueIncrease;
                    */
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
                    /*if (rightTargetColor.r >= 0.0f)
                        rightTargetColor.r += _targetSurroundObjectRedIncrease;
                    else if (rightTargetColor.r >= 1.0f)
                        rightTargetColor.g += _targetSurroundObjectGreenIncrease;
                    else if (rightTargetColor.r >= 1.0f && rightTargetColor.g >= 1.0f)
                        rightTargetColor.b += _targetSurroundingObjectBlueIncrease;
                    */
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
                    /*
                    if (downTargetColor.r >= 0.0f)
                        downTargetColor.r += _targetSurroundObjectRedIncrease;
                    else if (downTargetColor.r >= 1.0f)
                        downTargetColor.g += _targetSurroundObjectGreenIncrease;
                    else if (downTargetColor.r >= 1.0f && downTargetColor.g >= 1.0f)
                        downTargetColor.b += _targetSurroundingObjectBlueIncrease;
                    //downTargetColor.g += _targetSurroundObjectGreenIncrease;
                    //downTargetColor.b += _targetSurroundingObjectBlueIncrease;
                    */
                    downTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = downTargetColor;
                }
            }
            foreach (var target in targets)
            {
                if (UpCondition(currentShotInstance, target) && !upTarget)
                {
                    upTarget = target;
                    Debug.Log("up set");
                    Color upTargetColor = target.GetComponent<MeshRenderer>().material.color;
                    /*
                    if (upTargetColor.r >= 0.0f)
                        upTargetColor.r += _targetSurroundObjectRedIncrease;
                    else if (upTargetColor.r >= 1.0f)
                        upTargetColor.g += _targetSurroundObjectGreenIncrease;
                    else if (upTargetColor.r >= 1.0f && upTargetColor.g >= 1.0f)
                        upTargetColor.b += _targetSurroundingObjectBlueIncrease;
                    */
                    upTargetColor = Color.red;
                    target.GetComponent<MeshRenderer>().material.color = upTargetColor;
                }
            }
            ResetCurrentShot();
            print("Reset Shot");
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
