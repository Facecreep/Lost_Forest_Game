using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : Activator
{
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private Sprite stateOnSprite;
    [SerializeField] private Sprite stateOffSprite;

    protected override void Start()
    {
        base.Start();

        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
            ChangeState();
        if (other.CompareTag("Player"))
            InputManager.Interact += ChangeState;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            InputManager.Interact -= ChangeState;
    }

    protected override void ChangeState()
    {
        base.ChangeState();
    }

    public override void Activate()
    {
        base.Activate();
        
        _spriteRenderer.sprite = stateOnSprite;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        
        _spriteRenderer.sprite = stateOffSprite;
    }
}