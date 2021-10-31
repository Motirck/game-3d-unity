using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemInimigo : MonoBehaviour
{
    public GameObject bala;
    public Transform mira;

    public Rigidbody body;
    public static PersonagemInimigo personagemInimigo;

    void Awake()
    {
        personagemInimigo = this;
    }

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var gameObjBala = Instantiate(bala, mira.position, Quaternion.identity);
        gameObjBala.transform.rotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //  print("COLIDIU NO PONTO " + collision.contacts[0].point.ToString());
    }
}
