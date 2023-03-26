using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
  public Rigidbody2D rb2d;
  private Animator anim;
  private SpriteRenderer sprite;
  public Collider2D platformCollider;
  public float moveSpeed;
  public float myGravity;
  public int maxJumps;
  public float jumpForce;
  private float jumpTimer;
  public float jumpTimerMax;
  private bool pressedJump;
  private bool startJumpTimer;
  private bool releasedJump;

  private void Awake()
  {
    rb2d = gameObject.GetComponent<Rigidbody2D>();
    anim = gameObject.GetComponent<Animator>();
    sprite = gameObject.GetComponent<SpriteRenderer>();
    platformCollider = transform.Find("Platform-Collider").GetComponent<Collider2D>();
    
    jumpTimerMax = .2f;
    jumpTimer = jumpTimerMax;
    pressedJump = false;
    startJumpTimer = false;
    releasedJump = false;

    myGravity = rb2d.gravityScale;
    rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
  }

  private void Update()
  {
    Movement();
  }

  private void FixedUpdate()
  {
    if (pressedJump)
    {
      StartJump();
    }

    if (releasedJump)
    {
      StopJump();
    }

    if (startJumpTimer)
    {
      jumpTimer -= Time.deltaTime;
      if (jumpTimer <= 0)
      {
        releasedJump = true;
      }
    }
  }

  private void Movement()
  {

    Vector3 movement = new Vector3(0f, 0f, 0f);

    if (gameObject.name == "Player_One")
    {

      // JUMP
      if (Input.GetButtonDown("Player_One_Jump") && anim.GetInteger("Jumps") > 0 && anim.GetBool("canMove"))
      {
        pressedJump = true;
      }
      if (Input.GetButtonUp("Player_One_Jump"))
      {
        releasedJump = true;
      }

      // LOOK UP AND DOWN
      if (Input.GetAxis("Player_One_Vertical") > 0 && anim.GetInteger("Look") <= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 1);
      }
      else if (Input.GetAxis("Player_One_Vertical") == 0 && anim.GetInteger("Look") != 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 0);
      }
      else if (Input.GetAxis("Player_One_Vertical") < 0 && anim.GetInteger("Look") >= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", -1);

        if (anim.GetBool("isPlatformed"))
        {
          platformCollider.enabled = false;
        }
      }

      // HORIZONTAL MOVEMENT
      if (anim.GetBool("canMove"))
      {
        movement = new Vector3(Input.GetAxis("Player_One_Horizontal"), 0f, 0f);
      }
    }

    else if (gameObject.name == "Player_Two")
    {

      // JUMP
      if (Input.GetButtonDown("Player_Two_Jump") && anim.GetInteger("Jumps") > 0 && anim.GetBool("canMove"))
      {
        pressedJump = true;
      }
      if (Input.GetButtonUp("Player_Two_Jump"))
      {
        releasedJump = true;
      }

      // LOOK UP AND DOWN
      if (Input.GetAxis("Player_Two_Vertical") > 0 && anim.GetInteger("Look") <= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 1);
      }
      else if (Input.GetAxis("Player_Two_Vertical") == 0 && anim.GetInteger("Look") != 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 0);
      }
      else if (Input.GetAxis("Player_Two_Vertical") < 0 && anim.GetInteger("Look") >= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", -1);

        if (anim.GetBool("isPlatformed"))
        {
          platformCollider.enabled = false;
        }
      }

      // HORIZONTAL MOVEMENT
      if (anim.GetBool("canMove"))
      {
        movement = new Vector3(Input.GetAxis("Player_Two_Horizontal"), 0f, 0f);
      }

    }

    else if (gameObject.name == "Player_Three")
    {

      // JUMP
      if (Input.GetButtonDown("Player_Three_Jump") && anim.GetInteger("Jumps") > 0 && anim.GetBool("canMove"))
      {
        pressedJump = true;
      }
      if (Input.GetButtonUp("Player_Three_Jump"))
      {
        releasedJump = true;
      }

      // LOOK UP AND DOWN
      if (Input.GetAxis("Player_Three_Vertical") > 0 && anim.GetInteger("Look") <= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 1);
      }
      else if (Input.GetAxis("Player_Three_Vertical") == 0 && anim.GetInteger("Look") != 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 0);
      }
      else if (Input.GetAxis("Player_Three_Vertical") < 0 && anim.GetInteger("Look") >= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", -1);

        if (anim.GetBool("isPlatformed"))
        {
          platformCollider.enabled = false;
        }
      }

      // HORIZONTAL MOVEMENT
      if (anim.GetBool("canMove"))
      {
        movement = new Vector3(Input.GetAxis("Player_Three_Horizontal"), 0f, 0f);
      }

    }

    else if (gameObject.name == "Player_Four")
    {

      // JUMP
      if (Input.GetButtonDown("Player_Four_Jump") && anim.GetInteger("Jumps") > 0 && anim.GetBool("canMove"))
      {
        pressedJump = true;
      }
      if (Input.GetButtonUp("Player_Four_Jump"))
      {
        releasedJump = true;
      }

      // LOOK UP AND DOWN
      if (Input.GetAxis("Player_Four_Vertical") > 0 && anim.GetInteger("Look") <= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 1);
      }
      else if (Input.GetAxis("Player_Four_Vertical") == 0 && anim.GetInteger("Look") != 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", 0);
      }
      else if (Input.GetAxis("Player_Four_Vertical") < 0 && anim.GetInteger("Look") >= 0 && !anim.GetBool("isAttacking"))
      {
        anim.SetInteger("Look", -1);

        if (anim.GetBool("isPlatformed"))
        {
          platformCollider.enabled = false;
        }
      }

      // HORIZONTAL MOVEMENT
      if (anim.GetBool("canMove"))
      {
        movement = new Vector3(Input.GetAxis("Player_Four_Horizontal"), 0f, 0f);
      }

    }

    if (movement.x == 0 || !anim.GetBool("isGrounded"))
    {
      anim.SetBool("isRunning", false);
    }
    else if ((movement.x > 0 || movement.x < 0) && rb2d.velocity.y == 0 && anim.GetBool("isGrounded"))
    {
      anim.SetBool("isRunning", true);
    }

    if (rb2d.velocity.y < 0)
    {
      anim.SetBool("isFalling", true);
      anim.SetBool("isAscending", false);
    }
    else if (rb2d.velocity.y == 0)
    {
      anim.SetBool("isFalling", false);
      anim.SetBool("isAscending", false);
    }
    else if (rb2d.velocity.y > 0)
    {
      anim.SetBool("isFalling", false);
      anim.SetBool("isAscending", true);
    }

    if (movement.x > 0 && anim.GetInteger("Direction") != 1 && anim.GetBool("canTurn"))
    {
      anim.SetInteger("Direction", 1);
      sprite.flipX = false;
    }
    else if (movement.x < 0 && anim.GetInteger("Direction") != -1 && anim.GetBool("canTurn"))
    {
      anim.SetInteger("Direction", -1);
      sprite.flipX = true;
    }
    transform.position += movement * Time.deltaTime * moveSpeed;
  }

  private void StartJump()
  {
    // Resetting Y velocity to 0 to remove downward force
    rb2d.velocity = new Vector3(rb2d.velocity.x, 0f, 0f);

    anim.SetBool("isJumping", true);
    anim.SetInteger("Jumps", anim.GetInteger("Jumps") - 1);
    rb2d.gravityScale = 0f;
    rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    pressedJump = false;
    startJumpTimer = true;
    platformCollider.enabled = false;
  }

  private void StopJump()
  {
    rb2d.gravityScale = myGravity;
    releasedJump = false;
    jumpTimer = jumpTimerMax;
    startJumpTimer = false;
    anim.SetBool("isJumping", false);
    // platformCollider.enabled = true;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {

    if (other.transform.tag == "Floor" && !anim.GetBool("isJumping") && (other.transform.position.y < gameObject.transform.position.y))
    {
      Debug.Log("Collided with FLOOR");
      // rb2d.velocity = new Vector3(rb2d.velocity.x, 0f, 0f);
      anim.SetInteger("Jumps", maxJumps);
      anim.SetInteger("Lights", 3);
      anim.SetBool("isGrounded", true);
      platformCollider.enabled = true;
    }
  }

  private void OnCollisionExit2D(Collision2D other)
  {
    if (other.transform.tag == "Floor")
    {
      anim.SetBool("isPlatformed", false);
      anim.SetBool("isGrounded", false);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.transform.tag == "Platform" && !anim.GetBool("isJumping") && (other.transform.position.y < gameObject.transform.position.y))
    {
      Debug.Log("Collided with PLATFORM");
      // rb2d.velocity = new Vector3(rb2d.velocity.x, 0f, 0f);
      anim.SetInteger("Jumps", maxJumps);
      anim.SetInteger("Lights", 3);
      anim.SetBool("isGrounded", true);
      anim.SetBool("isPlatformed", true);
      platformCollider.enabled = true;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.transform.tag == "Platform")
    {
      anim.SetBool("isPlatformed", false);
      anim.SetBool("isGrounded", false);
    }
  }

}