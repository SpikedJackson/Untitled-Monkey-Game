using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Animator _animator;
    private SpriteRenderer _renderer;
    [SerializeField]
    private bool canClimb = false;
    public int maxVelocity;
    public Transform _position;
    public AudioSource jumpAudio;
    private bool _onGround;
   
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _position = GetComponent<Transform>();
        Relocate(new Vector3(-3.5f, -0.6f, 0));
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // change movement animations
        if (horizontalInput == 0)
        {
            _animator.SetBool("walking", false);
        } else
        {
            _animator.SetBool("walking", true);
            if ((horizontalInput > 0 && canClimb == false) || (horizontalInput < 0 && canClimb == true))
            {
                _renderer.flipX = false;
            } else
            {
                _renderer.flipX = true;
            }
        }

        // gravity only affects y value
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
        if (_rigid.velocity.y == 0)
        {
            _rigid.velocity = new Vector2(horizontalInput, verticalInput * 2);
            _onGround = true;

        }
        // stick to vine
        if (canClimb && verticalInput == 0)
        {
            _rigid.velocity = new Vector2(horizontalInput, 0);
        }
        // max velocity limit
        if (Math.Abs(_rigid.velocity.y) > maxVelocity)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _rigid.velocity.y * 0.95f);
        }
        // falls off map
        if (transform.position.y < (-5))
            GameManager.instance.Restart_Level();
        if (Input.GetKey(KeyCode.UpArrow) && _onGround && canClimb == false)
        {
            jumpAudio.Play();
            _onGround = false;
        }
    }
    public void ClimbToggle() // Callable function of player that the vine uses to allow the player to use vines
    {
        if (canClimb) // In the event you're leaving the vine, this resets you so you don't float.
        {
            canClimb = false;
            _animator.SetBool("climbing", false);
            _rigid.gravityScale = 0.5f;
        }
        else //This is the effect of the vine. Dead stop so you don't skyrocket or plummet through the vine. Gravity of 0 to simulate sticking to the vine.
        {
            canClimb = true;
            _animator.SetBool("climbing", true);
            _rigid.velocity = new Vector2(0, 0);
            _rigid.gravityScale = 0f;

        }
    }
    public void Relocate(Vector3 pos)
    {
        this.transform.position = pos;
    }    
}
