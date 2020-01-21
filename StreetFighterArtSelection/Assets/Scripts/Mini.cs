using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini : MonoBehaviour
{
    public string characterName;
    public string[] artistInstagrams;
    public Sprite[] sprites;
    public GameObject container;

    private int spriteIndex = 0;
    private Animator animator;

    private void Start()
    {
        animator = container.GetComponent<Animator>();
    }

    public void Reset()
    {
        spriteIndex = 0;
    }

    private int NextSprite()
    {
        int index = spriteIndex++;
        if (sprites.Length == spriteIndex)
        {
            spriteIndex = 0;
        }

        return index;
    }

    public void OnClick()
    {
        Debug.Log("OnClick: " + characterName);
        animator.SetBool("play", true);
        GameController.Instance.SetCharacterSelected(this, NextSprite());
    }

    public void PlayIdle()
    {
        animator.SetBool("play", false);
    }
}
