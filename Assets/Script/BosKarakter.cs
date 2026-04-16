using UnityEngine;
using UnityEngine.AI;

public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakOlanMaterial;
    public NavMeshAgent _Navmesh;
    public Animator _Animator;
    public GameObject Target;
    public GameManager _Gamemanager;
    bool Temasvar;

    private void LateUpdate()
    {
        if(Temasvar == true)
          _Navmesh.SetDestination(Target.transform.position); // varisnoktasina gitmesi saglandi
    }

    void Start()
    {
        
    }

    Vector3 PozisyonVer() // bir türde fonk olusturdugumuz zaman o turde return etmeliyiz
    {
        // bu satiri cok fazla yerde cagirdigimiz icin ayrý fonksiyon olarak tanýmladýk. artik sadece bu fonku cagircaz
        //Vector3 yeniPoz = new Vector3(transform.position.x, 0.18f, transform.position.z);
        return new Vector3(transform.position.x, 0.18f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler") || other.CompareTag("AnaKarakter"))
        {
            if (gameObject.CompareTag("BosKarakter")) // anlikkaraktersayisi amansiz artmasin diye bu korumayi yaptik
            {
                MateryalDegistirveAnimasyonTetikle();
                Temasvar = true;
                GetComponent<AudioSource>().Play();
            }
            
        }

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
            Vector3 yeniPos = new Vector3(transform.position.x, 0.18f, transform.position.z);
            _Gamemanager.YokOlmaEfektiOlustur(yeniPos, false, false);
            gameObject.SetActive(false); // altkarakter ignelikutuya carparsa yok olur
        }
    }

    void MateryalDegistirveAnimasyonTetikle()
    {
        Material[] mats = _Renderer.materials; //_Rendererdaki materyalleri bu listede topladýk.
        mats[0] = AtanacakOlanMaterial;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldir", true);
        gameObject.tag = "AltKarakterler";
        // sayisal islemlerde sikinti yasamamak icin karakter sayisini bir arttirdik.
        GameManager.AnlikKarakterSayisi++;
    }
    
    

}
