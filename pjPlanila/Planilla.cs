using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPlanila
{
    public class Planilla
    {
        //caracteristicas
        public string empleado { get; set; }
        public string cargo { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int años { get; set; }

        //metodos
        public int añosServicio()
        {
            return DateTime.Now.Year - fechaIngreso.Year;
        }

        public string mesconsultado()
        {
            int mes = DateTime.Now.Month;
            switch (mes)
            {
                case 1: return "Enero";
                case 2: return "Febrero";
                case 3: return "Marzo";
                case 4: return "Abril";
                case 5: return "Mayo";
                case 6: return "Junio";
                case 7: return "Julio";
                case 8: return "Agosto";
                case 9: return "Septiembre";
                case 10: return "Octubre";
                case 11: return "Noviembre";
                case 12: return "Diciembre";
            }
            return "";
        }

        //Determinar el sueldo basico
        public double DeterminaBasico()
        {
            switch (cargo)
            {
                case "Coordinador": return 2000;
                case "Jefe": return 4000;
                case "Capacitador": return 2500;
                case "Asistente": return 1200;
            }
            return 0;
        }

        //Determinar el monto de gratificacion
        public double DeterminaGratificacion()
        {
            if (mesconsultado() == "Abril")
                return 400;
            else if (mesconsultado() == "Julio")
                return 450;
            else if(mesconsultado() == "Diciembre")
                return DeterminaBasico() * 2;
            return 0;
        }

        //Determinar la comision
        public double DeterminarComision()
        {
            if (cargo == "Asistente")
                return 100;
            else if (cargo == "Coordinador")
                return 250;
            return 0;
        }

        //Determinar el monto de descuento del ahorro de cooperativa
        public double DeterminarDescuentoCooperativa()
        {
            if (cargo == "Jefe")
                return (5.0 / 100) * DeterminaBasico();
            else if (cargo == "Capacitador")
                return (2.0 / 100) * DeterminaBasico();
            return 0;
        }

        //Determina el monto de aportacion al seguro social
        public double DeterminaAportacionSeguro()
        {
            return 0.07 * DeterminaBasico();
        }

        // Calculando totales
        public double CalculaTotalIngresos()
        {
            return DeterminaBasico() + DeterminaGratificacion() + DeterminarComision() ;
        }

        public double CalculaTotalDescuentos()
        {
            return DeterminarDescuentoCooperativa();
        }

        public double CalculaTotalAportaciones()
        {
            return DeterminaAportacionSeguro();
        }

        //Determina el monto neto del empleado
        public double DetermionaNeto()
        {
            return CalculaTotalIngresos() - CalculaTotalDescuentos() - CalculaTotalAportaciones();
        }

    }
}
