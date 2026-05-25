using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 _moverPlayer;
    void Start()
    {
        InputMoverPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InputMoverPlayer()
    {
        _moverPlayer.x = Input.GetAxis("Horizontal");
        _moverPlayer.z = Input.GetAxis("Vertical");
    }
}
