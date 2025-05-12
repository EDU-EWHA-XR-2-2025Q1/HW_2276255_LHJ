using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int pickCount = 0;
    public int putCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // ← 씬 전환에도 파괴되지 않음
        }
        else Destroy(gameObject);
    }
}

