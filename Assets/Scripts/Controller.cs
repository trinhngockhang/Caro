using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    int p = 1;
    static int twoOpen = 10;
    static int oneOpen = 4;
    static int triple = 1200;
    static int quadar = 3000;
    static int attack = 4;
    static int defende = 5;
    static int winAtFakeMove = 7000;
    bool firstMove = true;
    static  bool firstMax, firstMin;
    static int[] lastMove1 = new int[2];
    static int maxdepth = 2;
    static int[] alpha = new int[3];
    public static void MiniMax()
    {
        alpha[0] = -9999999;
        firstMax = true;
        firstMin = true;
        int[] bestMove = new int[2];
        int[,] miniMap = loadMap.BigMap;
        lastMove1[0] = CellScript.y;
        lastMove1[1] = CellScript.x;
        bestMove = Max(miniMap, 0, 0, 0);
        Debug.Log("best move " + bestMove[0] + bestMove[1] + "score " + bestMove[2]);
        loadMap.buttons[bestMove[0], bestMove[1]].onClick.Invoke();


    }
    public static int[] Max(int[,] Map, int depth, int lX, int lY)
    {
        int[] bestMoveMax = new int[3];
        int A, B, C, D;
        int maxScore = -99999999;
        int depthMax = depth;
        int score = 0;
        int[] MaxBorder = loadMap.Border;
        bool notFound = true;


        for (int i = (MaxBorder[0] - depth >= 0 ? MaxBorder[0] - depth : MaxBorder[0]);
            i <= (MaxBorder[1] + depth <= 9 ? MaxBorder[1] + depth : MaxBorder[1]); i++)
        {
            for (int j = (MaxBorder[2] - depth >= 0 ? MaxBorder[2] - depth : MaxBorder[2]);
             j <= (MaxBorder[3] + depth <= 9 ? MaxBorder[3] + depth : MaxBorder[3]); j++)
            {
                // neu o chua dc danh.
                score = 0;
                if (Map[j, i] == 0)
                {
                    Map[j, i] = 2;
                    if (loadMap.win(Map, j, i) && depthMax == 0)
                    {
                        bestMoveMax[0] = i;
                        bestMoveMax[1] = j;
                        Debug.Log(i + "  va " + j);
                        maxScore = 99999999;
                        bestMoveMax[2] = maxScore;
                        Map[j, i] = 0;
                        return bestMoveMax;
                    }
                    else if (depthMax >= 2)
                    {
                        score = caculate(Map, j, i) * attack;
                    }
                    else
                    {
                        //de quy

                        score = Min(Map, depthMax + 1, i, j)[2];

                        //Debug.Log("score from min " + score + " i " + i + " j " + j);
                    }
                    if (score > maxScore)
                    {
                        maxScore = score;
                        bestMoveMax[0] = i;
                        bestMoveMax[1] = j;
                        bestMoveMax[2] = maxScore;
                    }
                    alpha[depthMax] = maxScore;
                    // xoa nuoc di cho luot xet tiep
                    Map[j, i] = 0;
                }
            }
        }
        bestMoveMax[2] = maxScore;
        return bestMoveMax;
    }

    public static int[] Min(int[,] Map, int depth, int lX, int lY)
    {
        int[] bestMoveMin = new int[3];
        int score = 0;
        int depthMin = depth;
        int minScore = 9999999;
        int lastMaxX = lX;
        int[] MinBorder = loadMap.Border;
        int lastMaxY = lY;
        for (int i = (MinBorder[0] - depth >= 0 ? MinBorder[0] - depth : MinBorder[0]);
             i <= (MinBorder[1] + depth <= 9 ? MinBorder[1] + depth : MinBorder[1]); i++)
        {
            for (int j = (MinBorder[2] - depth >= 0 ? MinBorder[2] - depth : MinBorder[2]);
             j <= (MinBorder[3] + depth <= 9 ? MinBorder[3] + depth : MinBorder[3]); j++)
            {
                score = 0;
                if (Map[j, i] == 0)
                {
                    Map[j, i] = 1;
                    if (loadMap.win(Map, j, i) && depthMin == 1)
                    {
                        bestMoveMin[0] = i;
                        bestMoveMin[1] = j;
                        bestMoveMin[2] = -999999;
                        Debug.Log("thua " + i + "  va " + j + " last " + lastMaxX + "  " + lastMaxY);
                        Map[j, i] = 0;
                        return bestMoveMin;
                    }
                    // chon max
                    score = -caculate(Map, j, i) * defende;
                    score += Max(Map, depthMin + 1, i, j)[2];

                    // Debug.Log("soce min " + score);
                    if (score < minScore)
                    {
                        minScore = score;
                        bestMoveMin[0] = i;
                        bestMoveMin[1] = j;
                        bestMoveMin[2] = minScore;
                    }
                    alpha[depthMin] = minScore;
                    // xoa nuoc di cho luot xet tiep
                    Map[j, i] = 0;
                    if (depthMin > 0 )
                    {
                        if (minScore < alpha[depthMin - 1])
                        {
                            bestMoveMin[2] = minScore;
                            return bestMoveMin;
                        };
                    }
                }
            }
        }

        bestMoveMin[2] = minScore;
        return bestMoveMin;

    }


    public static int caculate(int[,] fakeMap, int posX, int posY)
    {

        int Count = 0;
        int x = posX;
        int y = posY;
        int i = x;
        int j = y;
        int score = 0, score1 = 0, score2 = 0, score3 = 0;
        bool start = false;
        bool end = false;

        if (fakeMap[x, y] != 0)
        {
            //xet theo chieu ngnag

            while (j < 10)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        start = true;
                    }
                    break;
                }
                j = j + 1;

            }
            j = y;
            Count = Count - 1;
            while (j >= 0)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        end = true;
                    }
                    break;
                }
                j = j - 1;
            }
            if (Count == 5) score3 += winAtFakeMove;
            if (start || end)
            {
                if (start && end)
                {
                    if (Count == 3) score1 = triple;
                    else if (Count == 4) score1 = quadar;
                    else score1 = (Count - 1) * twoOpen;
                }
                score1 += (Count - 1) * oneOpen;

            }

            // Xet chieu doc
            Count = 0; i = x; j = y;
            start = false; end = false;
            while (i < 10)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        start = true;
                    }
                    break;
                }
                i = i + 1;
            }
            i = x; Count = Count - 1;
            while (i >= 0)
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        end = true;
                    }
                    break;
                }
                i = i - 1;

            }
            if (Count == 5) score2 += winAtFakeMove;
            if (start || end)
            {
                if (start && end)
                {
                    if (Count == 3) score2 = triple;
                    else if (Count == 4) score2 = quadar;
                    else score2 = (Count - 1) * twoOpen;
                }
                score2 += (Count - 1) * oneOpen;

            }
            // Xet duong cheo
            Count = 0; i = x; j = y; start = false; end = false;
            while ((i < 10) && (j < 10))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        start = true;
                    }
                    break;
                }
                i = i + 1;
                j = j + 1;
            }
            Count = Count - 1; i = x; j = y;
            while ((i >= 0) && (j >= 0))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        end = true;
                    }
                    break;
                }
                i = i - 1;
                j = j - 1;
            }
            if (Count == 5) score3 += winAtFakeMove;
            if (start || end)
            {
                if (start && end)
                {
                    if (Count == 3) score3 += triple;
                    else if (Count == 4) score3 += quadar;
                    else score3 += (Count - 1) * twoOpen;
                }

                score3 += (Count - 1) * oneOpen;

            }

            //Xet duong cheo
            Count = 0; i = x; j = y; start = false; end = false;
            while ((i < 10) && (j >= 0))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        start = true;
                    }
                    break;
                }
                i = i + 1;
                j = j - 1;
            }
            Count = Count - 1; i = x; j = y;
            while ((i >= 0) && (j < 10))
            {
                if (fakeMap[x, y] == fakeMap[i, j])
                {
                    Count = Count + 1;
                }
                else
                {
                    if (fakeMap[i, j] == 0)
                    {
                        end = true;
                    }
                    break;
                }
                i = i - 1;
                j = j + 1;
            }
            if (Count == 5) score3 += winAtFakeMove;
            if (start || end)
            {
                if (start && end)
                {
                    if (Count == 3) score3 += triple;
                    else if (Count == 4) score3 += quadar;
                    else score3 += (Count - 1) * twoOpen;
                }
                else
                {
                    score3 += (Count - 1) * oneOpen;
                }
            }
        }
        score = score1 + score2 + score3;
        return score;
    }
}
