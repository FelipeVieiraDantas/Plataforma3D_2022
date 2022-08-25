using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Toda vez que o código for mexer na UI

public class ControleJogador : MonoBehaviour
{
    Rigidbody fisica;
    public float velocidade = 10;
    public float forcaPulo = 300;
    public float velocidadeGira = 5;

    public bool estaNoChao;

    [Header("Força")]
    public Image barra;
    bool segurando;
    public float encheBarra = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //Pegar um componente rigidbody e falar que agora ele se chama fisica
        fisica = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Encher a barra se tiver segurando o obj
        if(segurando){
            //Time.deltaTime = 1/FPS exemplo: 1/60= 0.016; 
            barra.fillAmount += encheBarra * Time.deltaTime;
        }


        //Pegar um eixo que para a esquerda � -1, para direita 1
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoY = Input.GetAxis("Vertical");
        //Mostra uma mensagem s� pra gente, no Console.
        Debug.Log(movimentoX);

        //Movimento normal considerando X e Z da Unity
        /*fisica.velocity = new Vector3(
            movimentoX*velocidade,
            fisica.velocity.y,
            movimentoY * velocidade);*/

        transform.Rotate(0, movimentoX * velocidadeGira, 0);
        //Se eu quiser que ele rode sempre 90 graus:
        /*if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, -90, 0);
        }*/

        Vector3 direcao = transform.forward * movimentoY;
        direcao = direcao * velocidade;
        direcao.y = fisica.velocity.y;

        fisica.velocity = direcao;

        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao) {
            fisica.AddForce(0, forcaPulo, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            estaNoChao = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            estaNoChao = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            other.transform.parent = transform;
            other.GetComponent<Rigidbody>().isKinematic = true;
            segurando = true;
        }else
        {
            barra.fillAmount = 0; 
            segurando = false;
            other.transform.parent = null;
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
