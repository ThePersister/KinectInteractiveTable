using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {

    public AudioClip PlaySound;
    public GameObject PlayButton;
    public LayerMask OnlyPlayButton;
    public Camera TableView;
    public List<SpawnModels> Spawners = new List<SpawnModels>();

    public Material MAT_PlayButton_Enabled;
    public Material MAT_PlayButton_Disabled;

    private Ray ray;
    private RaycastHit raycasthit;
    private bool isPlaying = false;
    public bool CanPlayAgain = true;

    private float cdPlayAgain = 3f;

    void Update()
    {
        if (CanPlayAgain && Input.GetMouseButtonDown(0))
        {
            ray = TableView.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycasthit, 10000f, OnlyPlayButton))
            {
                Play();
            }
        }
    }


    public void Play()
    {
        // Safety flag
        if (isPlaying) return;
        isPlaying = true;

        CanPlayAgain = false;
        SoundHandler.Instance.SpawnSound(PlayButton.transform.position, PlaySound);

        PlayButton.SetActive(false);
        ScoreHandler.Instance.HighlightScore(false);
        ScoreHandler.Instance.ResetScore();
        TimerHandler.Instance.SetPlay();

        foreach (SpawnModels spawner in Spawners)
        {
            spawner.StartSpawnCycle();
        }
    }

    public void Stop()
    {
        // Safety flag
        if (!isPlaying) return;
        isPlaying = false;
        
        PlayButton.SetActive(true);
        ScoreHandler.Instance.HighlightScore(true);

        foreach (SpawnModels spawner in Spawners)
        {
            spawner.StopSpawnCycle();
        }

        StartCoroutine(PlayAgainCooldown());
    }

    private IEnumerator PlayAgainCooldown()
    {
        PlayButton.GetComponent<MeshRenderer>().material = MAT_PlayButton_Disabled;
        yield return new WaitForSeconds(cdPlayAgain);
        CanPlayAgain = true;
        PlayButton.GetComponent<MeshRenderer>().material = MAT_PlayButton_Enabled;
    }
}
