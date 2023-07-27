using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic Data")]
    public float speed;
    public float JumpForce;
    public float hitForce;
    public bool isHit = false;
    private bool isRush;
    public float RushTimeCounter;
    public float coolTime;
    public Rigidbody2D rb;
    public bool RushAble;
    public InputNeon input;
    public Vector2 InputDirec;
    public PhysicsCheck physicsCheck;
    public SpriteRenderer spriteRenderer_Weapon;
    public Drink drink;
    public Animator animator;
    public bool isDoubleJump = false;
    public float DiffBtwMouseandPlayer;
    public bool FacingRight = true;
    private int FacDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new InputNeon();
        coolTime = -1;
        input.Player.Jump.started += Jump;
        input.Player.Rush.started += Rush;
        drink.GetComponent<Drink>();
        animator.GetComponent<Animator>();
    }



    private void FixedUpdate()
    {
        InputDirec = input.Player.Move.ReadValue<Vector2>();
        if (!isHit && !isRush)
        {
            Move();
            Flip();
            CheckDiff();
        }
    }
    private void Update()
    {
        if (coolTime >= 0)
        {
            RushTimeCounter -= Time.deltaTime;
            coolTime -= Time.deltaTime;
        }
        if (RushTimeCounter < 0)
        {
            isRush = false;
            rb.gravityScale = 1;
        }
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Move()
    {
        rb.velocity = new Vector2(InputDirec.x * speed * Time.deltaTime, rb.velocity.y);
    }
    private void Rush(InputAction.CallbackContext context)
    {
        if (RushAble)
        {   
            if (FacingRight == true)
            {
                FacDir = 1;
            }
            if (FacingRight == false)
            {
                FacDir = -1;
            }
            if (coolTime < 0)
            {
                RushTimeCounter = 0.6f;
                if (RushTimeCounter >= 0)
                {
                    rb.gravityScale = 0;
                    rb.velocity = new Vector2(FacDir * 12f, 0f);
                    animator.SetTrigger("isRush");
                }
                coolTime = 1f;
                isRush = true;
            }
        }
    }
    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
        if (drink.isDoubleJump == true)
        {
            if (!physicsCheck.isGround && isDoubleJump == false)
            {
                rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
                isDoubleJump = true;
            }
        }
    }
    private void Flip()
    {
        if (DiffBtwMouseandPlayer < 0 && FacingRight == true)
        {
            transform.Rotate(0, 180, 0);
            FacingRight = false;
            spriteRenderer_Weapon.flipX = true;
        }
        if (DiffBtwMouseandPlayer > 0 && FacingRight == false)
        {
            transform.Rotate(0, 180, 0);
            FacingRight = true;
            spriteRenderer_Weapon.flipX = false;
        }
    }
    private void CheckDiff()
    {
        DiffBtwMouseandPlayer = Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x; ;
    }
    public void OnHitPlayer(Transform attacker)
    {
        rb.velocity = Vector2.zero;
        Vector2 hitDir = new Vector2(transform.position.x - attacker.position.x, 0).normalized;
        rb.AddForce(hitDir * hitForce, ForceMode2D.Impulse);
        isHit = true;
    }

}