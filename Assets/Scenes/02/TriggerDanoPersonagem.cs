using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDanoPersonagem : MonoBehaviour
{
    public int vida = 100;
    public static TriggerDanoPersonagem triggerDano;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        triggerDano = this;
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        print("ENTROU NA AREA TRIGGER 123>> " + other.gameObject.name);

        if (other.gameObject.tag != "Municao" && other.gameObject.tag != "Vida") {
            vida -= 20;
        }

        if (vida <= 0 && other.gameObject.name != "Chao")
        {
            SceneManager.LoadScene("Scene 02");

            Destroy(this.gameObject);
        }
    }

    public void addVida(int qtd)
    {
        vida += qtd;
    }

    public void removeVida(int qtd, Collision other)
    {
        vida -= qtd;

        if (vida <= 0 && other.gameObject.name != "Chao")
        {
            SceneManager.LoadScene("Scene 02");

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print("ESTA NA AREA TRIGGER>> " + other.gameObject.name);

    }

    private void OnTriggerExit(Collider other)
    {
        print("SAIU DA AREA TRIGGER>> " + other.gameObject.name);

    }
}
