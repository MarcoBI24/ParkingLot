using System;
using System.Globalization;
public class Program
{
    public static void Main()
    {
      
        /* Máquina de Estacionamiento:

        1.- El sistema realizará la impresión de la hora y minuto en la cual comienza a correr el tiempo ("Boleto").
        2.- El sistema hará el cobro con la tarifa de $30.00 por las primeras dos horas y $12 por cada fracción de 15 minutos posteriores.
        3.- El sistema solicitará al usuario que ingrese la hora y minuto de salida (Ingresar Boleto nuevamente al salir).
        4.- El sistema imprimirá en pantalla el total a pagar.
        5.- El sistema solicitará el pago en denominaciones de $1, $5, $10, $20, $50, $100 (Inserción de pago).
        6.- El sistema imprimirá en pantalla las monedas necesarias para saldar el cambio (Expulsión de cambio). */






        //hora de ingreso
        //minuto de ingreso
        //hora de salida 
        //minuto de salida
        
        Console.WriteLine(@"Bienvenido el Estacionamiento
        El precio por las primeras 2 horas es de $30.00 y $12.00 por cada fracción de 15 minutos posteriores.
        GRACIAS...");
        //pagado
        bool pagado=false;
        //vuelto
        int vuelto=0;
        //pago
        int pago;
        //pago total
        int pagoTotal=0;
        //monto a pagar por minuto
        int montoPagoMin=0;
        //monto a pagar por hora
        int montoPagoHora=0;
        //minutos de estacionamiento
        int minutoEstacionamiento;
        //horas de estacionamiento
        int horaEstacinamiento;
        //minuto de salida
        int minutoSalida;
        //hora de salida 
        int horaSalida;
        //numero del boleto (random)
        Random nBoleto=new Random();
        int Nboleto=nBoleto.Next(1000,2000);
        //hora actual
        DateTime horaActual = DateTime.Now;
        //hora actual convertirdo a ticks
        TimeSpan tiempoEntrada=new TimeSpan(horaActual.Ticks);
        //hora de ingreso
        int horaIngreso=tiempoEntrada.Hours;
        //minutos de ingreso
        int minutoIngreso=tiempoEntrada.Minutes;
        //Boleto
        Console.WriteLine("------------------------Su Boleto----------------------------");
        Console.WriteLine("--------> FECHA: "+horaActual+"-------------------------");
        Console.WriteLine("--------> HORA DE ENTRADA: "+tiempoEntrada.Hours+" horas--------------------------");
        Console.WriteLine("--------> MINUTO DE ENTRADA: "+tiempoEntrada.Minutes+" min--------------------------");
        Console.WriteLine("----------------N° del boleto: "+Nboleto);
        //para ver si quiere salir 
        for (int i = 0; i < 2; i++)
        {
          Console.WriteLine("digite su N° del boleto para salir");
          int numer = Convert.ToInt32(Console.ReadLine());
          if(numer==Nboleto)
          {
            //preguntando la hora y minuto de salida
            Console.WriteLine(">>>Digite la hora de salida: ");
            horaSalida=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(">>>Digite el minuto de salida: ");
            minutoSalida=Convert.ToInt32(Console.ReadLine());
            //sacando las horas de estacionamiento
            horaEstacinamiento=horaSalida-horaIngreso;
            //sacando minutos de estacionamiento
            minutoEstacionamiento=minutoSalida-minutoIngreso;
            //monto a pagar
            if(horaEstacinamiento>=2)
            {  
              
              for (int m = 2; m <= horaEstacinamiento; m+=2)
              {
                montoPagoHora+=30;
              }
               if(minutoEstacionamiento>=15)
                {
                  for (int n = 15; n <= minutoEstacionamiento;n=n+15)
                  {
                    montoPagoMin+=12;
                  }
                  
                }
            }
            pagoTotal=montoPagoHora+montoPagoMin;
            Console.WriteLine("El monto a pagar es "+pagoTotal+"$");
            if (pagoTotal != 0)
            {
              //cobro del monto total
              while (pagado==false)
              { 
                Console.WriteLine("-------puede pagar con $1, $5, $10, $20, $50, $100 ---------");
                pago=Convert.ToInt32(Console.ReadLine());
                if (pago<=pagoTotal)
                {
                  pagoTotal=pagoTotal-pago;
                  Console.WriteLine("Le falta pagar: "+pagoTotal);
                  if (pagoTotal==0)
                    {
                      pagado=true;
                      continue;
                    }
                    continue;
                }
                if(pago>pagoTotal)
                  {
                    pago=pago-pagoTotal;
                    vuelto=pago+0;
                    Console.WriteLine("Su vuelto es: "+vuelto+" $ gracias por su eleccion");
                    pagado=true;
                  }
                
                
              
              }
            }
           
            
            i+=2;
          }
          else
          {
            Console.WriteLine("Sigue intentando...");
            i-=1;
          } 
        }
       
        
        
      Console.ReadKey();
    }
}