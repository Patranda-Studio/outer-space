using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBuilding : MonoBehaviour { // Класс здания
    public int id; // Индекс
    public Renderer MainRenderer; // Рендер для изменения цвета
    public GameObject Model; // Модель
    public Vector2Int Size = Vector2Int.one; // Размер
    public Vector2Int[] Connect; // Места где можно пристроиться
    public GameObject[] ConnectorPlace; // Ссылки на конекторы внутри объекта
    public bool noConnect; // Зданию не требуються други конекторы для пристройки

    public void SetTransparent(bool available) { // Цвет материала во время стрительства
        if (available) { // Если можно строить
            MainRenderer.material.color = Color.green; // Цвет залёный
        } else { // Если нельзя строить
            MainRenderer.material.color = Color.red; // Цвет красный
        }
    }

    public void SetNormal() { // Нормальный цвет
        MainRenderer.material.color = Color.white; // Цвет белый
    }

    private void OnDrawGizmos() { // Отрисовка грида и конекторов
        if (Camera.main.GetComponent<BuildBase>().flyingBuilding != null) { // Если идёт стройка
            for (int x = 0; x < Size.x; x++) {
                for (int y = 0; y < Size.y; y++) {
                    if ((x + y) % 2 == 0) {
                        Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
                    } else {
                        Gizmos.color = new Color(0.3f, 0.3f, 0.3f, 0.3f);
                    }
                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
            for (int i = 0; i < ConnectorPlace.Length; i++) { // Проход по массиву коннекторов
                ConnectorPlace[i].SetActive(true); // Включение коннекторов
            }
            for (int x = 0; x < Size.x; x++) {
                for (int y = 0; y < Size.y; y++) {
                    if ((x + y) % 2 == 0) Gizmos.color = new Color(0.5f, 1f, 0.5f, 0.3f);
                    else Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.3f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
        } else { // Если не идёт стройка
            for (int i = 0; i < ConnectorPlace.Length; i++) { // Проход по массиву коннекторов
                ConnectorPlace[i].SetActive(false); // Выключение коннекторов
            }
        }
    }
}
