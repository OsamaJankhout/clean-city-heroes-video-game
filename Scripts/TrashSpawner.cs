using UnityEngine;
public class TrashSpawner : MonoBehaviour {

    public GameObject trashbagPrefab;
    public Collider[] spawnArea; 
    public int spawnCount = 50;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    { 
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnTrash();
        }
    }
    void SpawnTrash()
    {
        if (spawnArea.Length == 0) return;
        int i = Random.Range(0, spawnArea.Length);
        Collider area = spawnArea[i];

        Vector3 pos = new Vector3(Random.Range(area.bounds.min.x, area.bounds.max.x), area.bounds.center.y, Random.Range(area.bounds.min.z, area.bounds.max.z));

        Instantiate(trashbagPrefab, pos, Quaternion.identity);
    } 
}