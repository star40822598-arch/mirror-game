using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public Vector3 openOffset = new Vector3(0, 3, 0); // 往上開

    private bool opened = false;

    public void OpenDoor()
    {
        if (opened) return;

        opened = true;
        StartCoroutine(Open());
    }

    System.Collections.IEnumerator Open()
    {
        Vector3 startPos = door.position;
        Vector3 endPos = startPos + openOffset;

        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime;
            door.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }
    }
}