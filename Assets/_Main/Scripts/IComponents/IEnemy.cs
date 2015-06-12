using UnityEngine;
using System.Collections;

public class IEnemy : MonoBehaviour {

    public bool IsSquashed;
    public bool IsFlying;
    private bool isDying;

    private float fadeTimerMax = 3f;
    private float fadeTimerCur = 0f;

    private float scaleMin = 0.008f;
    private float scaleMax = 0.015f;

    // References
    public ISquashable SqaushReference;
    public IFlyable FlyReference;

    // Components
    private SkinnedMeshRenderer mSkinnedMeshRenderer;
    private Animator mAnimator;

    void Start()
    {
        // Set private Components
        mSkinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        mAnimator = GetComponentInChildren<Animator>();

        // Set Random Scale
        float scale = Random.Range(scaleMin, scaleMax);
        transform.GetChild(0).localScale = new Vector3(scale, scale, scale);
    }

    // Change color if renderer is not null
    public void SetColor(Color colorToSet)
    {
        if (mSkinnedMeshRenderer) mSkinnedMeshRenderer.material.SetColor("_Color", colorToSet);
    }

    public void SetFlyAndDie()
    {
        mAnimator.SetTrigger("Fly");
        Invoke("DieAndFade", 1f);
    }

    public void DieAndFade()
    {
        mAnimator.SetTrigger("Die");

        // Flag here so we don't die twice, just in case.
        if (isDying) return;
        isDying = true;

        StartCoroutine(DieAndFadeActual());
    }

    private IEnumerator DieAndFadeActual()
    {
        yield return new WaitForEndOfFrame();
        fadeTimerCur += Time.deltaTime;

        Color curColor = mSkinnedMeshRenderer.material.color;
        SetColor(Color.Lerp(curColor, new Color(curColor.r, curColor.g, curColor.b, 0), fadeTimerCur / fadeTimerMax));

        if (fadeTimerCur >= fadeTimerMax)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            StartCoroutine(DieAndFadeActual());
        }
    }
}
