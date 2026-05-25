using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public DoorController door;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 120f))
        {
            if (hit.collider.gameObject == gameObject)
            {
                door.OpenDoor();
                Destroy(gameObject);
            }
        }
    }
}