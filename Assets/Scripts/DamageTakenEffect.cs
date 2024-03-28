 using System.Collections;
 using UnityEngine;

 public class DamageTakenEffect : MonoBehaviour
 {
     private readonly Color _damageColor = Color.red;
     private const float _flashDuration = 0.1f;
     private const int _flashCount = 3;

     private Renderer _render;
     private Color[] originalColors;

     private void Start()
     {
         _render = GetComponent<Renderer>();
         
         originalColors = new Color[_render.materials.Length];
         for (int i = 0; i < _render.materials.Length; i++)
         {
             originalColors[i] = _render.materials[i].color;
         }
     }

     public void Flash()
     {
         StopAllCoroutines();
         StartCoroutine(DoFlash());
     }

     private IEnumerator DoFlash()
     {
         for (int i = 0; i < _flashCount; i++)
         {
             foreach (var mat in _render.materials)
             {
                 mat.color = _damageColor;
             }
             yield return new WaitForSeconds(_flashDuration);
             
             for (int j = 0; j < _render.materials.Length; j++)
             {
                 _render.materials[j].color = originalColors[j];
             }
             yield return new WaitForSeconds(_flashDuration);
         }
     }
 }
