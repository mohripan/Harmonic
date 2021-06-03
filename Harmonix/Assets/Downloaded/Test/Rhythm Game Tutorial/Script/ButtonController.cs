using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite pressedImage;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
