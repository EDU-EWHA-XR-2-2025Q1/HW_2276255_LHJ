using UnityEngine;
using Vuforia;

public class Instantiate_GameObject : MonoBehaviour
{
    public GameObject heartTemplate;     // 비활성화된 원본 오브젝트 (씬 안에 존재)
    public int cloneCount = 10;
    public Transform spawnParent;

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
        if (heartTemplate == null || spawnParent == null)
        {
            Debug.LogError("HeartTemplate 또는 SpawnParent가 설정되지 않았습니다.");
            return;
        }

        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 randomSphere = Random.insideUnitSphere * 5f;
            randomSphere.y = 0f;

            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);

            GameObject clone = Instantiate(heartTemplate, randomSphere, randomRot, spawnParent);
            clone.name = "Clone-" + string.Format("{0:D4}", i);
            clone.SetActive(true); // 복제본만 활성화
        }
    }
}
