using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public GameObject arrow;
    public TextMeshProUGUI tutorialText;
    public GameObject GametourPanel;

    public Transform mirrorTarget;
    public Transform laserTarget;

    private int tutorialStep = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartMirrorTutorial();
    }

    private void Update()
    {
        UpdateArrow();
    }

    void UpdateArrow()
    {
        if (tutorialStep == 0)
        {
            PointToTarget(mirrorTarget);
        }
        else if (tutorialStep == 1)
        {
            PointToTarget(laserTarget);
        }
    }

    void PointToTarget(Transform target)
    {
        Vector3 screenPos =
            Camera.main.WorldToScreenPoint(target.position);

        arrow.transform.position =
            screenPos + new Vector3(0, 80, 0);
    }

    public void StartMirrorTutorial()
    {
        tutorialStep = 0;

        tutorialText.text =
            "前往黑色邊框鏡子，對準鏡子並按住滑鼠左鍵旋轉，並調整至適當角度";
    }

    public void MirrorTouched()
    {
        tutorialStep = 1;

        tutorialText.text =
            "利用鏡子將雷射反射至目標物 相框 ";
    }

    public void TargetActivated()
    {
        tutorialText.text = "";
        arrow.SetActive(false);
        GametourPanel.SetActive(false);
    }
}