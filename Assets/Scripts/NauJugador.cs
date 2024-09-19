using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float _vel;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8; 
    }

    // Update is called once per frame
    void Update()
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
     float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: "+ direccioIndicadaX + " - Y: " + direccioIndicadaY  );


        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;
        transform.position = novaPos;
    }
}
