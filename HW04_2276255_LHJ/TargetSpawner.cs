using UnityEngine;
using Vuforia;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;          // Heart ������
    public int cloneCount = 10;
    public Transform spawnParent;            // ������ ��Ʈ�� ���� �θ� ������Ʈ

    private bool hasSpawned = false;

    void Start()
    {
        VuforiaBehaviour.Instance.enabled = true;
        GetComponent<ObserverBehaviour>().OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (!hasSpawned && status.Status == Status.TRACKED)
        {
            SpawnItems();
            hasSpawned = true;
        }
    }

    void SpawnItems()
    {
        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 randomPos = Random.insideUnitSphere * 5f;
            randomPos.y = 0.5f;

            GameObject clone = Instantiate(targetPrefab, randomPos, Quaternion.identity, spawnParent);
            clone.SetActive(true);
        }
    }
}
