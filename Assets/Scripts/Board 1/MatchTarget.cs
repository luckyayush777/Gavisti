using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorStruct {
    public float _r;
    public float _g;
    public float _b;
    public ColorStruct(float red, float green, float blue)
    {
        _r = red;
        _g = green;
        _b = blue;
    }
}

public class MatchTarget : MonoBehaviour
{
    public ColorStruct colorOnTarget;
    void Start()
    {
        ColorStruct color = GenRandomNumbers();
        GetComponent<MeshRenderer>().material.color = new Color(color._r, color._g, color._b);

    }
    void Update()
    {
        
    }

    private ColorStruct GenRandomNumbers()
    {
        int randomR = Random.Range(0, 5);
        int randomG = Random.Range(0, 5);
        int randomB = Random.Range(0, 5);

        float randomRed = randomR * 0.25f;
        float randomGreen = randomG* 0.25f;
        float randomBlue = randomB * 0.25f;
        colorOnTarget = new ColorStruct(randomRed, randomGreen, randomBlue);
        return colorOnTarget;
    }
}
