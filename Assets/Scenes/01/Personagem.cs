using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float velMovimento;
    public float velRotacao;

    public GameObject esferinha;

    // Start is called before the first frame update
    void Start()
    {
        velMovimento = 3f;
        velRotacao = 120;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var movimento = new Vector3(x, 0, z) * velMovimento;
        transform.Translate(movimento * Time.deltaTime);

        var mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(
            new Vector3(0, 1, 0)
            * mouseHorizontal
            * velRotacao * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            print("CLICOU MOUSE");

            // --------

            var gameObjEsfera = Instantiate(
                esferinha,
                transform.position,
                Quaternion.identity);
            gameObjEsfera.transform.rotation = transform.rotation;
        }
    }
}
