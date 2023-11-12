using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRange : MonoBehaviour
{
    [SerializeField] public List<Transform> Points;
    float leftX;
    float rightX;
    float upperY;
    float lowerY;
    // Start is called before the first frame update
    void Start()
    {
        leftX = Points[0].position.x;
        rightX = Points[1].position.x;
        upperY = Points[0].position.y;
        lowerY = Points[2].position.y;
    }

    public float RandomX()
    {
        return Random.Range(leftX, rightX);
    }
    public float RandomY()
    {
        return Random.Range(lowerY, upperY);
    }

}
