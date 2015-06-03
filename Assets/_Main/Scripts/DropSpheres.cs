using UnityEngine;
using System.Collections;

public class DropSpheres : MonoBehaviour {

    public Vector3 OffsetRange = new Vector3(10, 0, 0);
    public GameObject PFB_Sphere;

    void Start()
    {
        StartCoroutine(DropBallCycle());
    }

    private IEnumerator DropBallCycle()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject ball = (GameObject) Instantiate(PFB_Sphere, transform.position + Vector3.Lerp(Vector3.zero, OffsetRange, Random.value), Quaternion.identity);
        ball.transform.parent = transform;
        StartCoroutine(DropBallCycle());
    }
}
