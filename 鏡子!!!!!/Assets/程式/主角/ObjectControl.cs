using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
    public float interactDistance = 15f;
    public float rotateSpeed = 180f;

    public Image crosshair;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    private Transform currentTarget;

    // ⭐ 是否正在旋轉
    private bool isRotating = false;

    void Update()
    {
        // ⭐ 沒在旋轉時才檢查準心
        if (!isRotating)
        {
            CheckTarget();
        }

        // ⭐ 按下滑鼠：開始旋轉
        if (Input.GetMouseButtonDown(0) && currentTarget != null)
        {
            isRotating = true;
        }

        // ⭐ 放開滑鼠：停止旋轉
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
            currentTarget = null;
        }

        // ⭐ 持續旋轉
        if (isRotating && currentTarget != null)
        {
            RotateMirror();
        }
    }

    void CheckTarget()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // ⭐ Mirror
            if (hit.collider.CompareTag("Mirror"))
            {
                currentTarget = hit.collider.transform;
                crosshair.color = hoverColor;
                return;
            }

            // ⭐ Key
            if (hit.collider.CompareTag("Key"))
            {
                crosshair.color = hoverColor;
                return;
            }
        }

        currentTarget = null;
        crosshair.color = normalColor;
    }

    void RotateMirror()
    {
        float mouseX = Input.GetAxis("Mouse X");

        currentTarget.Rotate(
            Vector3.up,
            -mouseX * rotateSpeed * Time.deltaTime
        );
    }
}