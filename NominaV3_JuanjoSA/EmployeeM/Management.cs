using System;
using System.Collections.Generic;
using System.Text;

namespace NominaV3_JuanjoSA
{
    static class Management // CLASE PARA LA GESTIÓN DEL EMPLEADO EN GENERAL (DATOS, NOMINA, MODIFICACIONES, CONSULTA...)

    {   // ----------------------------------------------------------------------- GESTIÓN DE USUARIO
        public static Employee EmployeeManagement(Employee employee)
        {
            // CONSTANTES
            // VARIABLES
            Payslip payslip = new Payslip(); // Instanciación Payslip

            byte option; // Opciones del Menú
            bool exit = false; // Booleana para salir del bucle
            

            // MENÚ GESTION DEL TRABAJADOR
            do
            {
                Console.Clear();
                option = NominaV3_JuanjoSA.Principal_Interface.EmployeeManagementMenu(); // Menú gestión empleado

                switch (option)
                {
                    case 1:
                        employee = E_Interface.EmployeeInformation(employee); // Datos personales trabajador
                        break;
                    case 2:
                        employee = P_Interface.PayslipInformation(payslip, employee); // Datos jornada trabajador
                        break;
                    case 3:
                        NominaV3_JuanjoSA.Principal_Interface.ModifyOrDeleteMenu(employee, payslip); // Menú modificar o eliminar
                        break;
                    case 4:
                        NominaV3_JuanjoSA.Principal_Interface.CheckWeekMenu(employee);
                        break;
                    case 5:
                        NominaV3_JuanjoSA.Principal_Interface.Print(employee);
                        
                        break;
                    case 6:
                        exit = true;
                        break;
                }

            } while (!exit);

            return employee;
        }
    }
}
