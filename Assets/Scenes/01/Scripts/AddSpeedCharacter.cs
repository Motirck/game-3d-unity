using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedCharacter : MonoBehaviour
{
    public float moreSpeed;
    public float eixoX;
    public float eixoY;
    public float eixoZ;

    // Start is called before the first frame update
    void Start()
    {
        moreSpeed = 12f;
        eixoX = 1;
        eixoY = 0;
        eixoZ = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(eixoX, eixoY, eixoZ) * moreSpeed * Time.deltaTime);
    }

    // colidiu com algum colider
    private void OnTriggerEnter(Collider other)
    {
        print("ATIVOU SPEEEEEEEEED");
        Personagem02.personagem.IncreaseSpeed(moreSpeed, this.gameObject);
    }
}