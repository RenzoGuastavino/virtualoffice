using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectorBehaviour : MonoBehaviour
{
   private InteractiveObjectBehaviour interactiveComponent;

   // Start is called before the first frame update
   void Start()
   {

   }

   void Hover()
   {
      RaycastHit hit;
      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
      {
         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

         InteractiveObjectBehaviour component = hit.collider.gameObject.GetComponent<InteractiveObjectBehaviour>();
         if (component != null)
         {
            if (component != interactiveComponent)
            {

               if (interactiveComponent != null)
                  interactiveComponent.OnBlur();

               component.OnHover();
               interactiveComponent = component;
            }
         }
         else
         {
            ClearHoveredElement();
         }
      }
      else
      {
         ClearHoveredElement();

         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
      }

      if (Input.GetMouseButtonDown(0) && interactiveComponent != null) {
         interactiveComponent.OnSelect();
      }

   }

   private void ClearHoveredElement()
   {
      if (interactiveComponent != null)
      {
         interactiveComponent.OnBlur();
         interactiveComponent = null;
      }
   }

   // Update is called once per frame
   void Update()
   {
      Hover();
   }
}
