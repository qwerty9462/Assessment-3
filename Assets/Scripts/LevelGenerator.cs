using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject oldmap;
    public GameObject NormalPellet;
    public GameObject PowerPellet;
    //public RuleTile rule;
    public Tile[] tile;
    public Tilemap map;
    public Grid parent;
    //public Sprite[] maptile;
    //public Grid map;
    void Start()
    {
        //Destroy(oldmap);
        generate();
    }

    private void generate()
    {
        int[,] levelMap =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},//15
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},

         };
        Matrix4x4 turn0 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
        Matrix4x4 turn90 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
        Matrix4x4 turn180 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 180f), Vector3.one);
        Matrix4x4 turn270 = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 270f), Vector3.one);
        Matrix4x4 flipY = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 180f, 0f), Vector3.one);
        Matrix4x4 flipX = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 0f, 0f), Vector3.one);
        Matrix4x4 flipXY = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(180f, 180f, 0f), Vector3.one);
        bool ConnectUp(int i, int j)
        {          
            if (levelMap[i - 1, j] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i - 1, j] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i - 1, j] == levelMap[i, j]) return true;
            return false;
        }
        bool ConnectUpRight(int i, int j)
        {
            if (levelMap[i - 1, j+1] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i - 1, j+1] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i - 1, j+1] == levelMap[i, j]) return true;
            return false;
        }
        bool ConnectUpLeft(int i, int j)
        {
            if (levelMap[i - 1, j-1] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i - 1, j-1] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i - 1, j-1] == levelMap[i, j]) return true;
            return false;
        }
        bool ConnectDown(int i, int j)
        {
            if (levelMap[i + 1, j] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i + 1, j] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i + 1, j] == levelMap[i, j]) return true;
            return false;
        }
        bool ConnectRight(int i, int j)
        {           
            if (levelMap[i, j + 1] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i, j + 1] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i, j + 1] == levelMap[i, j]) return true;
            return false;
        }
        bool ConnectLeft(int i, int j)
        {           
            if (levelMap[i, j - 1] == 2 && levelMap[i, j] == 1) return true;
            if (levelMap[i, j - 1] == 4 && levelMap[i, j] == 3) return true;
            if (levelMap[i, j - 1] == levelMap[i, j]) return true;
            return false;
        }
        bool UpIsPath(int i, int j)
        {
            if (levelMap[i - 1, j] == 5 || levelMap[i - 1, j] == 6 || levelMap[i - 1, j] == 0) return true;
            return false;
        }
        bool UpRightIsPath(int i, int j)
        {
            if (levelMap[i - 1, j+1] == 5 || levelMap[i - 1, j+1] == 6 || levelMap[i - 1, j+1] == 0 || levelMap[i - 1, j + 1] == 4) return true;
            return false;
        }
        bool DownIsPath(int i, int j)
        {
            if (levelMap[i + 1, j] == 5 || levelMap[i + 1, j] == 6 || levelMap[i + 1, j] == 0) return true;
            return false;
        }

        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                map.SetTile(new Vector3Int(-i, j, 0), tile[levelMap[i, j]]);
                if (levelMap[i, j] == 1)
                {
                    //Debug.Log("try turn");
                    //Debug.Log("i="+i+ "j=" + j);
                    if (i == 19 && j == 0) {
                        //pass
                    }
                    else if (j == 27)
                    {
                        if (i == 0 || i == 19) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);
                        else if (i == 9 || i == 28) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);                        
                    }
                    else if (i == 0 && j == 0)
                    {
                        //Debug.Log("pass");
                    }
                    else if (levelMap[i - 1, j] == 2 && levelMap[i, j + 1] == 2)
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                        //Debug.Log("turned90");                      
                    }
                    else if (levelMap[i - 1, j] == 2 && levelMap[i, j - 1] == 2)
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);
                        //Debug.Log("turned180");
                    }
                    else if (levelMap[i + 1, j] == 2 && levelMap[i, j - 1] == 2)
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);
                        //Debug.Log("turned270");
                    }
                }
                else if (levelMap[i, j] == 2)
                {
                    if (i == 0 || i == 28)
                    {
                        //Debug.Log("pass");
                    }
                    else if (ConnectUp(i,j) || ConnectDown(i,j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                    }
                }
                else if (levelMap[i, j] == 3)
                {
                    
                    if (j == 19)
                    {
                        if (i == 9) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);
                        if (i == 10) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);
                        if (i == 18) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);
                        if (i == 19) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);

                    }
                    if (i!=14 && j==13)
                    {
                        //Debug.Log("try turn, on last collum");
                        //Debug.Log("i=" + i + "j=" + j);
                        if (levelMap[i + 1, j] == 5 && levelMap[i - 1, j ] == 4 && levelMap[i, j - 1] == 5)
                        {
                            map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                            //Debug.Log("turned90");
                        }
                        else if (levelMap[i + 1, j - 1] == 5 && levelMap[i + 1, j] == 4 && levelMap[i, j - 1] == 4 && !UpIsPath(i, j))
                        {
                            map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);
                            //Debug.Log("turned180");
                        }
                        else if (levelMap[i + 1, j - 1] == 0 && levelMap[i, j - 1] == 0)
                        {
                            map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                            //Debug.Log("turned270");
                        }
                    }
                    else if (ConnectRight(i, j) && ConnectUp(i, j) && !ConnectLeft(i, j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                        //Debug.Log("i=" + i + "j=" + j);
                        //Debug.Log("turned90");
                    }
                    else if (ConnectRight(i,j) && ConnectUp(i,j) && !ConnectUpRight(i, j) && UpRightIsPath(i,j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                        //Debug.Log("i=" + i + "j=" + j);
                        //Debug.Log("turned90");                      
                    }
                    else if (ConnectLeft(i,j) && ConnectUp(i, j)&& !ConnectRight(i, j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);
                        //Debug.Log("i=" + i + "j=" + j);
                        //Debug.Log("turned180");
                    }
                    else if (ConnectLeft(i, j) && ConnectDown(i, j)&& !ConnectUp(i, j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn270);
                        //Debug.Log("i=" + i + "j=" + j);
                        //Debug.Log("turned270");
                    }
                    if (i == 18 && j == 13) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn0);                    
                    if (i == 21 && j == 13) map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn180);
                }
                else if (levelMap[i, j] == 4)
                {
                    if (i == 14)
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                    }
                    else if (!UpIsPath(i, j) && !DownIsPath(i, j))
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), turn90);
                    }
                }
                else if (levelMap[i, j] == 5)
                {
                    Vector3 cellPosition = map.CellToLocal(new Vector3Int(-i, j, 0));
                    cellPosition = cellPosition + new Vector3(0.09f, 0.09f, 0);
                    Instantiate(NormalPellet, cellPosition, Quaternion.Euler(0, 0, 0), GameObject.Find("Tilemap").transform);
                }
            
                else if (levelMap[i, j] == 6)
                {
                    //GridLayout gridLayout = map.transform.parent.GetComponentInParent<GridLayout>();
                    //Vector3Int cellPosition = gridLayout.WorldToCell(map.GetTile(levelMap[i, j]));
                    Vector3 cellPosition = map.CellToLocal(new Vector3Int(-i,j,0));
                    cellPosition = cellPosition + new Vector3(0.09f,0.09f,0);
                    Instantiate(PowerPellet, cellPosition, Quaternion.Euler(0, 0, 0), GameObject.Find("Tilemap").transform);
                }
                else if (levelMap[i, j] == 7)
                {
                    if (j == 13)
                    {
                        map.SetTransformMatrix(new Vector3Int(-i, j, 0), flipY);
                    }
                    if (i == 28)
                    {
                        if(j == 13) map.SetTransformMatrix(new Vector3Int(-i, j, 0), flipXY);
                        if(j == 14) map.SetTransformMatrix(new Vector3Int(-i, j, 0), flipX);
                    }
                }
            }
        }

        //Instantiate(map, new Vector3(5.04f,0,0), Quaternion.Euler(0,180,0), parent.transform);
        //GameObject.Find("Tilemap(Clone)").name = "Tilemap2";
        //Instantiate(map, new Vector3(0, -4.86f, 0), Quaternion.Euler(180, 0, 0), parent.transform);
        //GameObject.Find("Tilemap(Clone)").name = "Tilemap3";
        //Instantiate(map, new Vector3(5.04f, -4.86f, 0), Quaternion.Euler(180, 180, 0), parent.transform);
        //GameObject.Find("Tilemap(Clone)").name = "Tilemap4";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
