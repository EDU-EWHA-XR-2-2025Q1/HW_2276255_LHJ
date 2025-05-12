using UnityEngine;

public class Item_Controller : MonoBehaviour
{
    public GameObject PickController;

    public void OnClickedExternally()
    {
        PrintInfo();
        if (PickController != null)
        {
            PickController.GetComponent<Pick_Controller>().Add_Click(gameObject);
        }
    }

    void PrintInfo()
    {
        Debug.Log($"{gameObject.name}을/를 클릭했습니다.");
    }
}
