using UnityEngine;
using System.Collections;

public class TriggerTalkFinal : MonoBehaviour
{
    public GameObject character;              // Référence à l'objet qui a l'Animator
    public AudioSource voiceClipSource;       // Le composant AudioSource pour la voix
    public string animationName = "speaking"; // Nom de l'animation

    public AudioClip voiceClip;                // Le clip audio unique à jouer
    public string clipToPlay; // Nom du clip à jouer (pour référence)

    public GameObject triggerToDesable;

    private Animator characterAnimator;        // Pour stocker la référence à l'Animator
    private bool isPlaying = false;

    void Start()
    {
        // Récupère le composant Animator de l'objet spécifié
        characterAnimator = character.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui entre dans la zone
        if (other.CompareTag("Player") && !isPlaying)
        {
            // Joue le clip audio
            if (voiceClip != null)
            {
                triggerToDesable.SetActive(false);
                characterAnimator.Play(animationName);
                voiceClipSource.clip = voiceClip;
                voiceClipSource.Play();
                isPlaying = true;

                // Appelle une fonction pour arrêter l'animation lorsque le son est terminé
                StartCoroutine(StopAnimationWhenAudioEnds(voiceClip.length));
            }
            else
            {
                Debug.LogWarning("Le clip audio spécifié n'est pas assigné.");
            }
        }
    }

    IEnumerator StopAnimationWhenAudioEnds(float clipLength)
    {
        // Attend la durée du clip
        yield return new WaitForSeconds(clipLength);
        
        // Arrête l'animation
        characterAnimator.Play("Idle"); // Remplace "Idle" par une animation neutre si besoin
        isPlaying = false;
    }
}
