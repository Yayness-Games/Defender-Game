using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float rotationRandomness = .1f;

    void Start()
    {
        rotationSpeed += Random.Range(rotationSpeed + rotationRandomness, rotationSpeed - rotationRandomness);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, rotationSpeed);
    }
}
