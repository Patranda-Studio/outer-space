using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldGenerator { // Генератор мира
    public static int landscapeLength = 50, landscapeWidth = 30; // Размер мира
    public static GameObject[,] landspace = new GameObject[landscapeLength, landscapeWidth]; // Массив ячеек

    public static void RandomWorldGenerator() { // Генерация мира рандомом
        for (int i = 0; i < landscapeLength; i++) {
            for (int j = 0; j < landscapeWidth; j++) {
                Camera.main.GetComponent<DataBase>().CreateCell(i, j, Random.Range(0, 2));
            }
        }
    }
}
