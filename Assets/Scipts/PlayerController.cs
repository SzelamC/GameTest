using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerFeet;
    private Animator playerAnim;

    public float runSpeed;
    public float jumpForce;
    public int maxExtraJumps;
    
    
    private float moveInput;
    private bool jumpPress;
    public int extraJumpCount;
    private bool isGrounded;
    private bool isFall;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerFeet = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
    }


    void Update()
    {
        GroundCheck();
        moveInput = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && extraJumpCount > 0){
            jumpPress = true;
        }
        if(playerRigidbody.velocity.y < -0.01f){
            isFall = true;
        } else{
            isFall = false;
        }
        SwitchAnimation();
    }

    void FixedUpdate() 
    {
        PlayerRun();
        if(jumpPress){
            PlayerJump();
            jumpPress = false;
        }
    }

    void SwitchAnimation()
    {
        if(!isGrounded||playerAnim.GetBool("PlayerJump")){
            if(isFall){
                playerAnim.SetBool("PlayerJump", false);
                playerAnim.SetBool("PlayerFall", true);
            }
        }
        if(playerAnim.GetBool("PlayerFall") && jumpPress){
            playerAnim.SetBool("PlayerJump", true);
            playerAnim.SetBool("PlayerFall", false);
        }
        if(isGrounded){
            playerAnim.SetBool("PlayerFall", false);
            playerAnim.SetBool("PlayerIdle", true);
        }
    }
    void GroundCheck()
    {
        isGrounded = playerFeet.IsTouchingLayers(LayerMask.GetMask("Floor")) || playerFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"));
        if(isGrounded){
            extraJumpCount = maxExtraJumps;
        }
    }
    void PlayerRun()
    {   
        Vector2 playerRunVel = new Vector2(moveInput*runSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerRunVel;
        bool playerHasXAxisSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        playerAnim.SetBool("PlayerRun", playerHasXAxisSpeed);
        if(playerHasXAxisSpeed){
            if(playerRigidbody.velocity.x > 0.1f){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if(playerRigidbody.velocity.x < -0.1f){
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }
    }

    void PlayerJump()
    {
        extraJumpCount--;
        Vector2 playerJumpVel = new Vector2(playerRigidbody.velocity.x, jumpForce);
        playerRigidbody.velocity = Vector2.up * playerJumpVel;
        playerAnim.SetBool("PlayerJump", true);
    }

}
