using UnityEngine;

public class LaserTargetRoom2 : MonoBehaviour
{
    public KeySpawner keySpawner;

    public float requiredTime = 3f;   // 需要時間
    public Renderer targetRenderer;  // 指定模型

    private float timer = 0f;
    private bool isActivated = false;
    private bool isBeingHit = false;

    private Material mat;
    private Color baseColor;
    private Color emissionColor;

    void Start()
    {
        mat = targetRenderer.material;

        baseColor = Color.red;           // 原本顏色
        emissionColor = Color.red * 5f;  // 發光顏色（強度可調）

        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.black);
    }

    void Update()
    {
        if (isActivated) return;

        if (isBeingHit)
        {
            timer += Time.deltaTime;

            // ⭐ 發光強度（依時間變化）
            float t = Mathf.Clamp01(timer / requiredTime);
            Color currentEmission = Color.Lerp(Color.black, emissionColor, t);
            mat.SetColor("_EmissionColor", currentEmission);
            TutorialManager.Instance.TargetActivated();

            if (timer >= requiredTime)
            {
                Activate();
            }
        }
        else
        {
            // ⭐ 沒被照 → 發光慢慢消失
            timer = 0f;
            mat.SetColor("_EmissionColor", Color.black);
        }

        isBeingHit = false;
    }

    public void HitByLaser_Room2()
    {
        isBeingHit = true;
    }

    void Activate()
    {
        isActivated = true;

        // ⭐ 完全發光（完成狀態）
        mat.SetColor("_EmissionColor", emissionColor);

        if (keySpawner != null)
        {
            keySpawner.SpawnKey();
        }
        else
        {
            Debug.LogError("KeySpawner 沒設定！");
        }
    }
}