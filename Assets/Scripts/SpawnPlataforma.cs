using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnPlataforma : MonoBehaviour
{
    public float distanceLeft;
    public float distanceRight;
    public int maxPlataforma;
    public GameObject plataforma;
    public GameObject plataformaFragil;
    public GameObject moeda;
    public List<GameObject> plataformas;
    public List<GameObject> plataformasFragil;
    public Transform player;
    public double distanciaEntrePlataformas;
    private float AlturaMaxChar;


    //variable of color to control fade of frageis
    Color newColor = new Color(1, 1, 1, 1);

    // Use this for initialization
    void Start()
    {
        //Instanciando as plataformas normais que serao utilizadas, inicialmente desativadas
        for (int i = 0; i < maxPlataforma; i++)
        {
            GameObject tempPlataforma = Instantiate(plataforma) as GameObject;
            plataformas.Add(tempPlataforma);
            tempPlataforma.SetActive(false);
        }
        //Instanciando as plataformas frageis que serao utilizadas, inicialmente desativadas
        for (int i = 0; i < maxPlataforma; i++)
        {
            GameObject tempPlataformaFragil = Instantiate(plataformaFragil) as GameObject;
            plataformasFragil.Add(tempPlataformaFragil);
            tempPlataformaFragil.SetActive(false);
        }

        //Instanciando a moeda
        moeda.SetActive(false);


        AlturaMaxChar = player.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        // Como as plataformas serao geradas apartir da altura maxima que o personagem alcancou:
        if (player.position.y > AlturaMaxChar + distanciaEntrePlataformas)
        {
            AlturaMaxChar = player.position.y;
            //A probabilidade para spawnar plataformas normais eh de 80%
            if (Random.value > 0.2)
            {
                Spawn();
            }
            //A probabilidade para spawnar plataformas frageis eh de 20%
            else
            {
                SpawnFrageis();
            }
        }

        // Checagem se as plataformas sairam do campo de visao do personagem, se sim, a plataforma sera desativada
        GameObject tempPlataforma = null;
        const float distanciaParaSpawn = 6.5f;
        for (int i = 0; i < maxPlataforma; i++)
        {
            if (player.position.y - plataformas[i].transform.position.y >= distanciaParaSpawn)
            {
                tempPlataforma = plataformas[i];
                tempPlataforma.SetActive(false);
            }
            if (player.position.y - plataformasFragil[i].transform.position.y >= distanciaParaSpawn)
            {
                tempPlataforma = plataformasFragil[i];
                tempPlataforma.SetActive(false);
            }
        }
			
        if (player.position.y - moeda.transform.position.y >= distanciaParaSpawn)
        {
            moeda.SetActive(false);
        }

    }

    //Metodo que spawna as plataformas
    private void Spawn()
    {
        const float alturaMin = -0.2f;
        const float alturaMax = 0.2f;
        float randPositionX = Random.Range(distanceLeft, distanceRight);
        float randPositionY = Random.Range(alturaMin, alturaMax);
        GameObject tempPlataforma = null;
        for (int i = 0; i < maxPlataforma; i++)
        {
            if (plataformas[i].activeSelf == false)
            {
                tempPlataforma = plataformas[i];
                break;
            }
        }

        if (tempPlataforma != null)
        {
            tempPlataforma.transform.position = new Vector3(randPositionX, transform.position.y + randPositionY, transform.position.z);
            tempPlataforma.SetActive(true);
            spawnMoeda(tempPlataforma);
        }
    }

    //metodo que spawna as plataformas frageis
    private void SpawnFrageis()
    {
        const float alturaMin = -0.2f;
        const float alturaMax = 0.2f;
        float randPositionX = Random.Range(distanceLeft, distanceRight);
        float randPositionY = Random.Range(alturaMin, alturaMax);
        GameObject tempPlataformaFragil = null;
        for (int i = 0; i < maxPlataforma; i++)
        {
            if (plataformasFragil[i].activeSelf == false)
            {
                tempPlataformaFragil = plataformasFragil[i];
                tempPlataformaFragil.GetComponent<SpriteRenderer>().color = newColor;
                break;
            }
        }
        if (tempPlataformaFragil != null)
        {
            tempPlataformaFragil.transform.position = new Vector3(randPositionX, transform.position.y + randPositionY, transform.position.z);
            tempPlataformaFragil.SetActive(true);
            spawnMoeda(tempPlataformaFragil);
        }
    }
    private void spawnMoeda(GameObject plataforma)
    {
        const float alturaMin = 1.5f;
        const float alturaMax = 1.8f;
        float randPositionX = Random.Range(distanceLeft, distanceRight);
        float randPositionY = Random.Range(alturaMin, alturaMax);
        if (moeda.activeSelf == false)
        {

            moeda.transform.position = new Vector3(randPositionX, plataforma.transform.position.y + randPositionY, plataforma.transform.position.z);
            moeda.SetActive(true);
        }
    }
}
