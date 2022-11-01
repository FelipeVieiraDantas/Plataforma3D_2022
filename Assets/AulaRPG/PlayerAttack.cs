using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public Transform atacando;
    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(atacando != null)
        {
            if(Vector3.Distance(transform.position,
                atacando.position) < 3)
            {
                if(stats.barraDeEstamina.fillAmount == 1)
                {
                    anim.SetTrigger("Ataque");
                }
            }
        }
        else
        {
            anim.ResetTrigger("Ataque");
        }
    }

    public void Acertou()
    {
        stats.barraDeEstamina.fillAmount = 0;
        stats.GanharXP(
            atacando.GetComponent<InimigoRPG>().
                TomarDano(stats.forca)
            );
    }

}
