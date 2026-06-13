using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndingManager : MonoBehaviour
{
    public GameObject winPanel;

    public VideoPlayer endingVideo;

    public MonoBehaviour playerMoveScript;
    public MonoBehaviour playerLookScript;

    private bool finished = false;

    public void StartEnding()
    {
        if (finished) return;

        finished = true;

        playerMoveScript.enabled = false;
        playerLookScript.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        endingVideo.gameObject.SetActive(true);

        endingVideo.Play();

        endingVideo.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        ShowWinPanel();
    }

    void ShowWinPanel()
    {
        winPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("退出遊戲");
    }
}