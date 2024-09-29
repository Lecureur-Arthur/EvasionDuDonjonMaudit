using UnityEngine;
using TMPro;
using System;

public class Keyboard : MonoBehaviour
{

    public TMP_InputField inputField;
    public AudioClip successClip; // Son de reussite
    public AudioClip failureClip; // Son d'echec
    public AudioSource audioSource; // Source audio
    public string correctCode = "1234";

    private int maxCodeLenght = 4;

    public void InsertChar(String c)
    {
        if (inputField.text.Length < 4) // Limite a 4 caracteres
        {
            inputField.text += c;
        }
    }

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public void EnterCode()
    {
        if (inputField.text == correctCode)
        {
            // Code correct, jouer le son de reussite
            audioSource.PlayOneShot(successClip);
        }
        else
        {
            // Code incorrect, jouer le son d'échec et réinitialiser le clavier
            audioSource.PlayOneShot(failureClip);
            ResetKeypad();
        }
    }

    public void ResetKeypad()
    {
        inputField.text = string.Empty;
    }
}
