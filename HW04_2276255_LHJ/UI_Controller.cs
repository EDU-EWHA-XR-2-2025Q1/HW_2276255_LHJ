using UnityEngine;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller Instance;          

    public TMP_Text PickCounts;                    // Text(TMP)_Pick
    public TMP_Text PutCounts;                     // Text(TMP)_Counts

    void Awake() => Instance = this;

    void Start() => RefreshCounts();               


    public void RefreshCounts()
    {
        if (GameManager.Instance == null) return;

        PickCounts.text = GameManager.Instance.pickCount.ToString();
        PutCounts.text = GameManager.Instance.putCount.ToString();
    }


    public void Display_PickCounts(int c) => PickCounts.text = c.ToString();

    public void Display_PutCounts()               
        => PutCounts.text = (int.Parse(PutCounts.text) + 1).ToString();

    public void Decrease_PickCounts()
        => PickCounts.text = (int.Parse(PickCounts.text) - 1).ToString();

    public int GetPickCounts() => int.Parse(PickCounts.text);
}
