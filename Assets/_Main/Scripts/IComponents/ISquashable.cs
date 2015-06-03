using UnityEngine;
using System.Collections;

public class ISquashable : MonoBehaviour {

    public GameObject BoundEnemy;
    [HideInInspector] public bool IsSquashed;

    public void SquashMe()
    {
        IsSquashed = true;

        SoundHandler.Instance.SpawnSquashSound(BoundEnemy.transform.position);

        // Flatten the enemy
        Vector3 s = BoundEnemy.transform.localScale;
        BoundEnemy.transform.localScale = new Vector3(s.x, s.y / 10f, s.z);

        gameObject.SetActive(false);
    }
}
