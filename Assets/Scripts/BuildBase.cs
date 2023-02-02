using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBase : MonoBehaviour {
    public GameObject[] buildPrefabs; // Шаблоны зданий
    public GameObject buildParent; // Контейнер для зданий

    public List<GameObject> buildContainer = new List<GameObject>(); // Контейнер  для зданий

    int x = 0;
    int y = 0;

    public TBuilding flyingBuilding; // Здание которе выбираеться где строить


    // Функция которая назначаеться на кнопуку (в основном) чтоб можно было начать строить
    public void StartPlacingBuilding(int id) { // Начало строительства
        if (flyingBuilding != null) { // Обнуление строительного здание если что-то пошло не по плану
            Destroy(flyingBuilding.gameObject); // Удаление этого здания
        }
        flyingBuilding = Instantiate(buildPrefabs[id].GetComponent<TBuilding>()); // Создания нового здания по id
        Cursor.visible = false; // Выключить курсор
    }

    private void Update() {
        if (flyingBuilding != null) { // Если идёт процесс стройки
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (groundPlane.Raycast(ray, out float position)) {
                Vector3 worldPosition = ray.GetPoint(position);
                if (Mathf.RoundToInt(worldPosition.x % 1) == 0) {
                    x = Mathf.RoundToInt(worldPosition.x);
                }
                if (Mathf.RoundToInt(worldPosition.z % 1) == 0) {
                    y = Mathf.RoundToInt(worldPosition.z);
                }

                bool available = true; // Переменная состояний возможности строительства

                if (x < 0 || x > WorldGenerator.landscapeLength - flyingBuilding.Size.x) {
                    available = false;
                }
                if (y < 0 || y > WorldGenerator.landscapeWidth - flyingBuilding.Size.y) {
                    available = false;
                }

                if (available && IsPlaceTaken(x, y)) available = false;

                flyingBuilding.transform.position = new Vector3(x, 0, y);
                flyingBuilding.SetTransparent(available);


                if (available && Input.GetMouseButtonDown(0) && (Resource.metal >= flyingBuilding.GetComponent<TBuilding>().requiredMetal)) {
                    for (int i = 0; i < flyingBuilding.Size.x; i++) {
                        for (int j = 0; j < flyingBuilding.Size.y; j++) {
                            WorldGenerator.landspace[x + i, y + j].GetComponent<TCell>().isEmpty = false;
                            for (int k = 0; k < flyingBuilding.GetComponent<TBuilding>().Connect.Rank; k++) {
                                if ((flyingBuilding.GetComponent<TBuilding>().Connect[k].x == i) && (flyingBuilding.GetComponent<TBuilding>().Connect[k].y == j)) {
                                    WorldGenerator.landspace[x + i, y + j].GetComponent<TCell>().isConnect = true;
                                }
                            }
                        }
                    }
                    flyingBuilding.GetComponent<TBuilding>().OnCreate(); // Выполнение дествия при строительстве
                    Resource.metal -= flyingBuilding.GetComponent<TBuilding>().requiredMetal; // Плата за постройку
                    buildContainer.Add(flyingBuilding.transform.gameObject);
                    flyingBuilding.transform.SetParent(buildParent.transform);
                    flyingBuilding.SetNormal();
                    flyingBuilding = null;
                    Cursor.visible = true;
                }
                if (Input.GetMouseButtonDown(1)) {
                    Destroy(flyingBuilding.transform.gameObject);
                    Cursor.visible = true;
                }
                if (Input.GetKeyDown(KeyCode.R)) {
                    flyingBuilding.Model.transform.Rotate(0, 90, 0);
                    flyingBuilding.Model.transform.localPosition = new Vector3(flyingBuilding.Model.transform.localPosition.z, 0, flyingBuilding.Model.transform.localPosition.x);
                    int t = flyingBuilding.Size.x;
                    flyingBuilding.Size.x = flyingBuilding.Size.y;
                    flyingBuilding.Size.y = t;
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY) { // Занято ли место (можно ли построить здание)
        //bool f1 = false; // Временный флаг проверки на свободное место
        // Проверка на то, что на месте строительства что-то есть
        for (int x = 0; x < flyingBuilding.Size.x; x++) {
            for (int y = 0; y < flyingBuilding.Size.y; y++) {
                if (WorldGenerator.landspace[placeX + x, placeY + y].GetComponent<TCell>().isEmpty == true) {
                    //f1 = true;
                } else {
                    //f1 = false;
                    //break;
                    return true;
                }
            }
            //if (f1 == false) break;
        }
        return false;
        /*bool f2 = false; // Временный флаг проверки на наличие коннекторов
        // Проверка на наличие в нужных местах конектора
        if (flyingBuilding.noConnect == false) {
            if (flyingBuilding.GetComponent<TBuilding>().Connect.Rank != 0) {
                for (int i = 0; i < flyingBuilding.GetComponent<TBuilding>().Connect.Rank; i++) {
                    if (WorldGenerator.landspace[placeX + flyingBuilding.GetComponent<TBuilding>().Connect[i].x, placeY + flyingBuilding.GetComponent<TBuilding>().Connect[i].y].GetComponent<TCell>().isConnect == true) {
                        f2 = true;
                        break;
                    }
                }
            }
        } else {
            f2 = true;
        }
        if (f1 && f2) {
            return false;
        } else {
            return true;
        }*/
    }
}
