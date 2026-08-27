using UnityEngine;
using tk;

// forces early execution
[DefaultExecutionOrder(-100)] 
public class InitBoxPush : MonoBehaviour
{

    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject donkey_spawn;

    private GameObject cube;


    // register ourselves to hear the reset signal from python
    private void OnEnable()
    {
        TcpCarHandler.OnReset += ResetBoxPush;
    }

    private void OnDisable()
    {
        TcpCarHandler.OnReset -= ResetBoxPush;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBoxPush()
    {
        // reset cube
        if (cube.TryGetComponent<ObjectResetter>(out ObjectResetter resetter))
        {
            resetter.ResetObject();
        }

        // let's just start with random goal poses for now
        float x_offset = Random.Range(-5f, 5f);
        float z_offset = Random.Range(-5f, 5f);
        goal.transform.position += new Vector3(x_offset, 0.0f, z_offset);
    }
}
