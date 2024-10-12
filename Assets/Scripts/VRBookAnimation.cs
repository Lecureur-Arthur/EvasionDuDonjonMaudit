using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRBookAnimation : MonoBehaviour
{
    public InputActionProperty primaryButtonAction;  // Action du bouton principal (X)
    public InputActionProperty secondaryButtonAction; // Action du bouton secondaire (Y)
    public Animator bookAnimator;                    // Référence à l'Animator du livre

    void Update()
    {
        // Vérifie si le bouton principal (X) est pressé
        if (primaryButtonAction.action.ReadValue<float>() > 0)
        {
            // Lancer l'animation pour ouvrir le livre
            bookAnimator.SetTrigger("OpenBook");
        }

        // Vérifie si le bouton secondaire (Y) est pressé
        if (secondaryButtonAction.action.ReadValue<float>() > 0)
        {
            // Lancer l'animation pour fermer le livre
            bookAnimator.SetTrigger("CloseBook");
        }
    }
}
