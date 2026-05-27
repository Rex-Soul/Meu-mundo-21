using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 _movePlayer;
    [SerializeField] CharacterController _controller;

    [SerializeField] Vector3 playerVelocity;
    [SerializeField] bool groundedPlayer;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    void Start()
    {

        _controller=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //InputMovePlayer();
        MovendoPlayer();
    }
    void InputMovePlayer()
    {
        _movePlayer.x = Input.GetAxis("Horizontal");
        _movePlayer.z = Input.GetAxis("Vertical");
    }
    void MovendoPlayer()
    {
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(_movePlayer * Time.deltaTime * playerSpeed);
        if (_movePlayer != Vector3.zero)
        {
            gameObject.transform.forward = _movePlayer;
        }
        //JumpPlayer();
        Gravidade();
    }
    void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
    }
    void Gravidade()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }
    public void SetMove(InputAction.CallbackContext value)
    {
        _movePlayer.x = value.ReadValue<Vector3>().x;
        _movePlayer.y = value.ReadValue<Vector3>().y;
    }
    public void SetJump(InputAction.CallbackContext value)
    {
        if (groundedPlayer == true)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
    }
}
