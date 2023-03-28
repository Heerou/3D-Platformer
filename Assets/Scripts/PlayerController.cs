using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public float GravityScale;
    public float RotationSpeed;

    private Vector3 moveDirection;
    public CharacterController CharContr;

    private Camera TheCamera;

    public GameObject PlayerModel;

    public Animator TheAnimator;

    // Start is called before the first frame update
    void Start()
    {
        TheCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float yStore = moveDirection.y;
        //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection *= MovementSpeed;
        moveDirection.y = yStore;

        if (CharContr.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = JumpForce;
            }
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * GravityScale;
        CharContr.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, TheCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRot = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            PlayerModel.transform.rotation = Quaternion.Slerp(PlayerModel.transform.rotation, newRot, RotationSpeed * Time.deltaTime);
        }

        TheAnimator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        TheAnimator.SetBool("Grounded", CharContr.isGrounded);
    }
}
