using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float Speed = 5f;
    private IEnemy _enemy;
    private Transform _transform;

	void Start () {
        _transform = transform;
        _enemy = GetComponent<IEnemy>();
	}

	void Update () {
        if (!_enemy.IsFlying && !_enemy.IsSquashed)
            _transform.position += transform.forward * Time.deltaTime * Speed;
	}
}
