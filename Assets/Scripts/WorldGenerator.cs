using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldGenerator { // ��������� ����
    public static int landscapeLength = 50, landscapeWidth = 30; // ������ ����
    public static GameObject[,] landspace = new GameObject[landscapeLength, landscapeWidth]; // ������ �����

    public static void RandomWorldGenerator() { // ��������� ���� ��������
        for (int i = 0; i < landscapeLength; i++) {
            for (int j = 0; j < landscapeWidth; j++) {
                Camera.main.GetComponent<DataBase>().CreateCell(i, j, Random.Range(0, 2));
            }
        }
    }
}
