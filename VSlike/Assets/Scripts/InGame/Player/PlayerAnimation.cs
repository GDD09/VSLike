using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    enum AnimationType {
        Idle,
        WalkL,
        WalkR,
    }

    readonly float animationBaseSpeed = 4f;
    SpriteRenderer spriteRenderer;

    [SerializeField] Sprite[] idleSprites;
    [SerializeField] Sprite[] walkLSprites;
    [SerializeField] Sprite[] walkRSprites;
    [SerializeField] AnimationType currentAnimation = AnimationType.Idle;
    [SerializeField] float animationSpeed = 1f;

    float animationTimer = 0f;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        animationTimer += Time.deltaTime * animationSpeed * animationBaseSpeed;
        switch (currentAnimation)
        {
            case AnimationType.Idle:
                UpdateSprite(idleSprites);
                break;
            case AnimationType.WalkL:
                UpdateSprite(walkLSprites);
                break;
            case AnimationType.WalkR:
                UpdateSprite(walkRSprites);
                break;
        }
    }

    // This method is to be called by `PlayerMovement`.
    void OnMove(Vector2 movement)
    {
        AnimationType newAnimation;
        if (movement == Vector2.zero)
        {
            newAnimation = AnimationType.Idle;
        }
        else if (movement.x > 0)
        {
            newAnimation = AnimationType.WalkR;
            animationSpeed = movement.magnitude;
        }
        else
        {
            // TODO: need up/down move animations
            newAnimation = AnimationType.WalkL;
            animationSpeed = movement.magnitude;
        }

        if (currentAnimation != newAnimation)
        {
            StartAnimation(newAnimation);
        }
    }


    void StartAnimation(AnimationType animation)
    {
        currentAnimation = animation;
        animationTimer = 0f;
    }

    void UpdateSprite(Sprite[] sprites) {
        if (sprites.Length == 0) { return; }

        int index = Mathf.FloorToInt(animationTimer) % sprites.Length;
        var sprite = sprites[index];

        if (spriteRenderer.sprite != sprite) {
            spriteRenderer.sprite = sprite;
        }
    }
}
