using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float lerpSpeed = 25.0f;
    [SerializeField] float positionX = 2.25f;

    private void OnEnable()
    {
        InputManager.instance.keyAction += Move;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void Update()
    {
        Status();
    }

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine > RoadLine.LEFT)
            {                
                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine < RoadLine.RIGHT)
            {
                roadLine++;
            }
        }
    }

    public void Status()
    {
        switch(roadLine)
        {
            case RoadLine.LEFT : Movement(-positionX);
                break;
            case RoadLine.MIDDLE : Movement(0);
                break;
            case RoadLine.RIGHT : Movement(positionX);
                break;
        }
    }

    public void Movement(float positionX)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0, 0), lerpSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }
}
