using UnityEngine;
using Vuforia;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;          // Heart 프리팹
    public int cloneCount = 10;
    public Transform spawnParent;            // 생성된 하트를 담을 부모 오브젝트

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
