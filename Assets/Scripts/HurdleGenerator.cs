using UnityEngine;

public class HurdleGenerator : MonoBehaviour
{
    // Public Methods
    public GameObject hurdle;
    public float MinSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;
    public float SpeedMultiplier;

    // Private Methods
    // [SerializeField] private GameObject runnerObject = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentSpeed = MinSpeed;
        generateHurdle();
    }

    public void generateNextHurdleWithGap()
    {
        float randomWait = Random.Range(0.2f, 1.2f);
        Invoke("generateHurdle", randomWait);
    }

    void generateHurdle()
    {
        GameObject HurdleInst = Instantiate(hurdle, transform.position, transform.rotation);

        HurdleInst.GetComponent<HurdleScript>().hurdleGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += SpeedMultiplier;
        }
    }
}
