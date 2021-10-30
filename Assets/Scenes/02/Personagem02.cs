using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Personagem02 : MonoBehaviour
{
    public float velMovimento;
    public GameObject bala;
    public Transform mira;
    public int municao = 10;
    public int count = 0;

    public Rigidbody body;
    public float forcaPulo;
    public static Personagem02 personagem;

    public int add(int valor)
    {
        return (int)(velMovimento + valor);
    }

    public string add(string valor)
    {
        return (velMovimento + valor).ToString();

    }

    public void add<T> (T objeto)
    {

        if(objeto is GameObject)
        {
            GameObject convertido = objeto as GameObject;
            
        }
        else if (objeto is Collider){
            print("Recebeu um colider");
        }

    }

    void Awake()
    {
        personagem = this;
    }

    public void AumentaMunicao(GameObject other)
    {
        print("other e igual a " + other.tag);
        if (other.name != "Plane" && other.tag == "Municao")
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
        add<int>(4);

        add<string>("ola mundo");

        velMovimento = 3f;

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
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
            print("Sua MUNIÇÃO acabou!");
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
      //  print("COLIDIU NO PONTO " + collision.contacts[0].point.ToString());
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
