using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBayonetta : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody fisica;
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoX, 0, movimentoZ);
        //Transformo uma direção como se fosse filha da camera
        //para o mundo da unity
        movimento = 
            Camera.main.transform.TransformDirection(movimento);
        movimento.y = 0;
        transform.rotation = Quaternion.LookRotation(movimento);
        fisica.velocity = movimento * velocidade;
    }
}
