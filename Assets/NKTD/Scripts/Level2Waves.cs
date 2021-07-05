using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Waves : MonoBehaviour
{
    public static int[][] Waves/* = { new int[] {0,0},
    new int[] {0,0,0,0},
    new int[] {0,0,0,0,0,0,0}} */;
    public static int WaveNumbers = 5;

    private void Awake()
    {
        Waves = new int[WaveNumbers][];

        Waves[0] = new int[9];// wave number = 0 , wave size 2
        Waves[0][0] = 0;
        Waves[0][1] = 0;
        Waves[0][2] = 0;
        Waves[0][3] = 0;
        Waves[0][4] = 0;
        Waves[0][5] = 0;
        Waves[0][6] = 0;
        Waves[0][7] = 1;
        Waves[0][8] = 1;

        Waves[1] = new int[10];
        Waves[1][0] = 1;
        Waves[1][1] = 1;
        Waves[1][2] = 1;
        Waves[1][3] = 1;
        Waves[1][4] = 1;
        Waves[1][5] = 2;
        Waves[1][6] = 2;
        Waves[1][7] = 2;
        Waves[1][8] = 2;
        Waves[1][9] = 2;


        Waves[2] = new int[10];
        Waves[2][0] = 6;
        Waves[2][1] = 5;
        Waves[2][2] = 4;
        Waves[2][3] = 3;
        Waves[2][4] = 2;
        Waves[2][5] = 1;
        Waves[2][6] = 1;
        Waves[2][7] = 2;
        Waves[2][8] = 3;
        Waves[2][9] = 4;

        Waves[3] = new int[5];
        Waves[3][0] = 6;
        Waves[3][1] = 5;
        Waves[3][2] = 6;
        Waves[3][3] = 6;
        Waves[3][4] = 9;
        

        Waves[4] = new int[5];
        Waves[4][0] = 9;
        Waves[4][1] = 9;
        Waves[4][2] = 9;
        Waves[4][3] = 9;
        Waves[4][4] = 9;
        
    }

    
}
