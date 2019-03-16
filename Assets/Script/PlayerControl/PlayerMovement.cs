using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController2D playerMotor;


    private float moveDir_X;
    private float moveDir_Y;
    private Vector3 mousePosition;
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
        Vector2 moveVectors = new Vector2(moveDir_X, moveDir_Y);

        animator.SetFloat("speed", Mathf.Abs(moveVectors.magnitude));
       
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

      

    }
    private void FixedUpdate()
    {

        playerMotor.Motor(new Vector2(moveDir_X, moveDir_Y), mousePosition-transform.position);
        

    }

}
