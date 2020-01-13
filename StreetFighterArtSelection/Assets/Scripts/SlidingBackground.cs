using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBackground : MonoBehaviour
{
    public float scrollSpeed;

    private Vector2 savedOffset;

    private void Start()
    {
    }

    private void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(y, 0);
        transform.position = offset;
    }
}
