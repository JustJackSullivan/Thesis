using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingAndRotating : MonoBehaviour
{

    public float rotationSpeed = 45f;


    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1f; 


    private Vector3 startPosition;


    void Start()
    {

        startPosition = transform.position;
    }

    void Update()
    {

  
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);


        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;


        transform.position = new Vector3(startPosition.x, newY, startPosition.z);


    }




}
