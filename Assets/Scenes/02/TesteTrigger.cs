using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteTrigger : MonoBehaviour
{
    public int vida = 20;

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        print("ENTROU NA AREA TRIGGER 555>> "+ other.gameObject.name);
        print("nome da tag "+ other.gameObject.tag);

        if (other.gameObject.tag == "Bala")
        {
            vida -= 10;
        }

        if (vida <= 0)
        {
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
