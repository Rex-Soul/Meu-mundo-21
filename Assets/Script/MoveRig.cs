using UnityEngine;

public class MoveRig : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRigidbody();
    }
    void MoveRigidbody()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        _rb.linearVelocity = new Vector3(moveH, _rb.linearVelocity.y, moveZ) * _speed;
    }
}
