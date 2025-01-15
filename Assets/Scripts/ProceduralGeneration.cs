using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int ancho, altura;
    [SerializeField] int MinPiedraAltura, MaxPiedraAltura;
    //[SerializeField] int MinCuevaX, MaxCuevaX, MinCuevaY, MaxCuevaY;
    [SerializeField] int numCuevas;
    [SerializeField] GameObject sucio, verde, gris, negro, pincho;

    void Start()
    {
        this.Generation();
    }
    /// <summary>
    /// // Método para la generacion procedural de un mapa inicial.
    /// </summary>

    private void Generation()
    {
        for (int x = 0; x < ancho; x++)
        {// Utilizaremos este bucle para instanciar "sucio"

            //Valores para la aleatoriedad de la altura
            int minAltura = altura - 1;
            int maxAltura = altura + 2;

            altura = Random.Range(minAltura,maxAltura);

            //Valores mínimos y máximos para la piedra
            int minPiedraDistancia = altura - MinPiedraAltura;
            int maxPiedraDistancia = altura - MaxPiedraAltura;
            int totalDistanciaSpawn = Random.Range(minPiedraDistancia, maxPiedraDistancia + 1);

            /*//Valores mínimos y máximos para la cueva
            int minCuevaX = ancho + MinCuevaX;
            int maxCuevaX = ancho + MaxCuevaX;
            int totalCuevaX = Random.Range(minCuevaX, maxCuevaX + 1);
            int minCuevaY = altura + MinCuevaY;
            int maxCuevaY = altura + MaxCuevaY;
            int totalCuevaY = Random.Range(minCuevaY, maxCuevaY + 1);*/

            for (int y = 0; y < altura; y++)
            {
                if (y < totalDistanciaSpawn)
                {
                    spawnObj(gris, x, y);
                }
                else
                {
                    //Instantiate(sucio, new Vector2(x, y), Quaternion.identity);// Instanciamos la Baldosa "sucio"
                    spawnObj(sucio, x, y);
                    //spawnObj(negro, totalCuevaX, totalCuevaY);
                }
            }//for y
             //Instantiate(verde, new Vector2(x, altura - 0.4f), Quaternion.identity);// Instanciamos la Baldosa "verde"

            if (Random.Range(0, 2) < 1)
            {
                spawnObj(verde, x, altura);
            }
            else
            {
                spawnObj(pincho, x, altura);
            }

            //Generar cuevas
            if (numCuevas > 0 && Random.Range(0, 10) < 1) // 20% de probabilidad de generar una cueva en cada columna
            {
                int cuevaAltura = Random.Range(1, altura);
                spawnObj(negro, x, cuevaAltura); // Asumiendo que tienes un objeto "cueva" para instanciar
                numCuevas--;
            }

        }//for x
    }//Generation

    ////////
    /// Método para expandir spawn
    ///////
    void spawnObj(GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;

    }//spawnObj

}//Main
