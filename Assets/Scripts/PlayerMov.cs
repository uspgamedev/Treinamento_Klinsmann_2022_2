using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{

    public PlayerController controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("Is_Jumping", true);
            Debug.Log("pulou");
        }

    }

    public void OnLanding(){
		animator.SetBool("Is_Jumping", false);
        Debug.Log("caiu");
	}

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
