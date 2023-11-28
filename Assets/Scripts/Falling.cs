using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    //public Transform prefabToMove; // Assuming the prefab is a 2D object with a Transform component
    public float moveSpeed = 2.0f;
    public float customGravity = -9.8f;


    private void Start()
    {
        Physics2D.gravity = new Vector2(0f, customGravity);

    }
    private void Update()
    {
        // Calculate the new position for the prefab
        Vector2 newPosition = transform.position - Vector3.up * moveSpeed * Time.deltaTime;

        // Update the position of the prefab
        transform.position = newPosition;


        //delete the object when it gets off screen
        if (this.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

}