using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    [SerializeField]
    private int _jumpForce;

    private SpriteRenderer _foundRenderer;

    private Animator _ArrowAnimator;
    private bool _collidedOnce = false;

    void Start()
    {
        _ArrowAnimator = this.transform.parent.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Make sure this only happens once
        if (_collidedOnce)
            return;
        Rigidbody2D collisionRb = collision.transform.GetComponent<Rigidbody2D>();

        if (!collisionRb)
            return;

        Vector2 force = new Vector2(0, _jumpForce);
        //Reset the y velocity, this is a safe check to avoid weird physics
        collisionRb.velocity = new Vector2(collisionRb.velocity.x, 0);
        collisionRb.AddForce(force, ForceMode2D.Impulse);
        _foundRenderer = collision.transform.GetComponent<SpriteRenderer>();

        //Make the arrow bop
        _ArrowAnimator.Play("FastArrow");

        SoundManager.Instance.PlaySound(SoundManager.Sounds.Jumppad);

        _collidedOnce = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _collidedOnce = false;
    }
}

