using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer psr;
    [SerializeField] private List<Sprite> asteroidSprites = new();

    private SpriteRenderer sr;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Count)];
    }
}
