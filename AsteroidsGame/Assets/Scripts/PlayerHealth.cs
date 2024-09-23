using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 3;

    //private ParticleSystem sparks;

    private float damageTaken = 0;


    void Start()
    {
        //sparks = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            damageTaken += asteroid.damage;
            //sparks.Play();
            Debug.Log(damageTaken);
        }
        if (damageTaken >= health)
        {
            //Game Over
            Destroy(gameObject);
        }
    }
}
