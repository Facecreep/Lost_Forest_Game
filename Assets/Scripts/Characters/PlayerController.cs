using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider2D;
    
    //Передвижение
    public float speed;
    private float _previousHorizontal;

    //Прыжок
    private enum JumpState { Grounded, Ascending, AboutToFall, Falling }
    private JumpState _jumpState;

    private float _maxVerticalVelocity;
    private float _jumpPoint;
    public float minJumpHeight;
    public float maxJumpHeight;
    
    //Взаимодействие
    public static Action Interact;

    //Start is called before the first frame update
    void Start()
    {
        _jumpState = JumpState.Grounded;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<BoxCollider2D>();

        _maxVerticalVelocity = GetComponent<MaxVerticalVelocityConstraint>().maxVerticalVelocity;
        _previousHorizontal = 0;

        InputManager.PlayerMove += Move;
        InputManager.PlayerJump += Jump;
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0)
                _jumpState = JumpState.Grounded;
        }
    }

    private void Move(float horizontal)
    {
        //Блок перемещение
        horizontal = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);

        //Блок вращение
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Jump()
    {
        float height = _rigidbody2D.position.y;

        if (_rigidbody2D.velocity.y <= 0)
            _jumpState = JumpState.Falling;

        if (Input.GetButtonDown("Jump"))
        {
            int layerMask = 1 << LayerMask.NameToLayer("Tile") | 1 << LayerMask.NameToLayer("Platform");

            Vector2 raycastDirection = new Vector2(0, -1f);
            Vector2 leftBottomPoint = (Vector2)transform.position + new Vector2(-_collider2D.size.x / 2, -_collider2D.size.y / 2);
            Vector2 rightBottomPoint = (Vector2)transform.position + new Vector2(_collider2D.size.x / 2, -_collider2D.size.y / 2);
            RaycastHit2D leftRay = Physics2D.Raycast(leftBottomPoint, raycastDirection, 0.04f, layerMask);
            RaycastHit2D rightRay = Physics2D.Raycast(rightBottomPoint, raycastDirection, 0.04f, layerMask);

            if (rightRay || leftRay || _jumpState == JumpState.Grounded)
            {
                if(Input.GetAxisRaw("Vertical") < 0)
                {
                    if (rightRay && rightRay.collider.gameObject.tag == "Platform")
                        rightRay.collider.enabled = false;
                    if (leftRay && leftRay.collider.gameObject.tag == "Platform")
                        leftRay.collider.enabled = false;
                }
                else
                {
                    _rigidbody2D.AddForce(new Vector2(0, 1) * _maxVerticalVelocity, ForceMode2D.Impulse);
                    _jumpPoint = _rigidbody2D.position.y;
                    _jumpState = JumpState.Ascending;
                }
            }
        }

        if (Input.GetButton("Jump"))
        {
            if (_jumpState == JumpState.Ascending)
            {
                if (height - _jumpPoint >= maxJumpHeight)
                    _jumpState = JumpState.Falling;

                _rigidbody2D.AddForce(new Vector2(0, 1) * _rigidbody2D.gravityScale * (Physics2D.gravity * -1));
            }
        }

        if (_jumpState == JumpState.AboutToFall)
        {
            if (height - _jumpPoint >= minJumpHeight)
                _jumpState = JumpState.Falling;
            else
                _rigidbody2D.AddForce(new Vector2(0, 1) * _rigidbody2D.gravityScale * (Physics2D.gravity * -1));
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (height - _jumpPoint <= minJumpHeight && _jumpState != JumpState.Falling)
                _jumpState = JumpState.AboutToFall;
            else
                _jumpState = JumpState.Falling;
        }
    }
}
