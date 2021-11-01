using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMunicao : MonoBehaviour
{
    public float currentSpeed;
    public float eixoX;
    public float eixoY;
    public float eixoZ;
    public GameObject bala;
    public Transform mira;
    public static AddMunicao municao;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 25f;
        eixoX = 1;
        eixoY = 0;
        eixoZ = 2;
    }

    void Awake()
    {
        municao = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(eixoX, eixoY, eixoZ) * currentSpeed * Time.deltaTime);
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        Personagem02.personagem.AumentaMunicao(this.gameObject);
        print("ENTROU NA AREA TRIGGER MUNICAO>> " + other.gameObject.name);
    }
}
