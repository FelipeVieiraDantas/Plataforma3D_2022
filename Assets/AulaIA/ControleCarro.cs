using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCarro : MonoBehaviour
{
    public float velocidade = 10;
    public float velRotacao = 5;
    Rigidbody fisica;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movimentoLado = Input.GetAxis("Horizontal");
        float movimentoFrente = Input.GetAxis("Vertical");
        fisica.velocity = transform.forward 
            * movimentoFrente * velocidade;
        transform.Rotate(0, movimentoLado * velRotacao, 0);
    }
}
