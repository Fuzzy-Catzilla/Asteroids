using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 3;

    [SerializeField] private int damage = 1;

    private ParticleSystem sparks;

    private float damageTaken = 0;


    // Start is called before the first frame update
    void Start()
    {
        sparks = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        damageTaken += damage;
        sparks.Play();
        Debug.Log(damageTaken);
        if (damageTaken >= health)
        {
            //Game Over
            Destroy(gameObject);
        }

    }
}
