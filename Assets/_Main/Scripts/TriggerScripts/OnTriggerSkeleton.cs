using UnityEngine;
using System.Collections;

public class OnTriggerSkeleton : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Squash"))
        {
            other.GetComponentInChildren<ISquashable>().SquashMe();
        }
        else
        {
            if(other.transform.parent.GetComponent<IFlyable>())
                other.transform.parent.GetComponent<IFlyable>().ThrowMe((other.transform.position - transform.position).normalized, 2f);
        }
    }
}
