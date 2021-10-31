using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInimigo : MonoBehaviour
{
    private float velocidade = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * velocidade * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("INIMIGO TEVE SUA BALA DESTRUIDA " + other.name);

        var otherTag = other.gameObject.tag;
        if (otherTag == "Cenario")
        {
            return;
        }

        Destroy(this.gameObject);
    }
}
