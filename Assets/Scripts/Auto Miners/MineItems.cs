using System.Collections.Generic;
using UnityEngine;

public class MineItems : MonoBehaviour
{
    public MineItemsController mineItemsController;
    
    private List<Transform> spawnPoints = new List<Transform>();
    public ItemScriptableObject itemTemplate;
    public float spawnInterval;

    private bool canSpawn = true;
    private float lastSpawnTime = 0;

    private void Start()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform child in childTransforms)
        {
            if (child.CompareTag("SpawnPoint"))
            {
                spawnPoints.Add(child);
            }
        }

        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (canSpawn && spawnPoints.Count > 0 && Time.time - lastSpawnTime >= spawnInterval)
        {
            Transform spawnPoint = GetNextAvailableSpawnPoint();

            if (spawnPoint != null)
            {
                GameObject newItem = Instantiate(itemTemplate.ItemPrefab, spawnPoint.position, Quaternion.identity);
                newItem.transform.parent = spawnPoint;

                lastSpawnTime = Time.time;

                if(mineItemsController != null)
                {
                    mineItemsController.ItemSpawned();
                }
            }
        }
    }

    public void SetCanSpawn(bool canSpawn)
    {
        this.canSpawn = canSpawn;
    }

    private Transform GetNextAvailableSpawnPoint()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 0.2f);

            if (colliders.Length == 0)
            {
                return spawnPoint;
            }
        }

        return null;
    }
}
