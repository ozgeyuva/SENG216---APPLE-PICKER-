using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList = new List<GameObject>();

    [SerializeField] private GameObject originalBasket;
    [SerializeField] private GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (originalBasket != null)
            originalBasket.SetActive(false);

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basket = Instantiate(basketPrefab);
            basket.SetActive(true);

            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            pos.z = 0f;

            basket.transform.position = pos;
            basketList.Add(basket);
        }
    }

    public void AppleMissed()
    {
       
        if (isGameOver || basketList.Count == 0)
            return;

        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject apple in apples)
        {
            Destroy(apple);
        }

        int lastBasketIndex = basketList.Count - 1;
        GameObject basketToRemove = basketList[lastBasketIndex];

        basketList.RemoveAt(lastBasketIndex);
        Destroy(basketToRemove);

        if (basketList.Count == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}