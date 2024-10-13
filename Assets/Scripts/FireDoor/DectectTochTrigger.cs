using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectTochTrigger : MonoBehaviour
{
    // Références aux murs
    public GameObject wallToDisable; // Mur à désactiver
    public GameObject wallToEnable;  // Mur à activer

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch")
        {
            // Animation du feux pendant 3 seconde
            
            // Sons de feux pendant 3 seconde

            // Désactiver un mur et activer l'autre
            wallToDisable.SetActive(false);
            wallToEnable.SetActive(true);
        }
    }
}
