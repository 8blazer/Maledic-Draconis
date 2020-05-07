using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

    public GameObject prefab;
    System.Random rnd = new System.Random();
    List<string> direction = new List<string>();
    static public List<string> open = new List<string>();
    float i = 0;
    int iConverter;
    float startX = .5f;
    float startY = .5f;
    static public float permaStartX;
    static public float permaStartY;
    float goalX;
    float goalY;
    float tempX;
    float tempY;
    float x = -49.5f;
    float y = 49.5f;
    // Start is called before the first frame update
    void Start()
    {
        while (i < 10000) //Generates the tiles
        {
            Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
            if (x == 49.5)
            {
                x = -49.5f;
                y--;
            }
            else
            {
                x++;
            }
            i++;
        }
        goalX = rnd.Next(0, 41);
        goalY = 40 - goalX;
        i = rnd.Next(1, 3);
        if (i == 1)
        {
            goalX = goalX * -1;
        }
        i = rnd.Next(1, 3);
        if (i == 1)
        {
            goalY = goalY * -1;
        }
        goalX = goalX + .5f;
        goalY = goalY + .5f;
        open.Add(startX + " " + startY);
        while (startX != goalX || startY != goalY) //Creates the path from the start to the goal
        {
            if (startX > goalX)
            {
                i = startX - goalX;
                while (i > 0)
                {
                    direction.Add("Left");
                    i--;
                }
                direction.Add("Right");
            }
            if (goalX > startX)
            {
                i = goalX - startX;
                while (i > 0)
                {
                    direction.Add("Right");
                    i--;
                }
                direction.Add("Left");
            }
            if (startY > goalY)
            {
                i = startY - goalY;
                while (i > 0)
                {
                    direction.Add("Down");
                    i--;
                }
                direction.Add("Up");
            }
            if (goalY > startY)
            {
                i = goalY - startY;
                while (i > 0)
                {
                    direction.Add("Up");
                    i--;
                }
                direction.Add("Down");
            }
            i = rnd.Next(0, direction.Count);
            iConverter = (int)i;
            if (direction[iConverter] == "Right" && startX != 49.5f)
            {
                startX++;
            }
            else if (direction[iConverter] == "Left" && startX != -49.5f)
            {
                startX--;
            }
            else if (direction[iConverter] == "Up" && startY != 49.5f)
            {
                startY++;
            }
            else if (startY != -49.5f)
            {
                startY--;
            }
            direction.Clear();
            if (!open.Contains(startX + " " + startY))
            {
                open.Add(startX + " " + startY);
            }
        }
        //Hallway generator
        i = rnd.Next(0, 5);
        List<int> hallways = new List<int>();
        while (hallways.Count != i)
        {
            int foo = rnd.Next(0, open.Count + 1);
            if (!hallways.Contains(foo))
            {
                hallways.Add(foo);
            }
        }
        while (hallways.Count > 0)
        {
            i = rnd.Next(1, 5);
            string[] points = open[hallways[0]].Split(' ');
            tempX = float.Parse(points[0]);
            tempY = float.Parse(points[1]);
            if (i == 1 && tempX < 40.5)
            {
                open.Add((tempX + 1) + " " + tempY);
                open.Add((tempX + 2) + " " + tempY);
                open.Add((tempX + 3) + " " + tempY);
                open.Add((tempX + 4) + " " + tempY);
                open.Add((tempX + 5) + " " + tempY);
                open.Add((tempX + 6) + " " + tempY);
                open.Add((tempX + 7) + " " + tempY);
                open.Add((tempX + 8) + " " + tempY);
            }
            else if (i == 2 && tempX > -40.5)
            {
                open.Add((tempX - 1) + " " + tempY);
                open.Add((tempX - 2) + " " + tempY);
                open.Add((tempX - 3) + " " + tempY);
                open.Add((tempX - 4) + " " + tempY);
                open.Add((tempX - 5) + " " + tempY);
                open.Add((tempX - 6) + " " + tempY);
                open.Add((tempX - 7) + " " + tempY);
                open.Add((tempX - 8) + " " + tempY);
            }
            else if (i == 3 && tempY < 40.5)
            {
                open.Add(tempX + " " + (tempY + 1));
                open.Add(tempX + " " + (tempY + 2));
                open.Add(tempX + " " + (tempY + 3));
                open.Add(tempX + " " + (tempY + 4));
                open.Add(tempX + " " + (tempY + 5));
                open.Add(tempX + " " + (tempY + 6));
                open.Add(tempX + " " + (tempY + 7));
                open.Add(tempX + " " + (tempY + 8));
            }
            else if (tempY > -40.5)
            {
                open.Add(tempX + " " + (tempY - 1));
                open.Add(tempX + " " + (tempY - 2));
                open.Add(tempX + " " + (tempY - 3));
                open.Add(tempX + " " + (tempY - 4));
                open.Add(tempX + " " + (tempY - 5));
                open.Add(tempX + " " + (tempY - 6));
                open.Add(tempX + " " + (tempY - 7));
                open.Add(tempX + " " + (tempY - 8));
            }
            hallways.RemoveAt(0);
        }
        //Width generator
        i = 0;
        int tempCount = open.Count;
        while (iConverter < tempCount)
        {
            string[] points = open[iConverter].Split(' ');
            tempX = float.Parse(points[0]);
            tempY = float.Parse(points[1]);
            i = rnd.Next(1, 8);
            if (i > 3)
            {
                open.Add((tempX + 1) + " " + tempY);
                open.Add((tempX - 1) + " " + tempY);
                open.Add(tempX + " " + (tempY + 1));
                open.Add(tempX + " " + (tempY - 1));
                open.Add((tempX + 1) + " " + (tempY + 1));
                open.Add((tempX - 1) + " " + (tempY - 1));
                open.Add((tempX + 1) + " " + (tempY - 1));
                open.Add((tempX - 1) + " " + (tempY + 1));
            }
            if (i == 7)
            {
                open.Add((tempX + 2) + " " + tempY);
                open.Add((tempX - 2) + " " + tempY);
                open.Add(tempX + " " + (tempY + 2));
                open.Add(tempX + " " + (tempY - 2));
                open.Add((tempX + 2) + " " + (tempY + 2));
                open.Add((tempX - 2) + " " + (tempY - 2));
                open.Add((tempX + 2) + " " + (tempY - 2));
                open.Add((tempX - 2) + " " + (tempY + 2));
                open.Add((tempX + 1) + " " + (tempY + 2));
                open.Add((tempX - 1) + " " + (tempY - 2));
                open.Add((tempX + 2) + " " + (tempY - 1));
                open.Add((tempX - 2) + " " + (tempY + 1));
            }
            iConverter++;
        }
    }
}