using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVida : MonoBehaviour
{
    public int vida = 10;
    public float currentSpeed;
    public float eixoX;
    public float eixoY;
    public float eixoZ;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 25f;
        eixoX = 1;
        eixoY = 0;
        eixoZ = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(eixoX, eixoY, eixoZ) * currentSpeed * Time.deltaTime);
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        Personagem02.personagem.AumentaVida(vida, this.gameObject);
        print("ENTROU NA AREA TRIGGER VIDA>> " + other.gameObject.name);
    }
}
