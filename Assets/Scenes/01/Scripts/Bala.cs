using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float velocidade = 15;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * velocidade * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("DESTRIUI A BALA "  + other.name);

        var otherTag = other.gameObject.tag;
        if (otherTag == "Player" || otherTag == "Cenario")
        {
            return;
        }

        Destroy(this.gameObject);
    }
}
