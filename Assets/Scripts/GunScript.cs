using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D crosshairTexture;
    public float crosshairScale = 1;
    private void OnGUI()
    {
        if (Time.timeScale != 0)
        {
            if (crosshairTexture != null)
            {
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height
                    - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale,
                      crosshairTexture.height * crosshairScale), crosshairTexture);
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
