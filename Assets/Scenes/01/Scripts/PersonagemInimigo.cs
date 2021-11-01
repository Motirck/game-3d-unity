using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemInimigo : MonoBehaviour
{
    public GameObject bala;
    public Transform mira;
    public int qtdRemocaoVida = 0;

    public static PersonagemInimigo personagemInimigo;

    void Awake()
    {
        personagemInimigo = this;
    }

    void Start()
    {
        InvokeRepeating("DisparaTiro", 2.0f, 1.0f);
    }

    void DisparaTiro()
    {
        var gameObjBala = Instantiate(bala, mira.position, Quaternion.identity);
        gameObjBala.transform.rotation = transform.rotation;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //print("COLIDIU COM TIRO DO PERSONAGEM " + collision.contacts[0].point.ToString());

        if (collision.gameObject.tag == "Bala")
        {
            qtdRemocaoVida = 50;
            print("Personagem Inimigo perdeu vida pois foi atingido por tiro");
            DanoPersonagemInimigo.dano.removeVida(qtdRemocaoVida, collision);

            Destroy(collision.gameObject);
        }
    }
}
