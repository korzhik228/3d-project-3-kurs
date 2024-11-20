using UnityEngine;

public class DoorStatus : MonoBehaviour
{
    public Door door; // Ссылка на скрипт двери

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Проверяем нажатие клавиши Space
        {
            Debug.Log("Дверь открыта: " + door.isOpen); // Выводим состояние двери в консоль
        }
    }
}