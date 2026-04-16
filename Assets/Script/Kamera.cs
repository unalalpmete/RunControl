using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset; // kameranin karakteri belli acidan takip edebilmesi icin tanimladik
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;

    void Start()
    {
        target_offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (SonaGeldikmi == false)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position + target_offset, .015f);
        }
        
    }
}
