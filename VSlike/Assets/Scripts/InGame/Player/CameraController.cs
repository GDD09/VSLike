using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject focusTarget;

    // 0.0 ~ 1.0, lerp ratio per fixed update
    public float cameraSpeed = 0.25f;
    public Vector2 offset = new Vector2(0, 0);

    // For interpolation
    Vector2 previousPosition;
    Vector2 nextPosition;

    void Start()
    {
        ResetCameraTracking();
    }

    void Update()
    {
        // Framerate-independent position interpolation
        var interpolateDelta = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
        interpolateDelta = Mathf.Clamp(interpolateDelta, 0.0f, 1.0f);
        SetPosition2(Vector2.Lerp(previousPosition, nextPosition, interpolateDelta));
    }

    void FixedUpdate()
    {
        previousPosition = nextPosition;
        SetPosition2(previousPosition);
        nextPosition = Vector2.Lerp(previousPosition, GetTargetPosition(), cameraSpeed);
    }


    void SetPosition2(Vector2 v)
    {
        v += offset;

        // Snap to pixel
        var newX = Mathf.Round(v.x * 100) / 100;
        var newY = Mathf.Round(v.y * 100) / 100;

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    Vector2 GetTargetPosition()
    {
        return focusTarget?.transform.position ?? Vector2.zero;
    }

    public void ResetCameraTracking()
    {
        previousPosition = GetTargetPosition();
        nextPosition = previousPosition;
    }
}

// Partially based on:
// https://github.com/nulta/TimePuzzler/blob/main/Assets/Scripts/Player/CameraController.cs
