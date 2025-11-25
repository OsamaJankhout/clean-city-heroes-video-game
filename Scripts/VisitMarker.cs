using UnityEngine;

public class VisitMarker : MonoBehaviour
{
    public string id;
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        FindObjectOfType<MissionController>().Visited(id);
    }
}
