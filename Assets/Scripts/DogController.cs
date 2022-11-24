using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    public float _speed =2f;
    public int _orientation =1;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        
        if(transform.position.x >= 3.26471f)
        {
            
            _orientation = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(transform.position.x <= -4.040346f)
        {
            _orientation = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.velocity = new Vector3(_orientation, rb.velocity.y, 0) * _speed;
    }

}
