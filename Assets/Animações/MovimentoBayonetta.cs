using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBayonetta : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody fisica;

    Animator anim;
    bool atacando;

    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (atacando)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Porrada"))
            {
                atacando = false;
            }
        }

        //Atacar com o botão esquerdo do mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Porrada"))
            {
                anim.SetTrigger("Ataque");
                atacando = true;
                anim.ResetTrigger("Combo");
            }
            else
            {
                anim.SetTrigger("Combo");
            }
        }



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

        //Ligar ou desligar animação de andando
        if(movimentoX != 0 || movimentoZ != 0)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }
    }
}
