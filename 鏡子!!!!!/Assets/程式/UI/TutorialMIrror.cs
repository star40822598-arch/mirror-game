using UnityEngine;

public class TutorialMirror : MonoBehaviour
{
    bool triggered = false;

    private void OnMouseDown()
    {
        if (triggered) return;

        triggered = true;

        TutorialManager.Instance.MirrorTouched();
    }
}