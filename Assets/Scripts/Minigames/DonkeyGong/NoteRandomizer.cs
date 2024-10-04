using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRandomizer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer noteSprite;
    [SerializeField] private SpriteRenderer bubbleSprite;

    internal void SetNoteSprites(Sprite inputNoteSprite, Sprite inputBubbleSprite)
    {
        noteSprite.sprite = inputNoteSprite;
        bubbleSprite.sprite = inputBubbleSprite;
    }

}
