using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpmovemntscript : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;
    public float rotationspeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15f;

    Vector3 moveVelocity;
    Vector3 turnVelocity;
   
    public float turnSmoothTime = 0.1f;
    float turnsmoothvelocity;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        
    }

   

    private void Start() {
        Cursor.lockState  = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

   

    // Update is called once per frame
    void Update()
    {
        float horizontal =  Input.GetAxisRaw("Horizontal");
        float vertical =  Input.GetAxisRaw("Vertical");
        Vector3 direction =  new Vector3(horizontal,0f, vertical).normalized;
        if(controller.isGrounded){

            moveVelocity = transform.forward * speed * vertical;
            turnVelocity = transform.up * speed * horizontal;
            if(Input.GetButtonDown("Jump")){
                moveVelocity.y = jumpSpeed;
            }

            moveVelocity.y += gravity * Time.deltaTime;
            controller.Move(moveVelocity * Time.deltaTime);
            transform.Rotate(turnVelocity * Time.deltaTime);
        }

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f); 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
