using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxVerticalVelocityConstraint : MonoBehaviour
{
    public float maxVerticalVelocity = 13f;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = maxVerticalVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.y) > maxVerticalVelocity)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Mathf.Sign(rigidbody2D.velocity.y) * maxVerticalVelocity);
    }
}
