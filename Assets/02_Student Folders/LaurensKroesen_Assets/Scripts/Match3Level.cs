using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3Level : MonoBehaviour
{
    // 0 == empty
    // 1 == cube
    // 2 == ball
    public GameObject next_wp_target;

    public GameObject player;
    
    public GameObject enemy;
    public GameObject activeEnemy;
    public GameObject[] spawnpoints = new GameObject[2];
    
    public GameObject[] location_squares = new GameObject[9];
    public GameObject player_piece;
    public GameObject ai_piece;
    public ArrayList instances; 
    public int[] squares = new int[]
    {
      //0 1 2
      //3 4 5
      //6 7 8
        0, 0, 0,
        0, 0, 0,
        0, 0, 0
    };

    public bool playerWin = false;
    public bool AIwin = false;

    private int block_this_square = -1;

    
    public bool computer_turn = false;
    
    // AI Rules:
    // 1. Prevent a Match 3. (Told to the AI by "checkformatch3 functions"
    // 2. Place in middle if open
    // 3. Put in random spot.
    
    // Start is called before the first frame update
    void Start()
    {
        instances = new ArrayList();
    }

    public bool isEnemyDead = true;

    void Update()
    {
        if (!isEnemyDead)
        {
            if (activeEnemy == null)
            {
                isEnemyDead = true;
            }
        }
    }
    
    void winDetected()
    {
        if (AIwin)
        {
            // Spawn enemy in one of 2 spawnpoints, then clear board when killed.
            if (isEnemyDead)
            {
                isEnemyDead = false;
                activeEnemy = Instantiate(enemy, spawnpoints[new System.Random().Next(0,2)].transform);
            }
            resetField();
        }
        else if (playerWin)
        {
            // TODO: Delete field and spawn end game trigger?
            foreach (var locationSquare in location_squares)
            {
                Destroy(locationSquare);
            }

            foreach (GameObject instance in instances)
            {
                Destroy(instance);
            }
            
            // Spawn the end goal.
            next_wp_target.transform.position = player.transform.position;
        }
    }

    void stalemate()
    {
        int c = 0;
        foreach (var square in squares)
        {
            if (square == 0)
                c++;
        }

        if (c == 0)
        {
            Debug.Log("Stalemate detected!");
            resetField();
        }
    }

    void resetField()
    {
        Debug.Log("Resetting Field!");
        
        foreach (GameObject instance in instances)
        {
            Destroy(instance);
        }

        AIwin = false;
        playerWin = false;
        squares = new []
        {
            0, 0, 0,
            0, 0, 0,
            0, 0, 0
        };
        playerWin = false;
        block_this_square = -1;
        timePassed = 0;
    }

    // TODO: Spawn End Level Marker.
    void activateSquare()
    {
        bool hor = checkForMatch3Horizontal();
        
        if (hor)
            winDetected();
        
        bool dia = checkForMatch3Diagonals();
        
        if (dia)
            winDetected();
        
        bool vert = checkForMatch3Verticals();
        
        if (vert)
            winDetected();
    }

    public void AIMove()
    {
        if (playerWin || AIwin)
            return;
        
        if (block_this_square != -1)
        {
            Debug.Log("Run defence!");
            AISelection(block_this_square);
            block_this_square = -1;
        }
        else if (squares[4] == 0)
        {
            Debug.Log("Middle is open, picking it!");
            AISelection(4);
        }
        else
        {
            var availble = new ArrayList();
            for (int c = 0; c < 9; c++)
            {
                if (squares[c] == 0)
                    availble.Add(c);
            }

            if (availble.Count == 0)
            {
                stalemate();
                return;
            }
            
            var rng = new System.Random();
            Debug.Log("Selecting Random Square...");
            int got = (int) availble[rng.Next(0, availble.Count)];
            Debug.Log("Got: " + got);
            AISelection(got);
        }
    }

    void AISelection(int c)
    {
        Debug.Log("AI SELECTED: " + c);
        
        var t = location_squares[c].transform.position;
        t.z -= 0.5f;
        var b = Instantiate(ai_piece, t, location_squares[c].transform.rotation);
        instances.Add(b);
        
        squares[c] = -1;
        
        activateSquare();
    }

    public void playerSelection(int c)
    {
        if (!isEnemyDead)
            return;
        
        if (playerWin || AIwin)
            return;
        
        // if Square is up for grabs allow player to take it.
        if (squares[c] == 0)
        {
            squares[c] = 1;
            var t = location_squares[c].transform.position;
            t.z -= 0.5f;
            
            var b = Instantiate(player_piece, t, location_squares[c].transform.rotation);
            instances.Add(b);
            
            activateSquare();
            
            AIMove();
        }
    }

    void findBlockMove(int a, int b, int c)
    {
        Debug.Log("Player is almost at a match 3, on: " + a + b + c);
        
        if (squares[a] == 0)
            block_this_square = a;
        else if (squares[b] == 0)
            block_this_square = b;
        else if (squares[c] == 0)
            block_this_square = c;
        else
            Debug.LogError("Something is wrong with this method");
    }

    bool checkForMatch3Horizontal()
    {
        // 0 1 2
        // (c*3) 3  (c*3)+1 4 5
        // (c*3) 6 7 8
        
        // check horizontals
        for (int c = 0; c < 3; c++)
        {
            int a = c * 3;
            int sum = squares[a] + squares[a + 1] + squares[a + 2];

            switch (sum)
            {
                case 3 :
                    playerWin = true;
                    break;
                case 2 : findBlockMove(a, a+1, a+2);
                    break;
                case -3:
                    AIwin = true;
                    break;
            }
        }

        return playerWin || AIwin;
    }

    bool checkForMatch3Verticals()
    {
        // C  c+3  c+6
        // 0   3   6
        // 1   4   7
        // 2   5   8
        for (int c = 0; c < 3; c++)
        {
            int sum = squares[c] + squares[c + 3] + squares[c + 6];

            switch (sum)
            {
                case 3 :
                    playerWin = true;
                    break;
                case 2 : findBlockMove(c, c+3, c+6);
                    break;
                case -3:
                    AIwin = true;
                    break;
            }
        }

        return playerWin || AIwin;
    }

    bool checkForMatch3Diagonals()
    {
        // 0 4 8
        // 2 4 6
        int sum_1 = squares[0] + squares[4] + squares[8];
        int sum_2 = squares[2] + squares[4] + squares[6];
        
        switch (sum_1)
        {
            case 3 :
                playerWin = true;
                break;
            case 2 : findBlockMove(0, 4, 8);
                break;
            case -3:
                AIwin = true;
                break;
        }
        
        switch (sum_2)
        {
            case 3 : playerWin = true; break;
            case 2 : findBlockMove(2, 4, 6);   break;
            case -3: AIwin = true; break;
        }

        return playerWin || AIwin;
    }

    public float timeout = 1;
    public float timePassed = 0;
}
