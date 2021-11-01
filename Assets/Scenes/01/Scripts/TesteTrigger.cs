using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteTrigger : MonoBehaviour
{
    public int vida = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            print("ENTROU NA AREA TRIGGER 555>> " + collision.gameObject.name);
            print("nome da tag " + collision.gameObject.tag);

            if (collision.gameObject.tag == "Bala")
            {
                vida -= 10;
            }

            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
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
