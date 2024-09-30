using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float baseSpeed = 2f;
    [SerializeField] float speed = 1f;

    void Update()
    {
        var vec = (Vector3) GetInputVector();
        transform.position += vec * baseSpeed * speed * Time.deltaTime;
        SendOnMoveMessage(vec);
    }

    Vector2 GetInputVector()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 inputVector = new Vector2(horizontal, vertical);
        inputVector.Normalize();

        return inputVector;
    }

    void SendOnMoveMessage(Vector2 inputVector)
    {
        SendMessage("OnMove", inputVector * speed);
    }
}
