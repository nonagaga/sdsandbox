using UnityEngine;

// forces early execution
[DefaultExecutionOrder(-100)] 
public class InitBoxPush : MonoBehaviour
{

    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject donkey_spawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // let's just start with random goal poses for now
        float x_offset = Random.Range(-5f, 5f);
        float z_offset = Random.Range(-5f, 5f);
        goal.transform.position += new Vector3(x_offset, 0.0f, z_offset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
