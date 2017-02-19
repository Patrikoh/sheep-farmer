using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterController controller;
    public float speed = 6.0F;
    public float rotationSpeed = 9000f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private bool isJumping;
    public Animator anim;
    private Vector3 moveDirection = Vector3.zero;
    private float inputH;
    private float inputV;
    private float animationSpeed;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (controller.isGrounded)
        {
            anim.SetBool("jump", false);
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (moveDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(moveDirection);


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetBool("jump", true);
            }
           

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime * speed);

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");



        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
  


    }
}
