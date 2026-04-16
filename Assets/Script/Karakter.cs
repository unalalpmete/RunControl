using UnityEngine;

public class Karakter : MonoBehaviour
{
    public GameManager _GameManager;
    public Kamera _Kamera;
    public bool SonaGeldikmi;
    public GameObject GidecegiYer;

    private void FixedUpdate()
    {
        if(!SonaGeldikmi)
        transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);
    }

    
    void Update()
    {
        if (SonaGeldikmi == true)
        {
            transform.position = Vector3.Lerp(transform.position, GidecegiYer.transform.position, .015f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f,
                        transform.position.y, transform.position.z), .3f);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f,
                        transform.position.y, transform.position.z), .3f);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carpma") || other.CompareTag("Toplama") || other.CompareTag("Cikartma") || other.CompareTag("Bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetimi(other.tag, sayi, other.transform);
        }
        else if (other.CompareTag("Sontetikleyici"))
        {
            _Kamera.SonaGeldikmi = true;
            _GameManager.DusmanlariTetikle();
            SonaGeldikmi = true;
        }
        else if (other.CompareTag("BosKarakter"))
        {
            //boskarakteri yonetebilmek icin kendi listemize aldýk.(ayni islemleri yapabilcez)
            _GameManager.Karakterler.Add(other.gameObject);
            
        }
    }

}
    