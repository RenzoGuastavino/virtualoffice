using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectBehaviour : MonoBehaviour, IInteractiveObject
{

   public Material NormalMaterial;
   public Material HoverMaterial;
   public Material SelectedMaterial;

   private Renderer rend;
   private Animator anim;

   public void OnBlur()
   {
      rend.material = NormalMaterial;
   }

   public void OnHover()
   {
      rend.material = HoverMaterial;
   }

   public void OnSelect()
   {
      rend.material = SelectedMaterial;
      anim.SetTrigger("select");
   }

   // Start is called before the first frame update
   void Start()
   {
      rend = this.GetComponent<Renderer>();
      anim = this.GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {

   }
}
