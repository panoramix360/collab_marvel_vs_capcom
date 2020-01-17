using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingBackground : MonoBehaviour
{
    public float scrollSpeed;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.material.mainTextureOffset = new Vector2(0f, Time.time * scrollSpeed);
    }
}
