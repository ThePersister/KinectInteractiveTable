using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFB_Sphere_Pool : Singleton<PFB_Sphere_Pool> {

    public int PoolSize;
    public GameObject Pooled_Prefab;
    public List<GameObject> Pool = new List<GameObject>();

    // Instantiate an amount of Pooled_Prefabs equal to the PoolSize;
    void Start()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            Pool.Add(Instantiate(Pooled_Prefab, Vector3.zero, Quaternion.identity) as GameObject);
        }
    }

    /* You can use RetrieveInstance() of this Instance_Pool instead of where you'd normally use Instantiate.
     * To restore the availablity of the instance after its use, simply use SetActive(false) on the instance;
     */

    /// <summary>
    /// Retrieves an available instance.
    /// If there are no available instances, a new one will be instantiated.
    /// After finding an appropriate instance, activate it and return it.
    /// 
    /// Important Discovery: Inactive Gameobjects will still count as a transform within a transform!
    /// </summary>
    /// <returns>An instance of the pooled prefab.</returns>
    public GameObject RetrieveInstance(Vector3 spawnPos, Quaternion rotation)
    {

        if (Pool.Count == 0)
        {
            return Instantiate(Pooled_Prefab, spawnPos, rotation) as GameObject;
        }

        GameObject availableInstance = Pool[0];
        Pool.RemoveAt(0);

        // Position and Rotate the instance.
        availableInstance.transform.position = spawnPos;
        availableInstance.transform.rotation = rotation;

        availableInstance.SetActive(true);
        return availableInstance;
    }
}
