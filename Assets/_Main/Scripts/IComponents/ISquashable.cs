using UnityEngine;
using System.Collections;

public class ISquashable : MonoBehaviour {

    public IEnemy EnemyReference;

    public void SquashMe()
    {
        // Can't do either twice or AND.
        if (EnemyReference.IsFlying || EnemyReference.IsSquashed) return;

        // Toggle to true
        EnemyReference.IsSquashed = true;

        // Sound and score
        SoundHandler.Instance.SpawnSquashSound(EnemyReference.transform.position);
        ScoreHandler.Instance.IncrementScore(5);

        // Flatten the enemy
        Vector3 s = EnemyReference.transform.localScale;
        EnemyReference.transform.localScale = new Vector3(s.x, s.y / 10f, s.z);

        // Die and fade, make the color red, and deactivate this squash collider so it can't be hit again.
        EnemyReference.DieAndFade();
        EnemyReference.SetColor(Color.red);
        gameObject.SetActive(false);
    }

    //private void SetAllRenderers(Color c)
    //{
    //    if (mRenderers == null) return;

    //    if (mSkinnedMeshRenderer)
    //    {
    //        mSkinnedMeshRenderer.material.SetColor("_Color", Color.red);
    //    }
    //    else
    //    {
    //        foreach (MeshRenderer renderer in mRenderers)
    //        {
    //            renderer.material.SetColor("_Color", Color.red);
    //        }
    //        //SetColorAndReturn(BoundEnemy.transform);
    //    }
    //}

    //private void SetColorAndReturn(Transform parent)
    //{
    //    mRenderer = parent.GetComponent<MeshRenderer>();
    //    if (mRenderer) mRenderer.material.SetColor("_Color", Color.red);

    //    foreach (Transform trans in parent)
    //    {
    //        SetColorAndReturn(trans);
    //    }
    //}
}
