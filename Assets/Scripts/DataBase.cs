using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour {
    public GameObject[] cellPrefabs; // —писок шаблонов €чеек
    public GameObject cellPerent; //  онтейнер дл€ €чеек

    void Start() {
        WorldGenerator.RandomWorldGenerator();
    }

    void DestroyCell(int x, int y) { // ”даление €чейки
        Destroy(WorldGenerator.landspace[x, y]);
    }

    public void CreateCell(int x, int y, int id) { // —оздание новой €чейки
        WorldGenerator.landspace[x, y] = Instantiate(cellPrefabs[id]);
        WorldGenerator.landspace[x, y].transform.SetParent(cellPerent.transform);
        WorldGenerator.landspace[x, y].transform.position = new Vector3(x, 0, y);
        WorldGenerator.landspace[x, y].GetComponent<TCell>().X = x;
        WorldGenerator.landspace[x, y].GetComponent<TCell>().Y = y;
    }
}