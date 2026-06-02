using UnityEngine;

public class tranlater3d : MonoBehaviour
{
    //[SerializeField] float posicaoX;
    //[SerializeField] float posicaoY;
    [SerializeField] Vector2 _posicao;
    [SerializeField] float _speed;
    [SerializeField] float _moverV;
    [SerializeField] float _moverH;
    void Start()
    {
        //transform.localPosition = new Vector3(_posicao.x, _posicao.y, 2);
        //transform.localEulerAngles = new Vector3(_posicao.x, _posicao.y, 2);
        //transform.localScale = new Vector3(_posicao.x, _posicao.y, _posicao.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoverTranlater();
    }
    void MoverTranlater()
    {
        _moverV = Input.GetAxisRaw("Vertical");
        _moverH = Input.GetAxisRaw("Horizontal");
        transform.Translate(transform.forward * _moverH * _speed * Time.deltaTime);
        transform.Translate(transform.right * _moverV * _speed * Time.deltaTime);
    }
}
