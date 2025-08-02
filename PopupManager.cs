using UnityEngine;
public class PopupManager : MonoBehaviour
{
    public GameObject popupWindow;
    
    public void ClosePopup()
    {
        Debug.Log("ClosePopup called");
        popupWindow.SetActive(false);
    }

    public void OpenPopup()
    {
        Debug.Log("OpenPopup called");
        popupWindow.SetActive(true);

    }
}