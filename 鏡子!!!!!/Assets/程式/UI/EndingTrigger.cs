using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public EndingManager endingManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endingManager.StartEnding();
        }
    }
}