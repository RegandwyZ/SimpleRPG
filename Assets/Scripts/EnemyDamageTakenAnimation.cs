 using System.Collections;
 using UnityEngine;

 public class EnemyDamageTakenAnimation : MonoBehaviour
 {
     public Color damageColor = Color.white;
     public float flashDuration = 0.1f;
     public int flashCount = 3;

     private Renderer[] renderers;
     private Color[] originalColors;

     private void Start()
     {
         renderers = GetComponentsInChildren<Renderer>();

         originalColors = new Color[renderers.Length];
         for (int i = 0; i < renderers.Length; i++)
         {
             originalColors[i] = renderers[i].material.color;
         }
     }

     public void Flash()
     {
         StopAllCoroutines();
         StartCoroutine(DoFlash());
     }

     private IEnumerator DoFlash()
     {
         for (int i = 0; i < flashCount; i++)
         {
             foreach (var render in renderers)
             {
                 render.material.color = damageColor;
             }
             yield return new WaitForSeconds(flashDuration);

             for (int j = 0; j < renderers.Length; j++)
             {
                 renderers[j].material.color = originalColors[j];
             }
             yield return new WaitForSeconds(flashDuration);
         }
     }
 }
