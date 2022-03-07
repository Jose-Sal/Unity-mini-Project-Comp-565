using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMouseInput : MonoBehaviour
{
    int index = 0;

    

    // Update is called once per frame
    void Update()
    {

        string test = "change me";
        //string Mytype = (ChangeType(test));
        if (Input.GetMouseButtonUp(0))  // check if left button is pressed
        {
            // take mouse position, convert from screen space to world space, do a raycast, store output of raycast into 
            // hitInfo object ...

            #region Screen To World
            RaycastHit hitInfo = new RaycastHit();  //stores the collision information with other gameobjects

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {

                #region HIDE
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.tag = "MyCube";
                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;
                #endregion
               
                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                #region HIDE
                //once the ray hits an object with tag Base, we want to spawn in a cube in the location of the raycast hit
                if (hitInfo.transform.tag.Equals("Base"))
                {
                    cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                #region HIDE
                //if it hits another cube then we must perfectly align itself to the surface it was hit
                else
                {
                    //we use normal to get the vector perpendicular of the surface. do it all for 6 of the surfaces
                    cube.transform.position= hitInfo.transform.position + hitInfo.normal;
                   
                }
                #endregion

                Debug.DrawRay(hitInfo.point, hitInfo.normal, Color.red, 2, false);
                //Debug.Log(hitInfo.normal);
                #endregion


            }
            else
            {
                //Debug.Log("No hit");
            }
            #endregion
        }
    }

    //public void Cube()
    //{
    //    Debug.Log("this is a Cube");
    //    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    cube.tag = "MyCube";
    //}
    //public void Sphere()
    //{
    //    Debug.Log("this is a Sphere");
    //    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    sphere.tag = "MySphere";
    //}
    //public void Capsule()
    //{
    //    Debug.Log("this is a Capsule");
    //    var capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
    //    capsule.tag = "MyCapsule";
    //}

    public /*PrimitiveType*/ void ChangeType(string type)
    {

        switch (type)
        {
            case "Cube":
                print("i am cube");
                //obType = PrimitiveType.Cube;
                //return PrimitiveType.Cube;
                break;
            case "Sphere":
                print("i am sphere");
                PrimitiveType sphere = PrimitiveType.Sphere;
                //return PrimitiveType.Sphere;
                break;
            case "Capsule":
                print("i am capsule");
                PrimitiveType Capsule = PrimitiveType.Capsule;
                //return PrimitiveType.Capsule;
                break;
            default:
                print("not selected");
                //return PrimitiveType.Cube;
                break;

        }
    }

}
