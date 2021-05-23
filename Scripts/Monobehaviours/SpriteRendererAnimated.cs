using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple Sprite Renderer animator. Set the sprites list and the speed to cycle between them.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererAnimated : MonoBehaviour
{
    public List<Sprite> Sprites;
    public float Speed;
    public bool Loop;

    private float timer;
    private int spriteIndex;

    private void Update()
    {
        if (!Loop && spriteIndex == Sprites.Count) return;
        if (Loop && spriteIndex == Sprites.Count) spriteIndex = 0;

        timer += Time.deltaTime;
        if (timer > (1 / Speed))
        {
            timer = 0;
            GetComponent<SpriteRenderer>().sprite = Sprites[spriteIndex];
            spriteIndex += 1;
        }
    }
}