using UnityEngine;
using UnityEditor;
using System.Collections;

public class OnTriggerSkeleton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Squash"))
        {
            other.SendMessage("SquashMe", SendMessageOptions.RequireReceiver);
        }
        else
        {
            other.transform.SendMessageUpwards("ThrowMe", (other.transform.position - transform.position).normalized * 2f, SendMessageOptions.RequireReceiver);
        }
    }
}
