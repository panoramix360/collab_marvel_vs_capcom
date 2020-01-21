using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public Image characterImage;
    public Text characterName;
    public Text artistInstagram;

    public GameObject audio;
    public AudioClip[] musics;
    private int musicIndex = 0;

    private Mini characterSelected;

    public void SetCharacterSelected(Mini characterToSelect)
    {
        if (characterSelected != null)
        {
            if (characterSelected.characterName == characterToSelect.characterName)
            {
                return;
            }
            characterSelected.PlayIdle();
        }

        characterSelected = characterToSelect;

        characterImage.sprite = characterSelected.image.GetComponent<Image>().sprite;
        characterName.text = characterSelected.characterName;
        artistInstagram.text = characterSelected.artistInstagram;
    }

    public void NextMusic()
    {
        musicIndex++;
        if (musics.Length == musicIndex)
        {
            musicIndex = 0;
        }

        AudioSource audioSource = audio.GetComponent<AudioSource>();
        audioSource.clip = musics[musicIndex];
        audioSource.Play();
    }
}
