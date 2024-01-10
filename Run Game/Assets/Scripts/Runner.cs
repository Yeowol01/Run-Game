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

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine <= RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else
            {
                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine >= RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else
            {
                roadLine++;
            }
        }
    }
}
