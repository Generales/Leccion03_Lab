using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Se declara variable para controlar la velocidad con la que se moverá el jugador (el objeto llamado player)
    public float speed = 5f;
    //Se declara variable para controlar 
    private Rigidbody playerRB;
    //
    private float zBound = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Se manda a llamar el componente llamado Rigidbody 
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RestrictPlayer();
    }

    void MovePlayer()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(Vector3.forward * speed * VerticalInput);
        playerRB.AddForce(Vector3.right * speed * HorizontalInput);
    }

    void RestrictPlayer()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        if (transform.position.z > -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
    }
}
