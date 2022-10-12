using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller_Player : MonoBehaviour
{
    [SerializeField]
    float radius;
    bool checkGround;

    [SerializeField]
    float positionCheckGround;
    public bool CheckGround { get { return checkGround; } }


    [SerializeField]
    float forceJump = 0;

    [SerializeField]
    float timeToJump;
    float temporalTimeToJump;

    bool fillBarPower = false;
    public bool FillBarPower { get { return fillBarPower; } }

    private bool collisionNewPlatForm = false;
    public bool CollisionNewPlatForm { get { return collisionNewPlatForm; } }

    Rigidbody2D rbPlayer;

    [SerializeField]
    LayerMask layerFilter;

    int currentRecord = 0;

    public int GetCurrentRecord { get { return currentRecord; } }

    Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        temporalTimeToJump = timeToJump;
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(new Vector3(transform.position.x, transform.position.y - positionCheckGround, 0), radius, layerFilter))
        {
            checkGround = true;
        }
        else
        {
            checkGround = false;
        }
        Jump();
    }
    //Controller Move player for test

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && checkGround)
        {

            timeToJump -= Time.deltaTime;
            fillBarPower = true;
            if (timeToJump > 0)
            {
                forceJump += Time.deltaTime * 7;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && checkGround)
        {
            animPlayer.SetTrigger("jump");
            fillBarPower = false;
            timeToJump = temporalTimeToJump;
            rbPlayer.velocity = Vector2.up * forceJump;
            forceJump = 5;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - positionCheckGround, 0), radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y > collision.transform.position.y)
        {
            currentRecord++;
            collisionNewPlatForm = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionNewPlatForm = false;
    }
}
