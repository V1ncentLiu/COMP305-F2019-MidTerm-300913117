using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class Island2Controller : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;
    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        Vector2 newPos = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPos = transform.position;
        currentPos -= newPos;
        transform.position = currentPos;
    }
    void Reset()
    {
        float randYPos = Random.Range(boundary.Bottom, boundary.Top);
        transform.position = new Vector2(boundary.Right, randYPos);
    }
    void CheckBounds()
    {
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }
}
