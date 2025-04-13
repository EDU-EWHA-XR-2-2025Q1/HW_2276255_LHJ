using System.Collections;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public Animator animator;
    public Transform doorTransform;
    public float openAngle = 90f;

    private Quaternion closedRotation;
    private Coroutine doorCoroutine;

    private void Start()
    {
        closedRotation = doorTransform.localRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 toPlayer = (other.transform.position - doorTransform.position).normalized;
            float dot = Vector3.Dot(doorTransform.forward, toPlayer);

            Quaternion targetRotation = (dot > 0)
                ? Quaternion.Euler(0, -openAngle, 0)
                : Quaternion.Euler(0, openAngle, 0);

            if (doorCoroutine != null) StopCoroutine(doorCoroutine);
            doorCoroutine = StartCoroutine(RotateDoor(targetRotation));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorCoroutine != null) StopCoroutine(doorCoroutine);
            doorCoroutine = StartCoroutine(RotateDoor(closedRotation));
        }
    }

    private IEnumerator RotateDoor(Quaternion targetRot)
    {
        float duration = 1f;
        float time = 0f;
        Quaternion startRot = doorTransform.localRotation;

        while (time < duration)
        {
            time += Time.deltaTime;
            doorTransform.localRotation = Quaternion.Lerp(startRot, targetRot, time / duration);
            yield return null;
        }

        doorTransform.localRotation = targetRot;
    }
}
