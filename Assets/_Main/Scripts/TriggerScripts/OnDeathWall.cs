using UnityEngine;
using System.Collections;

public class OnDeathWall : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (!other) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Model"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
