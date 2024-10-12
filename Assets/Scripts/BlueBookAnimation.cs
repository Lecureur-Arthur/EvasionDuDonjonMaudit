using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BlueBookAnimation : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Récupérer le composant Animator
        animator = GetComponent<Animator>();

        // Récupérer le composant XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Abonner aux événements "select" et "deselect" pour déclencher l'animation
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        // Message de debug pour confirmer que tout est en place
        Debug.Log("BlueBookAnimation script initialized.");
    }

    // Méthode pour lancer l'animation lorsque l'objet est attrapé
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed!");
        if (animator != null)
        {
            animator.SetBool("isGrabbed", true); // Assurez-vous d'avoir un paramètre booléen "isGrabbed" dans l'Animator
        }
        else
        {
            Debug.LogError("Animator is missing!");
        }
    }

    // Méthode pour arrêter l'animation ou la changer lorsque l'objet est relâché (si nécessaire)
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released!");
        if (animator != null)
        {
            animator.SetBool("isGrabbed", false);
        }
    }
}
