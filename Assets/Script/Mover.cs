using UnityEngine;

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
    void Update()
    {
        InputMovePlayer();
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
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }
}
