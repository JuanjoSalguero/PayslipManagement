using System;

namespace NominaV3_JuanjoSA
{
    internal class Program
    {
        // ----------------------------------------------------------------------- MAIN
        static void Main(string[] args)
        {
            // CONSTANTES
            // VARIABLES
            Employee employee = null; // Instanciación Employee

            byte option;
            bool exit = false;

            // MENU PRINCIPAL
            do
            {
                option = Principal_Interface.MainMenu(); // Menú

                switch (option)
                {
                    case 1:
                        employee = Management.EmployeeManagement(employee); // Menú de gestion del usuario
                        break;
                    case 2:
                        Principal_Interface.Exit(); // Salida de la aplicación
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
