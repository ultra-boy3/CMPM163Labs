using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BuildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int mapRadius = 20;

    public int space = 1;
    public float noiseDepth = 10.0f;

    public int streets = 0;
    public bool pipes = false;

    // Start is called before the first frame update
    void Start()
    {
        float seed = UnityEngine.Random.Range(0, 100);

        //int[] streetLocations = new int[streets];

        HashSet<int> streetLocations = new HashSet<int>();
        for(int i = 0; i < streets; i++)
        {
            int street = UnityEngine.Random.Range(0, 36) * 10; //Use noise instead?
            streetLocations.Add(street);
        }

        //At each location, it will instantiate a random building
        /*
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                int result = (int) (Mathf.PerlinNoise(w/noiseDepth + seed, h/noiseDepth + seed) * 10);

                Vector3 pos = new Vector3(w * space, 0, h * space);
                //int n = Random.Range(0, buildings.Length);
                //Instantiate(buildings[n], pos, Quaternion.identity);

                if (result < 2)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if(result < 4)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (result < 6)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (result < 8)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (result < 10)
                    Instantiate(buildings[4], pos, Quaternion.identity);
            }
        }
        */

        //Circular city
        for(int r = 5; r < mapRadius; r++)
        {
            int h = 0;
            /*
            for(int d = 0; d < 360; d += 5) //Every 5 degrees?
            {
                h++;
                if (!streetLocations.Contains(d))
                {
                    int result = (int)(Mathf.PerlinNoise(r / noiseDepth + seed, h / noiseDepth + seed) * 10);

                    Transform placement = gameObject.transform;
                    placement.position = new Vector3(r * space, 0, 0);
                    placement.RotateAround(new Vector3(0, 0, 0), transform.up, d);

                    if (result < 2)
                        Instantiate(buildings[0], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 4)
                        Instantiate(buildings[1], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 6)
                        Instantiate(buildings[2], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 8)
                        Instantiate(buildings[3], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 10)
                        Instantiate(buildings[4], placement.position, Quaternion.Euler(0, d, 0));
                }
            }
            */

            int d = 0;
            while(d < 360)
            {
                if (!streetLocations.Contains(d) && !streetLocations.Contains(d+5) && !streetLocations.Contains(d-5))
                {
                    int result = (int)(Mathf.PerlinNoise(r / noiseDepth + seed, h / noiseDepth + seed) * 10);

                    Transform placement = gameObject.transform;
                    placement.position = new Vector3(r * space, 0, 0);
                    placement.RotateAround(new Vector3(0, 0, 0), transform.up, d);

                    if (result < 4)
                        Instantiate(buildings[0], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 6)
                        Instantiate(buildings[1], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 8)
                        Instantiate(buildings[2], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 9)
                        Instantiate(buildings[3], placement.position, Quaternion.Euler(0, d, 0));
                    else if (result < 10)
                        Instantiate(buildings[4], placement.position, Quaternion.Euler(0, d, 0));
                }
                else if(streetLocations.Contains(d) && pipes)
                {
                    Transform placement = gameObject.transform;
                    placement.position = new Vector3(r * space, 0, 0);
                    placement.RotateAround(new Vector3(0, 0, 0), transform.up, d);

                    Instantiate(buildings[5], placement.position, Quaternion.Euler(0, d, 90));
                }

                if (r < 5)
                {
                    d += 20;
                }
                else if(r < 10)
                {
                    d += 10;
                }
                else
                {
                    d += 5;
                }
                h++;
            }
        }
    }
}
