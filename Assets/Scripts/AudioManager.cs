using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null; // Singleton instance
    public Slider volumeSlider; // Référence au slider (facultatif si tu l'utilises dans une scene specifique)
    private float currentVolume = 1f; // Volume par défaut

    void Awake()
    {
        // Singleton pattern pour eviter d'avoir plusieur instance du gestionnaire
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garde cet objet quand la scene charge
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Si une autre instaznce existe deja, on la detruit
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Charger le volume sauvegarde
        currentVolume = PlayerPrefs.GetFloat("Volume", 1f);
        ApplyVolumeToAllAudioSource(currentVolume);

        // Si un slider est lie, initialiser et ecouter ses changement
        if (volumeSlider != null)
        {
            volumeSlider.value = currentVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        currentVolume = volume;
        ApplyVolumeToAllAudioSource(volume);
        PlayerPrefs.SetFloat("Volume", volume); // Sauvegarde les preference de volume
    }

    private void ApplyVolumeToAllAudioSource(float volume)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }

    public void OnSceneChanged()
    {
        ApplyVolumeToAllAudioSource(currentVolume);
    }
}
