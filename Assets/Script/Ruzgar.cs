using UnityEngine;

public class Ruzgar : MonoBehaviour
{
    // karakterler o alanda kaldigi sure boyunca etkilensin istiyoruz.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AltKarakterler"))
        {   // tek seferlik güc => ForceMode.Impulse
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 0, 0), ForceMode.Impulse);
        }
    }
}
