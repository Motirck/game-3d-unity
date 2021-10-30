using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoMouse : MonoBehaviour
{
    public float velRotacao;
   
    // Update is called once per frame
    void Update()
    {
        var mouseHorizontal = Input.GetAxis("Mouse X");
        var mouseVertical = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseHorizontal * velRotacao * Time.deltaTime, 0));


    }
}
