using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Название сцены, которую вы хотите загрузить
    [SerializeField] private string sceneName;

    // Метод для загрузки сцены
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Имя сцены не указано!");
        }
    }
}

