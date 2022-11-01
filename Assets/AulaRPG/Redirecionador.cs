using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirecionador : MonoBehaviour
{
    public void Acertou()
    {
        GetComponentInParent<PlayerAttack>().Acertou();
    }
}
