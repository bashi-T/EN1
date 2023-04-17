using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;
    int PlayerIndex = -1;
    string DebugText = "";

    void printArray()
    {
        string debugText = "";
        for(int i = 0; i < map.GetLength(0); i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for(int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom,int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }

        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            if (!success)
            {
                return false;
            }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }






    // Start is called before the first frame update
    void Start()
    {

        map = new int[] { 0,0,0,1,0,2,0,0,0,0 };

        printArray(); 
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           int PlayerIndex = GetPlayerIndex();

            MoveNumber(1, PlayerIndex, PlayerIndex + 1);

            printArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int PlayerIndex = GetPlayerIndex();

            MoveNumber(1, PlayerIndex, PlayerIndex - 1);

            printArray();
        }


    }
}
