using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Criar Item")]
public class Item : ScriptableObject
{
    public string nome;
    public Sprite imagem;
}
