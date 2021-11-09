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

    // Update is called once per frame
    void Update()
    {
        TargetShot();
    }

    private void TargetShot()
    {
        if (currentShotInstance != null)
        {
            Debug.Log(currentShotInstance.GetComponent<BoardPuzzleBehaviour>().xCoordinate + " "
                + currentShotInstance.GetComponent<BoardPuzzleBehaviour>().yCoordinate);
            //Debug.Log(currentShotInstance.GetComponent<BoardPuzzleBehaviour>().yCoordinate);
        }
           
        foreach(var target in targets)
        {
           if ( LeftCondition(currentShotInstance, target) && !_targetsSet)
           {
                leftTarget = target;
                Debug.Log("left set");
           }
           if ( RightCondition(currentShotInstance, target) && !_targetsSet)
           {
                rightTarget = target;
                Debug.Log("left set");

           }
           if ( UpCondition(currentShotInstance, target) && !_targetsSet)
           {
               upTarget = target;
                Debug.Log("left set");

           }
           if ( DownCondition(currentShotInstance, target) && !_targetsSet)
           {
               downTarget = target;
                Debug.Log("left set");

           }
        }
        if ( leftTarget && rightTarget && upTarget && downTarget)
        {
            Debug.Log("Targets set");
            _targetsSet = true;
        }
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
        Debug.Log(targets.Count);
    }

    private bool LeftCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor != null && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate - 1
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                ) &&
                (
                objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
                objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }

    private bool RightCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor != null && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate + 1
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                ) &&
                (
                objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate ==
                objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }

    private bool UpCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor != null && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                ) &&
                (
                objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate - 1 ==
                objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }


    private bool DownCondition(GameObject objectToCheckFor, GameObject objectToCheckAgainst)
    {
        if (objectToCheckFor != null && (objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                == objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().xCoordinate
                ) &&
                (
                objectToCheckFor.GetComponent<BoardPuzzleBehaviour>().yCoordinate  + 1 ==
                objectToCheckAgainst.GetComponent<BoardPuzzleBehaviour>().yCoordinate))
            return true;
        else
            return false;
    }


}
