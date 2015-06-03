using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float Speed = 5f;
    private Transform _transform;
    private IFlyable _flyable;
    public ISquashable _squasable;

	void Start () {
        _transform = transform;
        _flyable = GetComponent<IFlyable>();
	}

	void Update () {
        if (!_flyable.IsFlying && !_squasable.IsSquashed)
            _transform.position += transform.forward * Time.deltaTime * Speed;
	}
}
