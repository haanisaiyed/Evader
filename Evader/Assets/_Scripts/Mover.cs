using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float horizontalSpeed;
    private float verticalSpeed;
    private float rotationSpeed;

    public enum HorizontalDirection {Left,Right,None}
    public enum VerticalDirection {Up, Down, None};
    public enum RotationDirection {Clockwise, AntiClockwise, None};
    [System.Serializable]

    public struct HorizontalMovement
    {
        public float speed;
        public HorizontalDirection direction;
    }
    [System.Serializable]

    public struct VerticalMovement
    {
        public float speed;
        public VerticalDirection direction;

    }
    [System.Serializable]

    public struct RotationMovement
    {
        public float speed;
        public RotationDirection direction;
    }



    // Start is called before the first frame update
    void Start()
    {

        
    }
    public HorizontalMovement horizontalMovement;
    public VerticalMovement verticalMovement;
    public RotationMovement rotationMovement;

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed=horizontalMovement.speed;
        verticalSpeed = verticalMovement.speed;
        rotationSpeed = rotationMovement.speed;
        if(horizontalMovement.direction==HorizontalDirection.Left)
            horizontalSpeed = -horizontalSpeed;
        if(verticalMovement.direction == VerticalDirection.Down)
            verticalSpeed=  -verticalSpeed;
        if(rotationMovement.direction == RotationDirection.Clockwise)
            rotationSpeed=-rotationSpeed;
        transform.position = new Vector3(
            transform.position.x +(horizontalSpeed*Time.deltaTime),
            transform.position.y +(verticalSpeed*Time.deltaTime),
            transform.position.z
        );
        transform.rotation = Quaternion.Euler(
            0f,0f,transform.rotation.eulerAngles.z +(rotationSpeed*Time.deltaTime)
        );
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnValidate(){
        horizontalMovement.speed = Mathf.Clamp(horizontalMovement.speed, 0f, 15f);
        verticalMovement.speed = Mathf.Clamp(verticalMovement.speed, 0f, 15f);
        rotationMovement.speed = Mathf.Clamp(rotationMovement.speed, 0f, 200f);
        if(horizontalMovement.direction == HorizontalDirection.None)
            horizontalMovement.speed =0f;
        if(verticalMovement.direction == VerticalDirection.None)
            verticalMovement.speed = 0f;
        if(rotationMovement.direction == RotationDirection.None)
            rotationMovement.speed = 0f;
    }
}
;