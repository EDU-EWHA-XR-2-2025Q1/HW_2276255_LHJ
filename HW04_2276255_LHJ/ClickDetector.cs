using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 마우스 클릭 감지
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var item = hit.collider.GetComponent<Item_Controller>();
                if (item != null)
                {
                    item.OnClickedExternally(); // Heart 클릭 시 호출
                }
            }
        }
    }
}
