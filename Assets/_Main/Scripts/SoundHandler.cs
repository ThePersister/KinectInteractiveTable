using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundHandler : Singleton<SoundHandler> {

    public GameObject PFB_SquashSound;
    public GameObject PFB_ScreamSound;
    public List<AudioClip> ScreamSoundclips = new List<AudioClip>();

    public void SpawnSquashSound(Vector3 enemyPos)
    {
        GameObject newSound = (GameObject) Instantiate(PFB_SquashSound, enemyPos, Quaternion.identity);
        newSound.transform.parent = this.transform;
        AudioSource source = newSound.GetComponent<AudioSource>();
        Destroy(newSound, source.clip.length);
    }

    public void SpawnScreamEffect(Transform targetParent)
    {
        // Spawn a new Sound holder at the correct spawn position, spawn rotation with the right clip.
        // Then play the clip and destroy the gameobject after it's done playing.
        GameObject newSound = (GameObject)Instantiate(PFB_ScreamSound, targetParent.position, Quaternion.identity);
        newSound.transform.parent = targetParent;
        AudioSource source = newSound.GetComponent<AudioSource>();
        source.clip = GetRandomScream();
        Destroy(newSound, source.clip.length);
    }

    private AudioClip GetRandomScream()
    {
        int test = Mathf.RoundToInt(Random.value * (ScreamSoundclips.Count - 1));
        return ScreamSoundclips[test];
    }
}
