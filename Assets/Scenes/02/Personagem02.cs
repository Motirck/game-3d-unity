using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Personagem02 : MonoBehaviour
{
    public float velMovimento;
    public GameObject bala;
    public Transform mira;
    public int municao = 10;
    public int count = 0;
    public int qtdRemocaoVida = 0;

    public Rigidbody body;
    public float forcaPulo;
    public static Personagem02 personagem;

    void Awake()
    {
        personagem = this;
    }

    public void AumentaMunicao(GameObject other)
    {
        print("other e igual a " + other.tag);
        if (other.name != "Chao" && other.tag == "Municao")
        {
            municao += 5;
            Destroy(other);
        }
    }

    public void AumentaVida(int qtd, GameObject other)
    {
         TriggerDanoPersonagem.triggerDano.addVida(qtd);
         Destroy(other);
    }

    void Start()
    {
        velMovimento = 4f;

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        print("POSICAOOOOOOOOOOOOOOOOOOOOOOOOOOOOO" + body.position.y);

        if (body.position.y < -5)
        {
            Destroy(this.gameObject);

            SceneManager.LoadScene("SimpleNaturePack_Demo");
        }

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var movimento = new Vector3(x, 0, z) * velMovimento;

        transform.Translate(movimento * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && municao > 0)
        {
            municao--;
            print("Mouse click!");
            var gameObjBala = Instantiate(bala, mira.position, Quaternion.identity);
            gameObjBala.transform.rotation = transform.rotation;
        }
        else if (municao <= 0)
        {
            print("Sua MUNI��O acabou!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count == 0)
            {
                print("PULOU");

                body.AddForce(
                    new Vector3(0, 1, 0) * forcaPulo,
                    ForceMode.Impulse);

                count++;

                Task.Delay(1000).ContinueWith((task) => { count = 0; });
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      print("COLIDIU COM TIRO INIMIGO " + collision.contacts[0].point.ToString());

        if (collision.gameObject.tag == "BalaInimiga")
        {
            qtdRemocaoVida = 15;
            print("Personagem perdeu vida pois foi atingido por tiro inimigo");
            TriggerDanoPersonagem.triggerDano.removeVida(qtdRemocaoVida, collision);
            Destroy(collision.gameObject);
        }
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
