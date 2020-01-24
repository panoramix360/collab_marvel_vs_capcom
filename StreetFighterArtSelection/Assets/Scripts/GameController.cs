using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public Image characterImage;
    public GameObject capa;
    public Text characterName;
    public Text artistInstagram;

    public GameObject audio;
    public AudioClip[] musics;
    private int musicIndex = 0;

    private Mini characterSelected;
    private bool firstTimeClicked = true;

    public void SetCharacterSelected(Mini characterToSelect, int spriteIndex)
    {
        if (firstTimeClicked)
        {
            characterImage.gameObject.SetActive(true);
            Destroy(capa);
        }

        if (characterSelected != null && characterSelected.characterName != characterToSelect.characterName)
        {
            characterSelected.PlayIdle();
            characterSelected.Reset();
        }

        characterSelected = characterToSelect;

        characterImage.sprite = characterSelected.sprites[spriteIndex];
        characterName.text = characterSelected.characterName;
        artistInstagram.text = characterSelected.artistInstagrams[spriteIndex];
    }

    public void NextMusic()
    {
        musicIndex++;
        if (musics.Length == musicIndex)
        {
            musicIndex = 0;
        }

        AudioSource audioSource = audio.GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.clip = musics[musicIndex];
        }
        audioSource.Play();
    }

    public void StopMusic()
    {
        AudioSource audioSource = audio.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
