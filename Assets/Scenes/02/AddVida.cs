using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVida : MonoBehaviour
{
    public int vida = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        Personagem02.personagem.AumentaVida(vida, this.gameObject);
        print("ENTROU NA AREA TRIGGER VIDA>> " + other.gameObject.name);
    }
}
