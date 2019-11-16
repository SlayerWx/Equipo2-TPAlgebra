using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallCollision : MonoBehaviour
{
    private Vector2 firstCollitionPosition;
    private Vector2 finalCollitionPosition;
    private bool moving;
    private Vector2 distanceTravelled;
    void Start()
    {
        firstCollitionPosition = transform.position;
        moving = false;
    }
    void Update()
    {
        
    }
    public void MyCollision(Vector2 collisionEnemy)
    {
        Debug.Log("COLISION");
        Vector2 distance;
        float angle;
        Vector2 aux;
        if (!moving)
        {
            firstCollitionPosition = transform.position;
        }
        else
        {
            finalCollitionPosition = collisionEnemy;
            distanceTravelled = finalCollitionPosition - firstCollitionPosition;
            distance = new Vector2(transform.position.x - collisionEnemy.x , transform.position.y - collisionEnemy.y);
            angle = Mathf.Acos(distanceTravelled.x * distance.x + distanceTravelled.y * distance.y / 
                    ((Mathf.Pow(distanceTravelled.x, 2) + Mathf.Pow(distanceTravelled.y, 2)) *
                     (Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2))));
            aux.x = (distanceTravelled.x + distanceTravelled.y) * Mathf.Cos(angle);
            aux.y = (distance.x + distance.y) * Mathf.Sin(angle);

            /*
             Guia Comentada >> Algebra

             La logica a seguir para realizar la fisica de la colision entre pelotas es la siguiente >>

             En el momento de colision entre la pelota blanca y una de color (sin movimiento) las fuerzas de ambas se restan y el resultado es repartida equitativamente a ambas.

             Para determinar el movimiento a seguir de la pelota de color (sin movimiento) es necesario crear un vector usando el punto central de la pelota blanca y el de la misma,
             la pelota de color (sin movimiento) se guiara en base a ese vector formado y saldra disparada en el sentido completamente opuesto al de la colision.

             Para determinar el movimiento a seguir de la pelota blanca post colision, es necesario tener determinado el vector en el cual se venia desplazando,
             luego se usa el nuevo vector creado entre el punto central de la blanca y la de color con el sentido opuesto al de la colision, luego al vector en el que circulaba 
             la pelota blanca se le suma este nuevo vector, dando como resultante un tercer nuevo vector que sera el que guie a la pelota despues de la colision

             //Pensamiento propio, fuera de la algebra >>

             Todas las pelotas pueden poseer dos vectores igualados a cero, uno llamado "Vector Direccion" (El vector en el que se mueve) y otro "Vector re-Direccion" (El vector que va a redireccionar el movimiento)
             una vez se le imprima una fuerza y una direccion, este ultimo se utilizara para definir el Vector Direccion y por regla general, se le sumara el Vector re-Direccion, 
             como sus valores son cero, el Vector Direccion no se vera modificado.
             Pero en el momento de una colision con una pelota, se usara el Vector formado entre ambos puntos centrales de la misma con direccion opuesta a la colision y se lo aplicara en el 
             Vector re-Direccion, de esta forma, como por regla general, al Vector Direccion se le suma el Vector re-Direccion se formara un nuevo vector que parsara a reemplazar al Vector Direccion posterior
             y de esta forma se vera modificado el movimiento.

             Esta regla general se me ocurrio para evitar verificar si una de las pelotas se encuentra en movimiento o esta quieta. De esta manera, cualquier sea el caso, el moviemto sera correcto.
             
             */
        }
        


    }
}
