using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour
{
    public float focusDuration = 2f;
    public float rotateSpeed = 5f;
    public MonoBehaviour playerLookScript;

    private bool isFocusing = false;
    private Quaternion originalRotation;

    public void FocusOnTarget(Transform target)
    {
        if (!isFocusing)
        {
            StartCoroutine(FocusRoutine(target));
        }
    }

    IEnumerator FocusRoutine(Transform target)
    {
        isFocusing = true;

        if (playerLookScript != null)
            playerLookScript.enabled = false;

        originalRotation = transform.rotation;

        // ⭐ 1. 轉到鑰匙（用 RotateTowards，不用 t）
        while (true)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                lookRot,
                180f * Time.deltaTime   // 轉速（角度/秒）
            );

            // ⭐ 判斷是否已經差不多對準
            if (Quaternion.Angle(transform.rotation, lookRot) < 1f)
                break;

            yield return null;
        }

        // ⭐ 2. 停留時間（這才是真正的停留）
        yield return new WaitForSeconds(focusDuration);

        // ⭐ 3. 轉回原本
        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                originalRotation,
                180f * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, originalRotation) < 1f)
                break;

            yield return null;
        }

        if (playerLookScript != null)
            playerLookScript.enabled = true;

        isFocusing = false;
    }
}