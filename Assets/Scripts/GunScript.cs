using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
public class GunScript : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    [SerializeField]
    private float _gunRange;
    public delegate void OnHit();
    //public static event OnHit TargetHit;
    private AudioSource audioSource;
    [SerializeField]
    private Text _ammoAmountText;
    [SerializeField]
    private int _amountOfBullets;
    private int _currentAmountOfBulletsShot;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _ammoAmountText.text = (_amountOfBullets - _currentAmountOfBulletsShot).ToString();     
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (_amountOfBullets - _currentAmountOfBulletsShot) > 0)
        {
            //Debug.Log("clicked!");
            _currentAmountOfBulletsShot++;
            _ammoAmountText.text = (_amountOfBullets - _currentAmountOfBulletsShot).ToString();
            audioSource.Play();
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out RaycastHit hit, _gunRange))
            {
                if(hit.collider.gameObject.GetComponent<SelectorBehaviour>() != null)
                hit.collider.gameObject.GetComponent<SelectorBehaviour>().OnShot();
                if (hit.collider.gameObject.GetComponent<SelectorBehaviour>() == null &&
                    hit.collider.gameObject.GetComponent<BoardPuzzleBehaviour>() != null)
                {
                    //Debug.Log("Hit Board 2 target");
                    hit.collider.gameObject.GetComponent<BoardPuzzleBehaviour>().OnShot();
                }
          
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadGun();
        }
    }

    private void ReloadGun()
    {
        _currentAmountOfBulletsShot = 0;
        _ammoAmountText.text = _amountOfBullets.ToString();
    }
}
