using UnityEngine;
using System.Collections;

public class IFlyable : MonoBehaviour {

    public IEnemy EnemyReference;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ThrowMe(Vector3 force)
    {
        // Toggle flag if not done before
        if (EnemyReference.IsSquashed || EnemyReference.IsFlying) return;
        EnemyReference.IsFlying = true;

        // Deactivate Squash System
        EnemyReference.SqaushReference.gameObject.SetActive(false);

        // Calculate direction
        force = new Vector3(force.x, Mathf.Abs(force.y), force.z);

        // Update rigidbody and apply force.
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(force, ForceMode.Impulse);

        // Spawn sound effect and increment score.
        SoundHandler.Instance.SpawnScreamEffect(transform);
        ScoreHandler.Instance.IncrementScore(2);

        // Set Fly and Death animations.
        EnemyReference.SetFlyAndDie();
    }
}
