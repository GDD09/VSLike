using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    void Update()
    {
        float x_axis = Input.GetAxis("Horizontal");
        if (x_axis > 0)
            transform.localScale = new Vector3(1, 1.5f, 1);
        else if (x_axis < 0)
            transform.localScale = new Vector3(-1, 1.5f, 1);
    }
}
