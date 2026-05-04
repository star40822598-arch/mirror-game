using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform spawnPoint;
    public CameraFocus cameraFocus;

    private bool spawned = false;

    public void SpawnKey()
    {
        if (spawned) return;

        GameObject key = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
        spawned = true;

        // ⭐ 讓鏡頭看鑰匙
        if (cameraFocus != null)
        {
            cameraFocus.FocusOnTarget(key.transform);
        }
    }
}