using UnityEngine;
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
        else if (GameManager.Instance.CanPlayAgain && other.gameObject.layer == Mathf.Log(GameManager.Instance.OnlyPlayButton, 2f))
        {
            GameManager.Instance.Play();
        }
        else
        {
            other.transform.SendMessageUpwards("ThrowMe", (other.transform.position - transform.position).normalized * 2f, SendMessageOptions.DontRequireReceiver);
        }
    }
}
