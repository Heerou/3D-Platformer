using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public float GravityScale = 5f;

    private Vector3 moveDirection;
    public CharacterController CharContr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float yStore = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection *= MovementSpeed;
        moveDirection.y = yStore;

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = JumpForce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * GravityScale;
        CharContr.Move(moveDirection * Time.deltaTime);
    }
}
