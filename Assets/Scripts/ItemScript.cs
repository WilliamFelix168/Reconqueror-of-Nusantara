using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton joyButton;
    private Animator Animator;
    private bool isTouchGround = true;
    protected bool jump;
    public Vector2 RespawnPoint;
    public LevelManager gameLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
        Animator = FindObjectOfType<Animator>();
        gameLevelManager = FindObjectOfType<LevelManager>();
        RespawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(joystick.Horizontal * 5f, rigidbody.velocity.y);
        if(joystick.Horizontal * 5f<0.0)
        {
            transform.localScale = new Vector2(-0.5f,0.5f);
        }
        if (joystick.Horizontal * 5f > 0.0)
        {
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
        


        if (!jump && joyButton.pressed)
        {
            rigidbody.velocity += Vector2.up * 1f;
            isTouchGround = false;
        }
        if(!jump && !joyButton.pressed)
        {
            isTouchGround = true;
        }
        Animator.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        Animator.SetBool("OnGround", isTouchGround);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FallDetector")
        {
            gameLevelManager.Respawn();
        }
    }
}
