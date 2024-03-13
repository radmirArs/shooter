using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class CubeTask : MonoBehaviour
{
    public GameObject cubePrefab; // Префаб кубика

    void Update()
    {
        // Проверяем нажатия кнопок мыши
        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            SpawnCube(); // Вызываем функцию создания кубика
        }
        else if (Input.GetMouseButtonDown(1)) // Правая кнопка мыши
        {
            DestroyObject(); // Вызываем функцию уничтожения объекта
        }
    }

    void SpawnCube()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Создаем копию префаба кубика в позиции курсора
        Instantiate(cubePrefab, mousePosition, Quaternion.identity);
    }

    void DestroyObject()
    {
        // Проверяем, есть ли объект под курсором мыши
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // Если объект найден, уничтожаем его
            Destroy(hit.collider.gameObject);
        }
    }
}
