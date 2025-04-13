using System.Collections;
using UnityEngine;

public class Ride_Controller : MonoBehaviour
{
    public Transform destination;     // 목적지(Room2 근처 위치)
    public float speed = 2f;          // 이동 속도

    private bool isRiding = false;
    private bool isArrived = false;
    private Transform playerTransform;

    private void Update()
    {
        // 탑승 중 & 아직 도착하지 않았을 때만 이동
        if (isRiding && !isArrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination.position) < 0.1f)
            {
                isArrived = true;
                isRiding = false;
                playerTransform?.SetParent(null); // 도착해도 자동 하차
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRiding && !isArrived)
        {
            isRiding = true;
            playerTransform = other.transform;

            // FPSController를 Vehicle에 자식으로 붙이고 살짝 위로 올리기
            playerTransform.SetParent(transform);
            playerTransform.position = transform.position + Vector3.up * 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isRiding)
        {
            // 플레이어가 Vehicle에서 내리면 정지
            isRiding = false;
            playerTransform.SetParent(null);
        }
    }
}
