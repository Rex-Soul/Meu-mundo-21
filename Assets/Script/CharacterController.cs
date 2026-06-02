using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _speed;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
    }
    void MoveController()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        _characterController.Move(transform.forward * moveZ * _speed * Time.deltaTime);
    }
}
