using UnityEngine;
using System.Collections;

public class ISquashable : MonoBehaviour {

    public GameObject BoundEnemy;
    [HideInInspector] public bool IsSquashed;
    public MeshRenderer[] mRenderers;
    private MeshRenderer mRenderer;

    public void SquashMe()
    {
        if (!BoundEnemy.GetComponent<IFlyable>().IsFlying) return;

        IsSquashed = true;

        SoundHandler.Instance.SpawnSquashSound(BoundEnemy.transform.position);
        ScoreHandler.Instance.IncrementScore(5);

        // Flatten the enemy
        Vector3 s = BoundEnemy.transform.localScale;
        BoundEnemy.transform.localScale = new Vector3(s.x, s.y / 10f, s.z);

        gameObject.SetActive(false);
        SetAllRenderers(Color.red);
        Destroy(this.gameObject, 5f);
    }

    private void SetAllRenderers(Color c)
    {
        if (mRenderers == null) return;

        foreach(MeshRenderer renderer in mRenderers)
        {
            renderer.material.SetColor("_Color", Color.red);
        }
        //SetColorAndReturn(BoundEnemy.transform);
    }

    private void SetColorAndReturn(Transform parent)
    {
        mRenderer = parent.GetComponent<MeshRenderer>();
        if (mRenderer) mRenderer.material.SetColor("_Color", Color.red);

        foreach (Transform trans in parent)
        {
            SetColorAndReturn(trans);
        }
    }
}
