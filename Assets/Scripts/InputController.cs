using UnityEngine;

public class InputController : MonoBehaviour
{
    private float timestamp = Mathf.Infinity;
    private float firerate = 0.1f;

    void CreateBullet()
    {
        GameObject tempObj = PoolManager.Instance.GetBullet();
        if (!tempObj)
        {
            return;
        }
        Vector3 randomPos = Random.insideUnitSphere * 2.0f;
        tempObj.transform.position = randomPos;
        timestamp = Time.time + firerate;
    }
    
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timestamp = Time.time + firerate;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            timestamp = Mathf.Infinity;
        }

        if (Time.time >= timestamp)
        {
            CreateBullet();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CreateBullet();
        }
        
        CheckInput();
    }
}
