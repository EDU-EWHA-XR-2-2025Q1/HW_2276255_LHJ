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
            DontDestroyOnLoad(gameObject);   // �� �� ��ȯ���� �ı����� ����
        }
        else Destroy(gameObject);
    }
}

