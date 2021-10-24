using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 100f;
    [SerializeField]
    private float _jumpHeight = 2;

    [SerializeField]
    private LayerMask _ground;

    [SerializeField] 
    private Transform m_GroundCheck;

    private bool _isGrounded = false;
    private const float _groundedRadius = .2f;
    private Vector2 _newVelocity;
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;
    private Collider2D[] _colliders = new Collider2D[50];

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Jump();
        Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();
        CheckGrounded();
    }

    void HandleInput()
    {
        //Move the player left or right
        float horizontalInput = Input.GetAxis("Horizontal") * _speed;
        float vertical = _rb.velocity.y;
        _newVelocity = new Vector2(horizontalInput, vertical);
        _rb.velocity = _newVelocity;
    }

    void Jump()
    {
        //Can only jump if the player is grounded again
        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            //Reset the y velocity, this is a safe check to avoid weird physics,
            //along with giving the possible future opertunity to add double jumps or mid air jumps 
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            Vector2 jumpForce = new Vector2(0, _jumpHeight);
            _rb.AddForce(jumpForce, ForceMode2D.Impulse);
            SoundManager.Instance.PlaySound(SoundManager.Sounds.Jump);
        }
    }

    void Flip()
    {
        //Check the current velocity of the player 
        //to make sure the sprite needs to be flipped or not
        if(_rb.velocity.x < 0)
            _spriteRenderer.flipX = true;
        else if(_rb.velocity.x > 0)
            _spriteRenderer.flipX = false;
    }

    void CheckGrounded()
    {
        //Credit to Brackeys on Youtube for this implementation of ground check, I did optimize it after feedback from Brecht
        bool wasGrounded = _isGrounded;
        _isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        int hitcount = Physics2D.OverlapCircleNonAlloc(m_GroundCheck.position, _groundedRadius ,_colliders, _ground);
        for (int i = 0; i < hitcount; i++)
        {
            if (_colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }
    }
}
