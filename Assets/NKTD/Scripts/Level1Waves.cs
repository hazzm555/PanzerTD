using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Waves : MonoBehaviour
{

    public static int [][] Waves/* = { new int[] {0,0},
    new int[] {0,0,0,0},
    new int[] {0,0,0,0,0,0,0}} */;
    public static int WaveNumbers = 4;

    private void Awake()
    {
        Waves = new int[WaveNumbers][];

        Waves[0] = new int[10];// wave number = 0 , wave size 2
        Waves[0][0] = 0;
        Waves[0][1] = 0;
        Waves[0][2] = 0;
        Waves[0][3] = 0;
        Waves[0][4] = 0;
        Waves[0][5] = 0;
        Waves[0][6] = 0;
        Waves[0][7] = 0;
        Waves[0][8] = 0;
        Waves[0][9] = 1;

        Waves[1] = new int[20];
        Waves[1][0] = 1;
        Waves[1][1] = 1;
        Waves[1][2] = 1;
        Waves[1][3] = 0;
        Waves[1][4] = 1;
        Waves[1][5] = 0;
        Waves[1][6] = 1;
        Waves[1][7] = 1;
        Waves[1][8] = 1;
        Waves[1][9] = 1;
        Waves[1][10] = 1;
        Waves[1][11] = 2;
        Waves[1][12] = 1;
        Waves[1][13] = 0;
        Waves[1][14] = 1;
        Waves[1][15] = 0;
        Waves[1][16] = 1;
        Waves[1][17] = 2;
        Waves[1][18] = 1;
        Waves[1][19] = 2;

        Waves[2] = new int[13];
        Waves[2][0] = 3;
        Waves[2][1] = 1;
        Waves[2][2] = 0;
        Waves[2][3] = 3;
        Waves[2][4] = 1;
        Waves[2][5] = 0;
        Waves[2][6] = 3;
        Waves[2][7] = 1;
        Waves[2][8] = 0;
        Waves[2][9] = 3;
        Waves[2][10] = 1;
        Waves[2][11] = 0;
        Waves[2][12] = 3;

        Waves[3] = new int[9];
        Waves[3][0] = 5;
        Waves[3][1] = 5;
        Waves[3][2] = 6;
        Waves[3][3] = 6;
        Waves[3][4] = 7;
        Waves[3][5] = 7;
        Waves[3][6] = 8;
        Waves[3][7] = 8;
        Waves[3][8] = 8;

    }
}