using UnityEngine;
using System.Collections;

public class OnTriggerSkeleton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("DESTROYED AN OBJECT");
        Destroy(other.gameObject);
    }
}
