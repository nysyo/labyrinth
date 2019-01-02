using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour
{
    public GameObject cube, plane, sphere;
    [SerializeField] int d = 31, w = 31;
    bool[,] table;
    bool[] end = new bool[4];
    void Start()
    {
        if (d % 2 == 0) d++;
        if (w % 2 == 0) w++;
        Vector2Int p = new Vector2Int(2 * Random.Range(1, (d + 1) / 2), 2 * Random.Range(1, (w + 1) / 2));
        table = new bool[d + 2, w + 2];
        int count = 0;
        for (int i = 1; i < d + 1; i++) {
            for(int j = 1; j < w + 1; j++) {
                table[i, j] = true;
            }
        }
        table[p.x, p.y] = false;
        while (count < (d - 1) * (w - 1) / 4 - 1) {
            switch (Random.Range(0, 4)) {
                case 0:
                    if (table[p.x + 2, p.y]) {
                        table[p.x + 1, p.y] = false;
                        table[p.x + 2, p.y] = false;
                        p.x += 2;
                        count++;
                    } else {
                        end[0] = true;
                    }
                    break;
                case 1:
                    if (table[p.x - 2, p.y]) {
                        table[p.x - 1, p.y] = false;
                        table[p.x - 2, p.y] = false;
                        p.x -= 2;
                        count++;
                    } else {
                        end[1] = true;
                    }
                    break;
                case 2:
                    if (table[p.x, p.y + 2]) {
                        table[p.x, p.y + 1] = false;
                        table[p.x, p.y + 2] = false;
                        p.y += 2;
                        count++;
                    } else {
                        end[2] = true;
                    }
                    break;
                case 3:
                    if (table[p.x, p.y - 2]) {
                        table[p.x, p.y - 1] = false;
                        table[p.x, p.y - 2] = false;
                        p.y -= 2;
                        count++;
                    } else {
                        end[3] = true;
                    }
                    break;
            }
            if(end[0] && end[1] && end[2] && end[3]) {
                for(int i = 0; i < 4; i++) {
                    end[i] = false;
                }
                while (true) {
                    p.x = 2 * Random.Range(1, (d + 1) / 2);
                    p.y = 2 * Random.Range(1, (w + 1) / 2);
                    if (!table[p.x, p.y]) break;
                }
            }
        }
        plane = Instantiate(plane, new Vector3(d / 2, 0, w / 2), Quaternion.identity);
        plane.transform.localScale = new Vector3(d / 10, 1, w / 10);
        Instantiate(sphere, new Vector3(1, 1, 1), Quaternion.identity);
        for(int i = 0; i < d + 1; i++) {
            for(int j = 0; j < w + 1; j++) {
                if (table[i, j]) Instantiate(cube, new Vector3(i - 1, 0.5f, j - 1), Quaternion.identity).transform.parent = plane.transform;
            }
        }
    }
}
