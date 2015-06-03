using UnityEngine;
using System.Collections;

public class IFlyable : MonoBehaviour {

    private Rigidbody _rigidbody;
    public ISquashable _squashReference;
    [HideInInspector] public bool IsFlying;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ThrowMe(Vector3 dir, float force)
    {
        dir = new Vector3(dir.x, Mathf.Abs(dir.y), dir.z);

        _squashReference.gameObject.SetActive(false);
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(dir.normalized * force, ForceMode.Impulse);
        IsFlying = true;
        SoundHandler.Instance.SpawnScreamEffect(transform);
        Destroy(this.gameObject, 5f);
    }
}
