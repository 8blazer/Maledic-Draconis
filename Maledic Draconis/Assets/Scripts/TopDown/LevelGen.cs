using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGen : MonoBehaviour
{

    public GameObject prefab;
    public static List<GameObject> squares = new List<GameObject>();
    System.Random rnd = new System.Random();
    List<string> direction = new List<string>();
    static public List<string> open = new List<string>();
    float i = 0;
    int iConverter;
    float startX = .5f;
    float startY = .5f;
    static public float permaStartX;
    static public float permaStartY;
    float midX;
    float midY;
    static public float goalX;
    static public float goalY;
    float tempX;
    float tempY;
    float x = -49.5f;
    float y = 49.5f;
    public GameObject slimePrefab;
    public GameObject wolfPrefab;
    public GameObject treePrefab;
    public GameObject koboldPrefab;
    public GameObject koboldArcherPrefab;
    static public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        while (i < 10000) //Generates the tiles
        {
            GameObject square = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
            squares.Add(square);
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
        //Adding a middle point
        i = rnd.Next(1, 3);
        if (i == 1)
        {
            midX = goalX;
            i = rnd.Next(0, 7);
            midX = midX - i - 3;
            if (startY > goalY)
            {
                midY = startY - goalY;
                iConverter = (int)midY;
                i = rnd.Next(1, iConverter);
                midY = startY - iConverter;
            }
            else
            {
                midY = goalY - startY;
                iConverter = (int)midY;
                i = rnd.Next(0, iConverter);
                midY = iConverter - startY;
            }
            i = rnd.Next(1, 3);
            if (i == 1)
            {
                midY = midY * -1;
            }
        }
        else
        {
            midY = goalY;
            i = rnd.Next(0, 7);
            midY = midY - i - 3;
            if (startX > goalX)
            {
                midX = startX - goalX;
                iConverter = (int)midX;
                i = rnd.Next(1, iConverter);
                midX = startX - iConverter;
            }
            else
            {
                midX = goalX - startX;
                iConverter = (int)midX;
                i = rnd.Next(0, iConverter);
                midX = iConverter - startX;
            }
            i = rnd.Next(1, 3);
            if (i == 1)
            {
                midX = midX * -1;
            }
        }
        open.Add(startX + " " + startY);
        while (startX != midX || startY != midY) //Creates the path from the start to the middle
        {
            if (startX > midX)
            {
                i = startX - midX;
                while (i > 0)
                {
                    direction.Add("Left");
                    i--;
                }
                direction.Add("Right");
            }
            if (midX > startX)
            {
                i = midX - startX;
                while (i > 0)
                {
                    direction.Add("Right");
                    i--;
                }
                direction.Add("Left");
            }
            if (startY > midY)
            {
                i = startY - midY;
                while (i > 0)
                {
                    direction.Add("Down");
                    i--;
                }
                direction.Add("Up");
            }
            if (midY > startY)
            {
                i = midY - startY;
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
        while (startX != goalX || startY != goalY) //Creates the path from the middle to the goal
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
        i = rnd.Next(0, 6);
        List<int> hallways = new List<int>();
        while (hallways.Count != i)
        {
            int foo = rnd.Next(0, open.Count);
            if (!hallways.Contains(foo))
            {
                hallways.Add(foo);
            }
        }
        while (hallways.Count > 0)
        {
            i = rnd.Next(1, 5);
            string[] points = open[hallways[0]].Split(' ');  //
            tempX = float.Parse(points[0]);
            tempY = float.Parse(points[1]);
            if (i == 1 && tempX < 40.5)
            {
                for (i = 1; i < (40.5 - tempX) / 2; i++)
                {
                    open.Add((tempX + i) + " " + tempY);
                    iConverter = rnd.Next(1, 8);
                    if (iConverter == 1)
                    {
                        open.Add((tempX + i) + " " + (tempY + 1));
                    }
                    else if (iConverter == 2)
                    {
                        open.Add((tempX + i) + " " + (tempY - 1));
                    }
                }
            }
            else if (i == 2 && tempX > -40.5)
            {
                for (i = 1; i < (tempX - 40.5) / 2; i++)
                {
                    open.Add((tempX - i) + " " + tempY);
                    iConverter = rnd.Next(1, 8);
                    if (iConverter == 1)
                    {
                        open.Add((tempX - i) + " " + (tempY + 1));
                    }
                    else if (iConverter == 2)
                    {
                        open.Add((tempX - i) + " " + (tempY - 1));
                    }
                }
            }
            else if (i == 3 && tempY < 40.5)
            {
                for (i = 1; i < (40.5 - tempY) / 2; i++)
                {
                    open.Add(tempX + " " + (tempY + i));
                    iConverter = rnd.Next(1, 8);
                    if (iConverter == 1)
                    {
                        open.Add((tempX + 1) + " " + (tempY + i));
                    }
                    else if (iConverter == 2)
                    {
                        open.Add((tempX - 1) + " " + (tempY + i));
                    }
                }
            }
            else if (tempY > -40.5)
            {
                for (i = 1; i < (tempY - 40.5) / 2; i++)
                {
                    open.Add(tempX + " " + (tempY - i));
                    iConverter = rnd.Next(1, 8);
                    if (iConverter == 1)
                    {
                        open.Add((tempX + 1) + " " + (tempY - i));
                    }
                    else if (iConverter == 2)
                    {
                        open.Add((tempX - 1) + " " + (tempY - i));
                    }
                }
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
            i = rnd.Next(1, 12);
            if (i > 5)
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
            if (i > 8)
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
            if (i == 12)
            {
                open.Add((tempX + 3) + " " + tempY);
                open.Add((tempX - 3) + " " + tempY);
                open.Add(tempX + " " + (tempY + 3));
                open.Add(tempX + " " + (tempY - 3));
                open.Add((tempX + 3) + " " + (tempY + 3));
                open.Add((tempX - 3) + " " + (tempY - 3));
                open.Add((tempX + 3) + " " + (tempY - 3));
                open.Add((tempX - 3) + " " + (tempY + 3));
                open.Add((tempX + 2) + " " + (tempY + 3));
                open.Add((tempX - 2) + " " + (tempY - 3));
                open.Add((tempX + 3) + " " + (tempY - 2));
                open.Add((tempX - 3) + " " + (tempY + 2));
                open.Add((tempX + 1) + " " + (tempY + 3));
                open.Add((tempX - 1) + " " + (tempY - 3));
                open.Add((tempX + 3) + " " + (tempY - 1));
                open.Add((tempX - 3) + " " + (tempY + 1));
            }
            iConverter++;
        }

        //Enemy Generator
        enemyCount = open.Count / 70;
        enemyCount = enemyCount + rnd.Next(-2, 3);
        if (enemyCount < 5)
        {
            enemyCount = 5;
        }
        int enemyChoice;
        float enemyX;
        float enemyY;
        i = 0;
        while (i < enemyCount)
        {
            if (SceneManager.GetActiveScene().name == "TopDown")
            {
                enemyChoice = rnd.Next(1, 5);
                iConverter = rnd.Next(1, open.Count);
                string[] enemyCords = open[iConverter].Split(' ');
                enemyX = float.Parse(enemyCords[0]);
                enemyY = float.Parse(enemyCords[1]);
                if (enemyChoice < 3)
                {
                    GameObject slime = Instantiate(slimePrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, slime.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        slime.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                else if (enemyChoice == 4)
                {
                    GameObject wolf = Instantiate(wolfPrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, wolf.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        wolf.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                else
                {
                    GameObject tree = Instantiate(treePrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, tree.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        tree.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                i++;
            }
            else
            {
                enemyChoice = rnd.Next(1, 5);
                iConverter = rnd.Next(1, open.Count);
                string[] enemyCords = open[iConverter].Split(' ');
                enemyX = float.Parse(enemyCords[0]);
                enemyY = float.Parse(enemyCords[1]);
                if (enemyChoice < 3)
                {
                    GameObject wolf = Instantiate(wolfPrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, wolf.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        wolf.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                else if (enemyChoice == 4)
                {
                    GameObject kobold = Instantiate(koboldPrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, kobold.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        kobold.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                else
                {
                    GameObject koboldArcher = Instantiate(koboldArcherPrefab, new Vector3(enemyX, enemyY, 0), Quaternion.identity);
                    while (Vector3.Distance(prefab.transform.position, koboldArcher.transform.position) < 10)
                    {
                        iConverter = rnd.Next(1, open.Count);
                        enemyCords = open[iConverter].Split(' ');
                        enemyX = float.Parse(enemyCords[0]);
                        enemyY = float.Parse(enemyCords[1]);
                        koboldArcher.transform.position = new Vector3(enemyX, enemyY, 0);
                    }
                }
                i++;
            }
        }
    }
}