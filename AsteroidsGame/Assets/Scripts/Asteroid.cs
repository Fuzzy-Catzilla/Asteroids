using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxTorque = 10f;

    public float torque = 0;
    private Transform sprite;


    private void Start()
    {
        sprite = transform.GetChild(0);
        torque = Random.Range(-maxTorque, maxTorque);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        sprite.Rotate(Vector3.forward , torque * Time.deltaTime);
    }
}
