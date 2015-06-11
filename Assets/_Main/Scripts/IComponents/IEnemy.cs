using UnityEngine;
using System.Collections;

public class IEnemy : MonoBehaviour {

    public bool IsSquashed;
    public bool IsFlying;

    private float fadeTimerMax = 5f;
    private float fadeTimerCur = 0f;

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
    }

    // Change color if renderer is not null
    public void SetColor(Color colorToSet)
    {
        if (mSkinnedMeshRenderer) mSkinnedMeshRenderer.material.SetColor("_Color", colorToSet);
    }

    public void DieAndFade()
    {
        mAnimator.SetTrigger("Die");
        StartCoroutine(DieAndFadeActual());
    }

    private IEnumerator DieAndFadeActual()
    {
        fadeTimerCur += Time.deltaTime;
        yield return new WaitForEndOfFrame();

        Color curColor = mSkinnedMeshRenderer.material.color;
        SetColor(Color.Lerp(curColor, new Color(curColor.r, curColor.g, curColor.b, 0), fadeTimerCur / fadeTimerMax));

        if (fadeTimerCur >= fadeTimerMax)
        {
            Destroy(this.gameObject, fadeTimerMax);
        }
        else
        {
            StartCoroutine(DieAndFadeActual());
        }
    }
}
