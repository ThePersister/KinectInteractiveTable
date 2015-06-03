using UnityEngine;
using System.Collections;

public class PFB_Sphere : MonoBehaviour
{

    // this.gameObject is being pooled.
    // Name of the Pool should fit, if not, create a new one properly.
    void Awake()
    {
        transform.parent = PFB_Sphere_Pool.Instance.transform;
        this.gameObject.SetActive(false);
    }


    private float timer_Current;
    private float timer_Max = 5;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SelfDestructIn(3));
    }

    void Update()
    {
        timer_Current += Time.deltaTime;
        if (timer_Current > timer_Max)
        {
            PFB_Sphere_Pool.Instance.Pool.Add(gameObject);
            timer_Current = 0;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator SelfDestructIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        PFB_Sphere_Pool.Instance.Pool.Add(gameObject);
        gameObject.SetActive(false);
    }
}
