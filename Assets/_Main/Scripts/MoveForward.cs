using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float Speed = 5f;
    private Transform _transform;

	void Start () {
        _transform = transform;
	}

	void Update () {
        _transform.position += transform.forward * Time.deltaTime * Speed;
	}
}
