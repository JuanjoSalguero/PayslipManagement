using System;
using System.Collections.Generic;
using System.Text;

namespace NominaV3_JuanjoSA
{
    class Payslip
    {   // ----------------------------------------------------------------------- MIEMBROS
        // CONSTANTES
        private const byte MAX_WEEKLY_WORKING_HOURS = 56;    // Jornada normal 40 + 16 horas extras semanales permitidas. 80 al año

        private const float MAX_HOURLY_WAGE = 62.50f;        // Importe hora máxima
        private const float MIN_HOURLY_WAGE = 7.82f;         // Salario mínimo por hora según SMI

        private const byte WEEKLY_WORKING_HOURS = 40;        // Jornada ordinaria semanal

        private const float OVERTIME_BONUS = 1.5f;           // Plus importe hora extra
        private const float IRPF = 16;                       // Porcentaje IRPF

        // MIEMBROS
        private float workedHours;      // Horas trabajadas
        private float hourlyWage;       // Importe de la hora

        // ----------------------------------------------------------------------- CONSTRUCTORES

        public Payslip()
        {
            WorkedHours = 0;
            HourlyWage = 0;
        }

        // ----------------------------------------------------------------------- PROPIEDADES DE LOS ATRIBUTOS

        public float WorkedHours // Propiedad workedhours
        {
            get
            {
                return workedHours;
            }
            set
            {
                // Validaciones horas trabajadas
                if (value < 0) throw new Exception("Las horas trabajadas no pueden ser negativas");
                if (value > MAX_WEEKLY_WORKING_HOURS) throw new Exception("* Las horas trabajadas no pueden ser superior a " + MAX_WEEKLY_WORKING_HOURS + "." +
                    "\n\n\t\t  El trabajador puede realizar como máximo 40 horas ordinarias semanales \n" +
                    "\t\t  y 16 horas extraordinarias semanales. El máximo legal se encuentra en\n" +
                    "\t\t  80 horas extraordinarias anuales.");
                workedHours = value;
            }
        }
        // En ambas validaciones admitimos el 0 para reflejar nóminas no trabajadas o eliminadas
        public float HourlyWage // Propiedad hourlywage
        {
            get
            {
                return hourlyWage;
            }
            set
            {   // Validaciones Importe/hora
                if (value != 0 && value <= MIN_HOURLY_WAGE) throw new Exception("* El importe de la hora trabajada no puede ser menor que el SMI/hora " + MIN_HOURLY_WAGE);
                if (value > MAX_HOURLY_WAGE) throw new Exception("* El importe de la hora trabajada no puede ser mayor a  " + MAX_HOURLY_WAGE);
                hourlyWage = value;
            }
        }

        // ----------------------------------------------------------------------- PROPIEDADES DE LAS CONSTANTES

        public float Irpf => IRPF; // Propiedad IRPF


        // ----------------------------------------------------------------------- MÉTODOS PRIVADOS/PÚBLICOS - FUNCIONALIDAD

        // Método para calcular las horas ordinarias
        private float BasicWorkedHours()
        {
            float basicWorkerHours = 0.0f;

            if (workedHours > WEEKLY_WORKING_HOURS) basicWorkerHours = WEEKLY_WORKING_HOURS;
            else basicWorkerHours = workedHours;

            return basicWorkerHours;
        }
        public float getBasicWorkedHours => BasicWorkedHours();


        // Método para calcular las horas extra
        private float OvertimeHours()
        {
            float overtimeHours = 0.0f;

            if (workedHours > WEEKLY_WORKING_HOURS) overtimeHours = (float)Math.Round(workedHours - WEEKLY_WORKING_HOURS, 2);
            else overtimeHours = 0.0f;

            return overtimeHours;
        }
        public float getOvertimeHours => OvertimeHours();


        // Método para calcular el salario base
        private float BasicSalary()
        {
            float basicSalary;

            basicSalary = (float)Math.Round(BasicWorkedHours() * HourlyWage, 2);

            return basicSalary;
        }
        public float getBasicSalary => BasicSalary();


        // Método para calcular el salario extra
        private float OvertimeSalary()
        {
            float overtimeSalary = 0.0f;

            if (getOvertimeHours != 0) overtimeSalary = (float)Math.Round(getOvertimeHours * (HourlyWage * OVERTIME_BONUS), 2);

            return overtimeSalary;
        }
        public float getOvertimeSalary => OvertimeSalary();


        // Método para calcular el salario bruto
        private float GrossSalary()
        {
            float grossSalary;

            grossSalary = (float)Math.Round(BasicSalary() + OvertimeSalary(), 2);

            return grossSalary;
        }
        public float getGrossSalary => GrossSalary();


        // Método para calcular el importe de la retención
        private float IncomeTax()
        {
            float incomeTax;

            incomeTax = (float)Math.Round(GrossSalary() * (IRPF / 100), 2);

            return incomeTax;
        }
        public float getIncomeTax => IncomeTax();


        // Método para calcular el salario neto
        private float NetSalary()
        {
            float netSalary;

            netSalary = (float)Math.Round(GrossSalary() - IncomeTax(), 2);

            return netSalary;
        }
        public float getNetSalary => NetSalary();
    }
}
