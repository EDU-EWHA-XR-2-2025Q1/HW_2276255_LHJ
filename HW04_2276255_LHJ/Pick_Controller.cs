using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Controller : MonoBehaviour
{
    public void Add_Click(GameObject clone)
    {
        GameManager.Instance.pickCount++;
        UI_Controller.Instance.Display_PickCounts(GameManager.Instance.pickCount);
        Destroy(clone);
    }
}

