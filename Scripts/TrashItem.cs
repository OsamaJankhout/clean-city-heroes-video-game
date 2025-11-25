using UnityEngine;

public class TrashItem : MonoBehaviour
{
    int scoreValue = 10;
    public AudioClip pickup;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var lm = FindObjectOfType<LevelManager>();
        if(lm != null)
        {
            lm.AddScore(scoreValue);
            lm.OnTrashCollected();
        }

        if (pickup) AudioSource.PlayClipAtPoint(pickup, transform.position, 0.8f);
        Destroy(gameObject);
    }
}
