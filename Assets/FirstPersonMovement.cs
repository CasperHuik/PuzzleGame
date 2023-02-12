﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Mirror; 

public class FirstPersonMovement : NetworkBehaviour
{
    private bool isMoving = false; 

    private Animator animator;

    public CharacterController controller; 
    public GameObject PlayerModel; 

    public float speed = 12f; 
    public float gravity = -9.81f; 
    public float jumpHeight = 10f; 

    public Transform groundCheck; 
    public float groundDistance = 0.4f; 
    public LayerMask groundMask; 

    Vector3 velocity; 
    bool isGrounded; 

    private void Start(){
        PlayerModel.SetActive(false);
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name; 
        if(sceneName == "Game"){
            if(PlayerModel.activeSelf == false){
                SetPosition();
                PlayerModel.SetActive(true);
            }

            if(isLocalPlayer){
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if(isGrounded && velocity.y < 0){
                    velocity.y = -2f; 
                }


                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){animator.SetBool("IsMoving", true);}
                else{animator.SetBool("IsMoving", false);}

                Vector3 move = transform.right * x + transform.forward * z; 

                controller.Move(move * speed * Time.deltaTime);

                if(Input.GetButtonDown("Jump") && isGrounded){
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }

                velocity.y += gravity * Time.deltaTime; 

                controller.Move(velocity * Time.deltaTime);
            }
        }
    }

    public void SetPosition(){
        transform.position = new Vector3(Random.Range(-5,5), 1, Random.Range(-15,7));
    }

}
