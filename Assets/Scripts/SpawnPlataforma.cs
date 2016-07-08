using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnPlataforma : MonoBehaviour {
    public float distanceLeft;
    public float distanceRight;
    public int maxPlataforma;
    public GameObject plataforma;
    public GameObject plataformaFragil;
    public List<GameObject> plataformas;
    public List<GameObject> plataformasFragil;
    public Transform player;
    public double distanciaEntrePlataformas;
    private float AlturaMaxChar;
	// Use this for initialization
	void Start () {
        //Instanciando as plataformas normais que serao utilizadas, inicialmente desativadas
        for(int i = 0; i < maxPlataforma; i++)
        {
            GameObject tempPlataforma = Instantiate(plataforma) as GameObject;
            plataformas.Add(tempPlataforma);
            tempPlataforma.SetActive(false);
        }
        //Instanciando as plataformas frageis que serao utilizadas, inicialmente desativadas
        for(int i = 0; i<maxPlataforma; i++)
        {
            GameObject tempPlataformaFragil = Instantiate(plataformaFragil) as GameObject;
            plataformasFragil.Add(tempPlataformaFragil);
            tempPlataformaFragil.SetActive(false);
        }
        AlturaMaxChar = player.position.y;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Como as plataformas serao geradas apartir da altura maxima que o personagem alcancou:
        if(player.position.y > AlturaMaxChar + distanciaEntrePlataformas)
        {
            AlturaMaxChar = player.position.y;
            //A probabilidade para spawnar plataformas normais eh de 80%
            if(Random.value > 0.2)
            {
                spawn();
            }
            //A probabilidade para spawnar plataformas frageis eh de 20%
            else
            {
                spawnFrageis();
            }
        }

        // Checagem se as plataformas sairam do campo de visao do personagem, se sim, a plataforma sera desativada
        GameObject tempPlataforma = null;
        float distanciaParaSpawn = 6.5f;
        for(int i =0; i<maxPlataforma; i++)
        {
            if(player.position.y - plataformas[i].transform.position.y >= distanciaParaSpawn)
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



    }

    //Metodo que spawna as plataformas
    private void spawn()
    {
        float randPositionX = Random.Range(distanceLeft, distanceRight);
        float randPositionY = Random.Range(-0.3f, 0.3f);
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
        }
    }

    //metodo que spawna as plataformas frageis
    private void spawnFrageis()
    {
        float randPositionX = Random.Range(distanceLeft, distanceRight);
        float randPositionY = Random.Range(-0.2f, 0.2f);
        GameObject tempPlataformaFragil = null;
        for (int i = 0; i < maxPlataforma; i++)
        {
            if (plataformasFragil[i].activeSelf == false)
            {
                tempPlataformaFragil = plataformasFragil[i];
                break;
            }
        }
        if (tempPlataformaFragil != null)
        {
            tempPlataformaFragil.transform.position = new Vector3(randPositionX, transform.position.y + randPositionY, transform.position.z);
            tempPlataformaFragil.SetActive(true);
        }

    }
}
