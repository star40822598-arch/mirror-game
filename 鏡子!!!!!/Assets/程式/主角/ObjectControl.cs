using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
    public float interactDistance = 10f;
    public float rotateSpeed = 120f;

    public Image crosshair;              // UI 十字準心
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    private Transform currentTarget;

    void Update()
    {
        CheckTarget();

        // 按下滑鼠 → 鎖定鏡子
        if (Input.GetMouseButtonDown(0) && currentTarget != null)
        {
            // 已經在 CheckTarget 設定
        }

        // 放開 → 取消
        if (Input.GetMouseButtonUp(0))
        {
            currentTarget = null;
        }

        // 按住旋轉
        if (Input.GetMouseButton(0) && currentTarget != null)
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
            if (hit.collider.CompareTag("Mirror") || hit.collider.CompareTag("Key"))
            {
                currentTarget = hit.collider.transform;
                crosshair.color = hoverColor;
                return;
            }
        }

        // 沒對到鏡子
        currentTarget = null;
        crosshair.color = normalColor;
    }

    void RotateMirror()
    {
        float mouseX = Input.GetAxis("Mouse X");

        currentTarget.Rotate(Vector3.up, mouseX * rotateSpeed * Time.deltaTime);
    }
}