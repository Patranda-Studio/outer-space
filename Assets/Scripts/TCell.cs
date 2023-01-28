using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCell : MonoBehaviour { // Класс ячейки ланшафта
    public int id; // Индекс
    public bool isEmpty = true; // Свободно ли ячейка
    public bool isConnect = false; // Есть ли на ней конектор
    public int X, Y; // Координаты
}