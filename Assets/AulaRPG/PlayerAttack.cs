using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform atacando;
    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
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
                    stats.barraDeEstamina.fillAmount = 0;
                    atacando.GetComponent<InimigoRPG>().
                        TomarDano();
                }
            }
        }
    }
}
