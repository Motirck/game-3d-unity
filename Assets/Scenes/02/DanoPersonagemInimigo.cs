using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DanoPersonagemInimigo : MonoBehaviour
{
    public int vida = 100;
    public static DanoPersonagemInimigo dano;

    void Awake()
    {
        dano = this;
    }

    public void removeVida(int qtd, Collision other)
    {
        vida -= qtd;

        if (vida <= 0 && other.gameObject.name != "Chao")
        {
            Destroy(this.gameObject);
        }
    }
}
