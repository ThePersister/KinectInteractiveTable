using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnModels : MonoBehaviour {

    public float SpawnDelay = 1f;
    public Vector3 OffsetRange = new Vector3(0, 5, 0);
    public List<GameObject> Models = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        GameManager.Instance.Spawners.Add(this);
    }

    private IEnumerator SpawnModelCycle()
    {
        yield return new WaitForSeconds(SpawnDelay);

        if (isSpawning)
        {
            GameObject enemy = (GameObject)Instantiate(GetRandomModel(), transform.position + Vector3.Lerp(-OffsetRange, OffsetRange, Random.value), transform.rotation);
            enemy.transform.parent = transform;
            StartCoroutine(SpawnModelCycle());
        }
    }

    private GameObject GetRandomModel()
    {
        return Models[Mathf.RoundToInt(Random.value * (Models.Count -1))];
    }

    public void StartSpawnCycle()
    {
        isSpawning = true;
        StartCoroutine(SpawnModelCycle());
    }

    public void StopSpawnCycle()
    {
        isSpawning = false;
        MoveForward[] enemies = FindObjectsOfType<MoveForward>();

        // Clear all the enemies
        foreach (MoveForward enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
