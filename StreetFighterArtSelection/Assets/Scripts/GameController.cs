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

    public GameObject dhalsim;
    public GameObject gambit;

    public GameObject audio;
    public string[] musics;
    private AudioClip currentAudio;
    private int musicIndex = 0;

    private Mini characterSelected;
    private bool firstTimeClicked = true;

    private void Start()
    {
        currentAudio = audio.GetComponent<AudioSource>().clip;
    }

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

        string dhalsimArtist = "@taj_tajima";
        string gambitArtist = "@byulabyu";
        string currentInstagramArtist = characterSelected.artistInstagrams[spriteIndex];
        if (currentInstagramArtist == dhalsimArtist || currentInstagramArtist == gambitArtist)
        {
            if (currentInstagramArtist == dhalsimArtist)
            {
                dhalsim.SetActive(true);
            } else
            {
                gambit.SetActive(true);
            }
            characterImage.gameObject.SetActive(false);
        }
        else
        {
            dhalsim.SetActive(false);
            gambit.SetActive(false);
            characterImage.gameObject.SetActive(true);
        }

        characterImage.sprite = characterSelected.sprites[spriteIndex];
        characterName.text = characterSelected.characterName;
        artistInstagram.text = currentInstagramArtist;
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
            Resources.UnloadAsset(currentAudio);
            currentAudio = Resources.Load<AudioClip>(musics[musicIndex]);
            audioSource.clip = currentAudio;
        }
        audioSource.Play();
    }

    public void StopMusic()
    {
        AudioSource audioSource = audio.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
