using UnityEngine;

public class EscQuitManager : MonoBehaviour
{
    public GameObject exitHint;

    private bool hintVisible = false;
    private float holdTime = 0f;

    void Update()
    {
        // 顯示提示
        if (Input.GetKeyDown(KeyCode.Escape) && !hintVisible)
        {
            hintVisible = true;
            exitHint.SetActive(true);
        }

        // F關閉提示
        if (Input.GetKeyDown(KeyCode.F) && hintVisible)
        {
            hintVisible = false;
            exitHint.SetActive(false);
            holdTime = 0f;
        }

        // 長按ESC退出
        if (hintVisible)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                holdTime += Time.deltaTime;

                if (holdTime >= 3f)
                {
                    QuitGame();
                }
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                holdTime = 0f;
            }
        }
    }

    void QuitGame()
    {
        Debug.Log("退出遊戲");
        Application.Quit();
    }
}