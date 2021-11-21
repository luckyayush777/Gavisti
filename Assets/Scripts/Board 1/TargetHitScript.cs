using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitScript : MonoBehaviour
{
    [SerializeField]
    private Material materialOnShoot;
    private Material _currentMaterial;
 
    public static float _redAmount;
    public static float _blueAmount;
    public static float _greenAmount;
    [SerializeField]
    private float _redAmountIncrease;
    [SerializeField]
    private float _greenAmountIncrease;
    [SerializeField]
    private float _blueAmountIncrease;
    [SerializeField]
    private GameObject _targetObject;
    public delegate void OnMatch();
    public static event OnMatch OnColorMatch;



    // Start is called before the first frame update
    void Start()
    {
        
        _currentMaterial = GetComponent<MeshRenderer>().material;
        if (_currentMaterial == null)
        {
            Debug.Log("couldnt find attached material");
        }
        ResetSetup();
        _currentMaterial.color = new Color(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        _currentMaterial.color = new Color(_redAmount, _greenAmount, _blueAmount);
        GetComponent<MeshRenderer>().material = _currentMaterial;
        if (_currentMaterial.color.r == _targetObject.GetComponent<MatchTarget>().colorOnTarget._r
            && _currentMaterial.color.g == _targetObject.GetComponent<MatchTarget>().colorOnTarget._g
            && _currentMaterial.color.b == _targetObject.GetComponent<MatchTarget>().colorOnTarget._b)
        {
            Debug.Log("matched Target");
            OnColorMatch?.Invoke();
        }
    }

    private void OnEnable()
    {
        //GunScript.TargetHit += OnShot;
    }

    private void OnDisable()
    {
        //GunScript.TargetHit -= OnShot;
    }
    public void OnShot()
    {
        /*GetComponent<Renderer>().material = new Material(Shader.Find("Standard"))
        {
            color = Color.green
        };
        */

    }

    private void ResetSetup()
    {
        _redAmount = 0.0f;
        _greenAmount = 0.0f;
        _blueAmount = 0.0f;
    }

    public void IncreaseRed()
    {
        _redAmount += _redAmountIncrease;
    }

    public void IncreaseBlue()
    {
        _blueAmount += _blueAmountIncrease;
    }

    public void IncreaseGreen()
    {
        _greenAmount += _greenAmountIncrease;
    }
}
