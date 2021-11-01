using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string _selectorColor;
    [SerializeField]
    TargetHitScript _hitScript;
    void Start()
    {
        //ResetSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShot()
    {
        if(_selectorColor == "red")
        {
            Debug.Log("hit red");
            _hitScript.IncreaseRed();
        }
        else if (_selectorColor == "blue")
        {
            Debug.Log("hit blue");
            _hitScript.IncreaseBlue();

        }
        else if (_selectorColor == "green")
        {
            _hitScript.IncreaseGreen();
            Debug.Log("hit green");
        }
    }


}
