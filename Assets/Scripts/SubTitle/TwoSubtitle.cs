using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSubtitle : MonoBehaviour
{
    public AudioSource otherAudioSource; // Référence à l'AudioSource de l'autre objet

    public GameObject backgroundSubtitle;
    public GameObject subtitle1;
    public GameObject subtitle2;

    // Update is called once per frame
    void Update()
    {
        // Vérifie si l'autre AudioSource joue un son
        if (otherAudioSource.isPlaying)
        {
            StartCoroutine(ShowSubtitles());
        }
    }

    private bool isSubtitleActive = false;

    public IEnumerator ShowSubtitles()
    {
        if (isSubtitleActive) yield break; // Empêche la boucle involontaire
        isSubtitleActive = true;

        // Active les sous-titres un par un avec un délai de 5 secondes
        backgroundSubtitle.SetActive(true);
        subtitle1.SetActive(true);
        yield return new WaitForSeconds(5);

        subtitle1.SetActive(false);
        subtitle2.SetActive(true);
        yield return new WaitForSeconds(5);

        subtitle2.SetActive(false);
        backgroundSubtitle.SetActive(false);

        isSubtitleActive = false; // Reset du flag à la fin
    }
}
