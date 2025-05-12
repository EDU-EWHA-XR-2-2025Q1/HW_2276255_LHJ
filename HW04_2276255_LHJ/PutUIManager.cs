using UnityEngine;
using UnityEngine.UI;

public class PutUIManager : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject fireButton;
    public GameObject bowl; 

    public void ShowPutUI()
    {
        crosshair.SetActive(true);
        fireButton.SetActive(true);
        bowl.SetActive(true); 
    }

    public void HidePutUI()
    {
        crosshair.SetActive(false);
        fireButton.SetActive(false);
        bowl.SetActive(false);
    }
}
