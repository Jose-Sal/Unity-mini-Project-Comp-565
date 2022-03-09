using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMouseInput : MonoBehaviour
{
    //public Button b;
    public int Mytype;
    public int MyTexture;
    public string tagname;
    public Material[] ChangeMaterial;
    Renderer rend;
    public /*PrimitiveType*/ void ChangeType(int type /*out PrimitiveType MyTest*/)
    {
        Mytype = type;
    }

    public void Texture(int Texture)
    {
        MyTexture = Texture;
    }

    //for transparency
    RaycastHit RHit;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();  //stores the collision information with other gameobjects

        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        //--------------------------------------------------------------------
        Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePosition, out RHit, 50000f, (1<<8))){
            transform.position = hitInfo.point;
        }
        //---------------------------------------------------------------------
        if (Input.GetMouseButtonUp(0))  // check if left button is pressed
        {




            // take mouse position, convert from screen space to world space, do a raycast, store output of raycast into 
            // hitInfo object ...

            #region Screen To World
            //RaycastHit hitInfo = new RaycastHit();  //stores the collision information with other gameobjects

            //bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                var test = PrimitiveType.Cube;
               
                switch (Mytype)
                {
                    case 3:
                        test = PrimitiveType.Capsule;
                        tagname = "MyCapsule";
                        break;
                    case 2:
                        test = PrimitiveType.Sphere;
                        tagname = "MySphere";
                        break;
                    default:
                        test = PrimitiveType.Cube;
                        tagname = "MyCube";
                        break;
                }
                #region HIDE
                
                var Obj = GameObject.CreatePrimitive(test);

                //this is to change the material
                rend=Obj.GetComponent<Renderer>();
                rend.sharedMaterial = ChangeMaterial[MyTexture];

                Obj.tag = tagname;
                Obj.gameObject.AddComponent < BoxCollider >();
                //cube.GetComponent<BoxCollider>().isTrigger = true;
                //cube.GetComponent<Renderer>().material = blockMaterial;

                #endregion
                

                //cube.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.5f, hitInfo.point.z);
                #region HIDE
                //once the ray hits an object with tag Base, we want to spawn in a cube in the location of the raycast hit
                if (hitInfo.transform.tag.Equals("Base"))
                {
                    Obj.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + (0.5f), hitInfo.point.z);
                }
                #region HIDE
                //if it hits another cube then we must perfectly align itself to the surface it was hit
                else
                {
                    //we use normal to get the vector perpendicular of the surface. do it all for 6 of the surfaces
                    Obj.transform.position= hitInfo.transform.position + hitInfo.normal;
                   
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
        else if (Input.GetMouseButtonDown(1))
        {
            if (hit) { 
            if (hitInfo.transform.tag != "Base")
            {
                Destroy(hitInfo.collider.gameObject);

            }
            
                return;
            }
            //else if (hitInfo.transform.tag.Equals("MySphere"))
            //{
            //    Debug.Log("im sphere");
            //}
        }
    }
}
