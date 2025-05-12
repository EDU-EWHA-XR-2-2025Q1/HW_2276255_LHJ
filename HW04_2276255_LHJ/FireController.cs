using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    [Header("�߻� ����")]
    public GameObject projectilePrefab;     // �߻�ü ������
    public Transform firePoint;             // �߻� ��ġ (ī�޶� �� ������)
    public float fireForce = 10f;

    [Header("UI ����")]
    public Button fireButton;               // �߻� ��ư (OnClick �� Fire() ���)

    void Start() => UpdateButtonState();   // ���� �� ��ư ����

    void Update() => UpdateButtonState();   // PickCount ���� �� �ǽð� �ݿ�


    void UpdateButtonState()
    {
        if (fireButton != null)
            fireButton.interactable = GameManager.Instance.pickCount > 0;
    }

 
    public void Fire()
    {
        if (GameManager.Instance.pickCount <= 0) return;

        // 1) �߻�ü ����
        GameObject projectile = Instantiate(projectilePrefab,
                                            firePoint.position,
                                            Quaternion.identity);

        // 2) ���� �������� �� ���ϱ�
        if (projectile.TryGetComponent(out Rigidbody rb))
            rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);

        // 3) ī��Ʈ ó��
        GameManager.Instance.pickCount--;   // Pick ����
        GameManager.Instance.putCount++;    // Put ����

        // 4) UI ��� ����
        UI_Controller.Instance.RefreshCounts();

        // 5) ��ư ���� ��Ȯ��
        UpdateButtonState();
    }
}
