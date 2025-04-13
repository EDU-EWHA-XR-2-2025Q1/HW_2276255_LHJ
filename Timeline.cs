using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    public void OnFrameEnter_Stop()
    {
        GetComponent<Animator>().speed = 0;
    }
}
