using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    public string _WebsiteURL = "http://tetsu3295.azurewebsites.net/tables/Product?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);
        int i = 0;

      //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL


        //----------------------
                //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.ProductName);
            //----------------------
            //YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
            int totalCubes = 30;

            float totalDistance = 2.9f;

                float perc = i / (float)totalCubes;
                float sin = Mathf.Sin(perc * Mathf.PI / 2);

                float x = 1.8f + sin * totalDistance;
                float y = 5.0f;
                float z = 0.0f;

                var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //Quaternion is default identity;
                newCube.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc));
                newCube.GetComponent<CubeScript>().rotateSpeed = .2f + perc * 4.0f;
                newCube.GetComponentInChildren<TextMesh>().text = product.ProductName;

            i++;
                //----------------------
            }
	}
	    
	// Update is called once per frame
	void Update () {
	
	}
}
