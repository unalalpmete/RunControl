using UnityEngine;
using UnityEngine.AI;

public class Alt_Karakter : MonoBehaviour
{
    
    NavMeshAgent _Navmesh; // üretilen her prefab altkarakter navmeshagenta sahiptir ve bu sayede o noktaya ulasir.
    public GameManager _Gamemanager; // altkarakterlerimize _gamemanageri atadik 
    public GameObject Target; // prefab altkarakterin gitmek istedigi varis noktasi
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position); // varisnoktasina gitmesi saglandi
    }

    Vector3 PozisyonVer() // bir türde fonk olusturdugumuz zaman o turde return etmeliyiz
    {
        // bu satiri cok fazla yerde cagirdigimiz icin ayrý fonksiyon olarak tanýmladýk. artik sadece bu fonku cagircaz
        //Vector3 yeniPoz = new Vector3(transform.position.x, 0.18f, transform.position.z);
        return new Vector3(transform.position.x, 0.18f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("igneliKutu"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }

        if (other.CompareTag("Testere"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }

        if (other.CompareTag("Pervaneigneler"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer());
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }

        if (other.CompareTag("Balyoz"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer(), true);
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }

        if (other.CompareTag("Dusman"))
        {
            _Gamemanager.YokOlmaEfektiOlustur(PozisyonVer(), false, false);
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }

        else if (other.CompareTag("BosKarakter"))
        {
            //boskarakteri yonetebilmek icin kendi listemize aldýk.(ayni islemleri yapabilcez)
            _Gamemanager.Karakterler.Add(other.gameObject);
            

        }
    }

}
