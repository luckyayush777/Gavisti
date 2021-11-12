using UnityEngine;

public class BoardPuzzleBehaviour : MonoBehaviour
{
    public bool _isTarget = false;
    public int xCoordinate;
    public int yCoordinate;
    [SerializeField]
    private float _targetRedIncrease;
    [SerializeField]
    private float _targetGreenIncrease;
    [SerializeField]
    private float _targetBlueIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShot()
    {
        Color targetColor = GetComponent<MeshRenderer>().material.color;
        /*if(targetColor.r >= 0.0f)
        {
            targetColor.r += _targetRedIncrease;
        }
        else if(targetColor.r >= 1.0f )
        {
            targetColor.g += _targetGreenIncrease;
        }
        else if(targetColor.r >= 1.0f && targetColor.g >= 1.0f)
        {
            targetColor.b += _targetBlueIncrease;
        }
        */
        targetColor = Color.red;
        GetComponent<MeshRenderer>().material.color = targetColor;
        BoardBehaviour.currentShotInstance = gameObject;
    }
}
