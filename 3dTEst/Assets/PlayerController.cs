
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D _rb;
    private bool _fasingRight = false;
    private Animator _anim;
    public LayerMask WhatIsGrounded;
    public Transform FeetPos;
    public float Jump;
    private bool _isGroundedCheck;
    public float CheckRadius;
    private float _moveInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    
    void Update()
    {   
        


      
    
        


        if(_moveInput > 0 && _fasingRight == true)
        {
            Flip();
        }
        else if(_moveInput < 0 && _fasingRight == false)
        {
            Flip();
        }

        if(_moveInput > 0 || _moveInput < 0)
        {
            _anim.SetBool("_isRun" , true);
        }
        else if(_moveInput == 0)
        {
            _anim.SetBool("_isRun" , false);
        }
}
    void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveInput * Speed , _rb.velocity.y);
    
    
    _isGroundedCheck = Physics2D.OverlapCircle(FeetPos.position , CheckRadius , WhatIsGrounded);
        if(_isGroundedCheck == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * Jump;
            _anim.SetBool("_isJump" , true);
            Debug.Log("JUMP!");

            
        }
        if(_isGroundedCheck == false)
            {
                 _anim.SetBool("_isJump" , false);
            }
    }



    void Flip()
    {   
        _fasingRight = !_fasingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *=-1;
        transform.localScale = Scaler;
    }
}
