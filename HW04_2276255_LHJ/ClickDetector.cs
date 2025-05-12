using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���콺 Ŭ�� ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var item = hit.collider.GetComponent<Item_Controller>();
                if (item != null)
                {
                    item.OnClickedExternally(); // Heart Ŭ�� �� ȣ��
                }
            }
        }
    }
}
