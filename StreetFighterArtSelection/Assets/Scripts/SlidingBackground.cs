using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingBackground : MonoBehaviour
{
    public float scrollSpeed;
    public Renderer renderer;

    private void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }
}
