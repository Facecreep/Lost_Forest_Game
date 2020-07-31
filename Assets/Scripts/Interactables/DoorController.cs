using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activatable
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

    protected override void ChangeState()
    {
        base.ChangeState();
    }

    public override void Activate()
    {
        _spriteRenderer.sprite = stateOnSprite;
        _boxCollider2D.enabled = false;
    }

    public override void Deactivate()
    {
        _spriteRenderer.sprite = stateOffSprite;
        _boxCollider2D.enabled = true;
    }
}
