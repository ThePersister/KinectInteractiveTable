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
        if (_squashReference.IsSquashed) return;
        IsFlying = true;

        dir = new Vector3(dir.x, Mathf.Abs(dir.y), dir.z);

        _squashReference.gameObject.SetActive(false);
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(dir.normalized * force, ForceMode.Impulse);
        SoundHandler.Instance.SpawnScreamEffect(transform);
        ScoreHandler.Instance.IncrementScore(2);
        Destroy(this.gameObject, 5f);
    }
}
