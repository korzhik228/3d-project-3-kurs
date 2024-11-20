using UnityEngine;

public class Door : MonoBehaviour
{
    public float openSpeed = 2f; // Скорость открытия двери
    public Vector3 openPosition; // Конечная позиция открытой двери
    public bool isOpen = false; // Флаг, открыта ли дверь

    private Vector3 closedPosition; // Исходная позиция двери

    private void Start()
    {
        closedPosition = transform.position; // Сохраняем исходную позицию двери
    }

    public void Open()
    {
        if (!isOpen) // Проверяем, не открыта ли уже дверь
        {
            isOpen = true;
            // Вычисляем конечную позицию двери
            openPosition = closedPosition + Vector3.up * 2f; // Например, открытие на 2 метра вверх
        }
    }

    private void Update()
    {
        if (isOpen) // Если дверь должна быть открыта
        {
            // Плавно перемещаем дверь к конечной позиции
            transform.position = Vector3.Lerp(transform.position, openPosition, openSpeed * Time.deltaTime);
        }
        else
        {
            // Возвращаем дверь к исходной позиции, если она закрыта
            transform.position = Vector3.Lerp(transform.position, closedPosition, openSpeed * Time.deltaTime);
        }
    }
}
