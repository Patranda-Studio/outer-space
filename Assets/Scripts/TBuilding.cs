using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBuilding : MonoBehaviour { // ����� ������
    public int id; // ������
    public Renderer MainRenderer; // ������ ��� ��������� �����
    public GameObject Model; // ������
    public Vector2Int Size = Vector2Int.one; // ������
    public Vector2Int[] Connect; // ����� ��� ����� ������������
    public GameObject[] ConnectorPlace; // ������ �� ��������� ������ �������
    public bool noConnect; // ������ �� ���������� ����� ��������� ��� ����������

    public void SetTransparent(bool available) { // ���� ��������� �� ����� ������������
        if (available) { // ���� ����� �������
            MainRenderer.material.color = Color.green; // ���� ������
        } else { // ���� ������ �������
            MainRenderer.material.color = Color.red; // ���� �������
        }
    }

    public void SetNormal() { // ���������� ����
        MainRenderer.material.color = Color.white; // ���� �����
    }

    private void OnDrawGizmos() { // ��������� ����� � ����������
        if (Camera.main.GetComponent<BuildBase>().flyingBuilding != null) { // ���� ��� �������
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
            for (int i = 0; i < ConnectorPlace.Length; i++) { // ������ �� ������� �����������
                ConnectorPlace[i].SetActive(true); // ��������� �����������
            }
            for (int x = 0; x < Size.x; x++) {
                for (int y = 0; y < Size.y; y++) {
                    if ((x + y) % 2 == 0) Gizmos.color = new Color(0.5f, 1f, 0.5f, 0.3f);
                    else Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.3f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
        } else { // ���� �� ��� �������
            for (int i = 0; i < ConnectorPlace.Length; i++) { // ������ �� ������� �����������
                ConnectorPlace[i].SetActive(false); // ���������� �����������
            }
        }
    }
}
