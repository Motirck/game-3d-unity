using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class PersonagemInimigo : MonoBehaviour
{
    public GameObject bala;
    public Transform mira;
    public int countDisparo = 0;
    public int qtdRemocaoVida = 0;

    public Rigidbody body;
    public static PersonagemInimigo personagemInimigo;

    void Awake()
    {
        personagemInimigo = this;
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (countDisparo == 0)
        {
            var gameObjBala = Instantiate(bala, mira.position, Quaternion.identity);
            gameObjBala.transform.rotation = transform.rotation;

            countDisparo++;

            Task.Delay(1000).ContinueWith((task) => { countDisparo = 0; });
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("COLIDIU COM TIRO DO PERSONAGEM " + collision.contacts[0].point.ToString());

        if (collision.gameObject.tag == "Bala")
        {
            qtdRemocaoVida = 50;
            print("Personagem Inimigo perdeu vida pois foi atingido por tiro");
            DanoPersonagemInimigo.dano.removeVida(qtdRemocaoVida, collision);
            Destroy(collision.gameObject);
        }
    }
}
