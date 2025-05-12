using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    [Header("발사 설정")]
    public GameObject projectilePrefab;     // 발사체 프리팹
    public Transform firePoint;             // 발사 위치 (카메라 앞 조준점)
    public float fireForce = 10f;

    [Header("UI 연결")]
    public Button fireButton;               // 발사 버튼 (OnClick → Fire() 등록)

    void Start() => UpdateButtonState();   // 시작 시 버튼 상태

    void Update() => UpdateButtonState();   // PickCount 변동 시 실시간 반영


    void UpdateButtonState()
    {
        if (fireButton != null)
            fireButton.interactable = GameManager.Instance.pickCount > 0;
    }

 
    public void Fire()
    {
        if (GameManager.Instance.pickCount <= 0) return;

        // 1) 발사체 생성
        GameObject projectile = Instantiate(projectilePrefab,
                                            firePoint.position,
                                            Quaternion.identity);

        // 2) 전방 방향으로 힘 가하기
        if (projectile.TryGetComponent(out Rigidbody rb))
            rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);

        // 3) 카운트 처리
        GameManager.Instance.pickCount--;   // Pick 감소
        GameManager.Instance.putCount++;    // Put 증가

        // 4) UI 즉시 갱신
        UI_Controller.Instance.RefreshCounts();

        // 5) 버튼 상태 재확인
        UpdateButtonState();
    }
}
