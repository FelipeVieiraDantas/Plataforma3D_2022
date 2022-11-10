using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public Item item;

    public Rigidbody fisica;
    public SphereCollider colisor;
    public float forcaPular = 100;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().
            sprite = item.imagem;

        Vector3 forcaAplicada;
        forcaAplicada.y = 300;
        forcaAplicada.x = Random.Range(0, forcaPular);
        forcaAplicada.z = Random.Range(0, forcaPular);
        fisica.AddForce(forcaAplicada);
        Invoke("LigarCollider", 1); //Chamar função com atraso
    }

    void LigarCollider()
    {
        colisor.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Inventario>().
                AdicionarItem(item);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform);

        if (colisor.enabled == true)
        {
            Vector3 vel = fisica.velocity;
            vel.x = 0;
            vel.z = 0;
            fisica.velocity = vel;
        }
    }
}
