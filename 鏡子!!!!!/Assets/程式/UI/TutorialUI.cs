using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorialPanel;

    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;

            tutorialPanel.SetActive(isOpen);

            // 滑鼠顯示
            Cursor.visible = isOpen;

            // 解鎖滑鼠
            Cursor.lockState = isOpen ?
                CursorLockMode.None :
                CursorLockMode.Locked;
        }
    }
}