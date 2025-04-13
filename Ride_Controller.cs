using System.Collections;
using UnityEngine;

public class Ride_Controller : MonoBehaviour
{
    public Transform destination;     // ������(Room2 ��ó ��ġ)
    public float speed = 2f;          // �̵� �ӵ�

    private bool isRiding = false;
    private bool isArrived = false;
    private Transform playerTransform;

    private void Update()
    {
        // ž�� �� & ���� �������� �ʾ��� ���� �̵�
        if (isRiding && !isArrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination.position) < 0.1f)
            {
                isArrived = true;
                isRiding = false;
                playerTransform?.SetParent(null); // �����ص� �ڵ� ����
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRiding && !isArrived)
        {
            isRiding = true;
            playerTransform = other.transform;

            // FPSController�� Vehicle�� �ڽ����� ���̰� ��¦ ���� �ø���
            playerTransform.SetParent(transform);
            playerTransform.position = transform.position + Vector3.up * 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isRiding)
        {
            // �÷��̾ Vehicle���� ������ ����
            isRiding = false;
            playerTransform.SetParent(null);
        }
    }
}
