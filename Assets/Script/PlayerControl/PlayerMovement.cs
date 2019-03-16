using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController2D playerMotor;


    private float moveDir_X;
    private float moveDir_Y;
    private Vector3 targetVectors;
    private Vector2 moveVectors;
    private Animator animator;
    // Use this for initialization
    void Start() {
        playerMotor = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update () {

        moveDir_X = Input.GetAxisRaw("Horizontal");
        moveDir_Y = Input.GetAxisRaw("Vertical");
        moveVectors = new Vector2(moveDir_X, moveDir_Y);
        targetVectors = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)) - transform.position;

        int dir = moveDir_X >= 0 ? 1 : -1;

        if (moveVectors.magnitude* dir * targetVectors.x>0)
            animator.SetFloat("speed", 1f);
        else if(moveVectors.magnitude * dir * targetVectors.x < 0)
            animator.SetFloat("speed", 0f);
        else
            animator.SetFloat("speed", 0.5f);





    }
    private void FixedUpdate()
    {

        playerMotor.Motor(moveVectors, targetVectors);
        

    }

}
