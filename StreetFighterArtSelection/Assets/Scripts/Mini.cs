using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini : MonoBehaviour
{
    public string characterName;
    public string artistInstagram;
    public GameObject image;
    public GameObject container;

    private Animator animator;

    private void Start()
    {
        animator = container.GetComponent<Animator>();
    }

    public void OnClick()
    {
        Debug.Log("OnClick: " + characterName);
        animator.SetBool("play", true);
        GameController.Instance.SetCharacterSelected(this);
    }

    public void PlayIdle()
    {
        animator.SetBool("play", false);
    }
}
