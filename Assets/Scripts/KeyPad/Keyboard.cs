using UnityEngine;
using TMPro;
using System;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public AudioClip successClip; // Son de reussite
    public AudioClip failureClip; // Son d'echec
    public AudioSource audioSource; // Source audio
    public string correctCode;

    private int maxCodeLenght = 4;

    // Références aux murs
    public GameObject wallToDisable; // Mur à désactiver
    public GameObject wallToEnable;  // Mur à activer

    public GameObject triggerTaklDisable;
    public GameObject triggerTalkEnable;

    private bool hasTriggered = false;

    public void InsertChar(String c)
    {
        if (!hasTriggered)
        {
            if (inputField.text.Length < maxCodeLenght) // Limite à 4 caractères
            {
                inputField.text += c;
            }
        }
    }

    public void DeleteChar()
    {
        if (!hasTriggered)
        {
            if (inputField.text.Length > 0)
            {
                inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            }
        }
    }

    public void EnterCode()
    {
        if (!hasTriggered)
        {
            if (inputField.text == correctCode)
            {                           
                hasTriggered = true;

                // Code correct, jouer le son de reussite
                audioSource.PlayOneShot(successClip);

                // Désactiver un mur et activer l'autre
                wallToDisable.SetActive(false);
                wallToEnable.SetActive(true);

                triggerTaklDisable.SetActive(false);
                triggerTalkEnable.SetActive(true);
            }
            else
            {
                // Code incorrect, jouer le son d'échec et réinitialiser le clavier
                audioSource.PlayOneShot(failureClip);
                ResetKeypad();
            }               
        }
    }

    public void ResetKeypad()
    {
        inputField.text = string.Empty;
    }
}
