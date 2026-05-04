using UnityEngine;

public class LaserTarget : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;
    public Color glowColor = Color.yellow;

    private bool isHit = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        if (!isHit)
        {
            rend.material.color = originalColor;
        }

        isHit = false;
    }

    public void HitByLaser()
    {
        rend.material.color = glowColor;
        isHit = true;
    }
}