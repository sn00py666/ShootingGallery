using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject redCirclePrefab; // Префаб красного кружка
    //public GameObject[] scoreZones; // Массив очков по зонам, например: {10, 20, 50}
    public List<GameObject> scoreZones; // Список объектов
    private List<float> distances;
    private GameManager gm;
    private ScoreManager sm;

    // Проверяем, есть ли объекты для обработки
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sm = FindObjectOfType<ScoreManager>();

        // Проверяем, есть ли объекты для обработки
        if (scoreZones.Count < 2)
        {
            Debug.LogWarning("Недостаточно объектов для вычисления расстояний.");
            return;
        }

        // Очищаем список расстояний
        distances = new List<float>();

        // Вычисляем расстояния между объектами
        for (int i = 0; i < scoreZones.Count; i++)
        {
            Vector3 positionCenter = transform.position;
            Vector3 positionTarget = scoreZones[i].transform.position;

            float distance = Vector3.Distance(positionCenter, positionTarget);
            distances.Add(distance);
        }

        // Выводим расстояния в консоль
        for (int i = 0; i < distances.Count; i++)
        {
            Debug.Log($"Расстояние между цетром и объектом {i}: {distances[i]}");
        }
    }
    private void OnMouseDown()
    {
        // Определяем место нажатия
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPosition.z = 0; // Убираем глубину для 2D

        // Рассчитываем попадание в зону
        int score = CalculateScore(clickPosition);

        // Выводим результат в консоль
        Debug.Log(clickPosition);
        Debug.Log($"Попадание! Очки: {score}");

        if (score != -1)
        {
            // Создаем кружок на месте клика
            Instantiate(redCirclePrefab, clickPosition, Quaternion.identity, transform);
        }
        if (gm.bulletCountNow == 0)
        {
            //gm.anim.SetTrigger("PlayAnimAfterShot");
            gm.anim.SetTrigger("NT");
            Debug.Log("anim");

            //gm.StopAnim();

        }

    }

    private int CalculateScore(Vector3 position)
    {
        // Определяем расстояние от центра мишени
        Vector3 targetCenter = transform.position;
        float distance = Vector3.Distance(position, targetCenter);
        // Определяем зону по радиусам
        for (int i = 0; i < distances.Count; i++)
        {
            if (distance < distances[i])
            {
                gm.bulletCountNow--;
                sm.UpdateScore(scoreZones.Count - i);
                return scoreZones.Count - i;
            }
        }

        //Если вышли за все зоны, очки = -1
        gm.bulletCountNow--;
        return -1;
    }
}