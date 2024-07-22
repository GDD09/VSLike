using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody2D rb2d;
    Transform transform;
    [SerializeField]
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = getInputVector();
        Debug.Log(v);
        transform.transform.position += v*speed*Time.deltaTime;
    }
    Vector3 getInputVector()
    {
        float horizontal_vector = Input.GetAxisRaw("Horizontal");
        float vertical_vector = Input.GetAxisRaw("Vertical");
        Vector3 input_vector = new Vector3(horizontal_vector, vertical_vector, 0);
        Debug.Log(input_vector);
        return input_vector;
    }
}
