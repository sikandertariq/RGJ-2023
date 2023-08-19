using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Tut tut;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    //[SerializeField]
    //private float jumpHeight = 1.0f;
    [SerializeField] 
    private float gravityValue = -9.81f;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Transform cameraMain;

    private void Awake()
    {
        tut=new Tut();
        controller=GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        tut.Enable();
    }

    private void OnDisable()
    {
        tut.Disable();
    }

    

    private void Start()
    {
        //cameraMain = Camera.main.transform;
    }

    //void Update()
    //{
    //    groundedPlayer = controller.isGrounded;
    //    if (groundedPlayer && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }
    //    Vector2 movementInput=tut.Player.Move.ReadValue<Vector2>();
    //    Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
    //    controller.Move(move * Time.deltaTime * playerSpeed);

    //    if (move != Vector3.zero)
    //    {
    //        gameObject.transform.forward = move;
    //    }

    //    // Changes the height position of the player..
    //    //if (Input.GetButtonDown("Jump") && groundedPlayer)
    //    //{
    //    //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    //    //}

    //    playerVelocity.y += gravityValue * Time.deltaTime;
    //    controller.Move(playerVelocity * Time.deltaTime);
    //}
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 movementInput = tut.Player.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward* movementInput.y+cameraMain.right*movementInput.x);
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

            _animator.SetBool("isRunning", true);
            _animator.SetBool("isIdle", false);
        }
        else
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isIdle", true);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}