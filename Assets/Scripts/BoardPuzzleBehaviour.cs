using UnityEngine;

public class BoardPuzzleBehaviour : MonoBehaviour
{
    public bool _isTarget = false;
    public int xCoordinate;
    public int yCoordinate;
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
        GetComponent<MeshRenderer>().material.color = Color.red;
        BoardBehaviour.currentShotInstance = this.gameObject;
    }
}
