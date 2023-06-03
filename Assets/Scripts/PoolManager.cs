using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    
    [SerializeField] private Transform parent;
    
    [Header("Pool Variables")]
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private uint poolSize = 10;
    [SerializeField] private float timeToLive = 10.0f;

    [Header("GUI Variables")] 
    [SerializeField] private TextMeshProUGUI counterText;

    private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(objectPrefab, parent);
            go.SetActive(false);
            pool.Add(go);
        }
    }

    void Update()
    {
        uint ballCounter = 0;

        for (int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeInHierarchy)
            {
                ballCounter++;
            }
        }

        counterText.text = $"Current Ball Count : {ballCounter}/{poolSize}";

        float percentage = ((float)ballCounter / (float)poolSize) * 100.0f;

        if (percentage < 75.0f)
        {
            counterText.color = Color.green;
        }
        else if (percentage < 90.0f)
        {
            counterText.color = Color.yellow;
        }
        else
        {
            counterText.color = Color.red;
        }
    }

    public void ResetPool()
    {
        foreach (GameObject go in pool)
        {
            go.SetActive(false);
        }
    }

    IEnumerator DeleteObject(GameObject go)
    {
        yield return new WaitForSeconds(timeToLive);
        go.SetActive(false);
    }

    public GameObject GetBullet()
    {
        foreach (GameObject go in pool)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                StartCoroutine(DeleteObject(go));
                return go;
            }
        }

        return null;
    }
}
