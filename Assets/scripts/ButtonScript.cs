using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public Door door; // Ссылка на скрипт двери

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что столкнувшийся объект - игрок
        {
            door.Open(); // Открываем дверь, вызывая метод Open() из скрипта двери
        }
    }
}