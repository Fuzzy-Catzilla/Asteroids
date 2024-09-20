using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int health = 6;
    [SerializeField] private int damage = 1;
    [SerializeField] private Vector2 speedRange = new (1f, 2f);
    [SerializeField] private float maxTorque = 10f;

    private CircleCollider2D cc;
    private Transform sprite;
    private float speed = 0f;
    private float torque = 0;
    private float damageTaken = 0;
    private ParticleSystem sparks;


    private void Start()
    { 
        sprite = transform.GetChild(0);
        speed = Random.Range(speedRange.x, speedRange.y);
        torque = Random.Range(-maxTorque, maxTorque);
        sparks = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        AsteroidMovement();
        
    }

    private void AsteroidMovement()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        sprite.Rotate(Vector3.forward, torque * Time.deltaTime);
    }

    public void RecieveDamage(float damage)
    {
        damageTaken += damage;
        sparks.Play();
        Debug.Log(damageTaken);
        if (damageTaken >= health)
        {
            //spawn asteroid bits
            //sounds
            Destroy(gameObject);
        }
    }
}
