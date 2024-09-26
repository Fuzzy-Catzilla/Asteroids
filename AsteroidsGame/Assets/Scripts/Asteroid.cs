using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int health = 6;
    [SerializeField] private Vector2 speedRange = new (1f, 2f);
    [SerializeField] private float maxTorque = 10f;
    [SerializeField] private float autoClean = 15f;

    public int damage = 1;

    private CircleCollider2D cc;
    private Transform sprite;
    private ParticleSystem sparks;
    private float speed = 0f;
    private float torque = 0;

    private float damageTaken = 0;


    private void Start()
    { 
        cc = GetComponent<CircleCollider2D>();
        sprite = transform.GetChild(0);
        sparks = GetComponentInChildren<ParticleSystem>();
        speed = Random.Range(speedRange.x, speedRange.y);
        torque = Random.Range(-maxTorque, maxTorque);

        Destroy(gameObject, autoClean);
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
        if (damageTaken < health)
        {
            damageTaken += damage;
            sparks.Play();
            transform.localScale -= (Vector3.one * 0.05f);
        }
        if (damageTaken >= health)
        {
            //spawn asteroid bits
            //sounds
            sparks.Play();
            cc.enabled = false;
            sprite.gameObject.SetActive(false);
            Destroy(gameObject, sparks.main.duration);
        }
    }
}
