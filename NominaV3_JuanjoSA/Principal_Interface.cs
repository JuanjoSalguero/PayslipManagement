using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace NominaV3_JuanjoSA
{
    static class Principal_Interface // CLASE PARA LA INTERFAZ DEL TRABAJADOR Y DE LA NÓMINA
    {
        // ----------------------------------------------------------------------- MÉTODOS DEL MAIN (Program)

        // Menú de la aplicación
        public static byte MainMenu()
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key

            // ENTRADA
            do
            {
                MainHeader(); // Cabecera de la aplicación
                // OPCIÓN 1
                if (option == 1) Principal_Interface.Option("\t\t\t\t 01.    Gestionar trabajador ");
                else Console.WriteLine("\t\t\t\t 01.    Gestionar trabajador ");

                // OPCIÓN 2
                if (option == 2) Principal_Interface.Option("\t\t\t\t 02.    Salir                ");
                else Console.WriteLine("\t\t\t\t 02.    Salir                ");

                key = Console.ReadKey(true).Key; // Lectura de la tecla

                // Si presionamos la flecha Arriba
                if (key == ConsoleKey.UpArrow)
                {
                    if (option == 1) option = 2;
                    else option--;
                }

                // Si presionamos la fleca Abajo
                if (key == ConsoleKey.DownArrow)
                {
                    if (option == 2) option = 1;
                    else option++;
                }
                Console.Clear();

            } while (key != ConsoleKey.Enter); // Repetir el bucle mientras no se presione ENTER

            // PROCESO
            // SALIDA
            return option;
        }

        // Método para la salida de la aplicación
        static public void Exit()
        {
            Console.SetWindowSize(135, 32);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n\t\t  ----------------------------------------------------------------------------------------------------  ");
            Console.WriteLine($"\t\t |    Los nuevos datos introducidos o modificaciones realizadas han sido guadadas con éxito           | ");
            Console.WriteLine($"\t\t |                                                                                                    | ");
            Console.WriteLine($"\t\t |    Recuerde dar de alta al trabajador en Seguridad Social el mismo día de su fecha de comienzo     | ");
            Console.WriteLine($"\t\t |                                      www.seg-social.es                                             | ");
            Console.WriteLine($"\t\t |                                                                                                    | ");
            Console.WriteLine($"\t\t |                   Para cualquier consulta con respecto al uso de la aplicación                     | ");
            Console.WriteLine($"\t\t |                     no dude en ponerse en contacto con nosotros a través del                       | ");
            Console.WriteLine($"\t\t |                     télefono 957 21 22 23 de Lunes a Viernes de 9:00 a 20:00                       | ");
            Console.WriteLine($"\t\t |                                                                                                    | ");
            Console.WriteLine($"\t\t |                                Att: Juanjo Salguero Acevedo                                        | ");
            Console.WriteLine($"\t\t  ----------------------------------------------------------------------------------------------------  ");
            Console.WriteLine($"\t\t                                                                                                        ");
            Console.WriteLine("\t\t      Presione ENTER para SALIR...                                                                      ");
            Console.WriteLine($"\t\t                                                                                                        ");
            Console.ResetColor();
            Console.ReadLine();
        }

        // Cabecera de la aplicación (MAIN)
        public static void MainHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|                Cálculo de la nómina semanal del trabajador/a                 |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // ----------------------------------------------------------------------- MÉTODOS DE GESTION DEL EMPLEADO (Management)

        // Menú gestión de empleado
        public static byte EmployeeManagementMenu()
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key

            // ENTRADA
            do
            {
                ManagementHeader(); // Cabecera Gestión de usuario

                // OPCIÓN 1
                if (option == 1) Option("\t\t\t\t 01.    Crear nuevo trabajador ");
                else Console.WriteLine("\t\t\t\t 01.    Crear nuevo trabajador ");

                // OPCIÓN 2
                if (option == 2) Option("\t\t\t\t 02.    Incluir nueva jornada  ");
                else Console.WriteLine("\t\t\t\t 02.    Incluir nueva jornada  ");

                // OPCIÓN 3
                if (option == 3) Option("\t\t\t\t 03.    Modificar o Eliminar   ");
                else Console.WriteLine("\t\t\t\t 03.    Modificar o Eliminar   ");

                // OPCIÓN 4
                if (option == 4) Option("\t\t\t\t 04.    Consultar semana       ");
                else Console.WriteLine("\t\t\t\t 04.    Consultar semana       ");

                // OPCIÓN 5
                if (option == 5) Option("\t\t\t\t 05.    Imprimir               ");
                else Console.WriteLine("\t\t\t\t 05.    Imprimir               ");

                // OPCIÓN 6
                if (option == 6) Option("\t\t\t\t 06.    Salir                  ");
                else Console.WriteLine("\t\t\t\t 06.    Salir                  ");

                key = Console.ReadKey(true).Key; // Lectura de la tecla

                // Si presionamos la flecha Arriba
                if (key == ConsoleKey.UpArrow)
                {
                    if (option == 1) option = 6;
                    else option--;
                }

                // Si presionamos la fleca Abajo
                if (key == ConsoleKey.DownArrow)
                {
                    if (option == 6) option = 1;
                    else option++;
                }
                Console.Clear();

            } while (key != ConsoleKey.Enter); // Repetir el bucle mientras no se presione ENTER

            // PROCESO
            // SALIDA
            return option;
        }

        // Menú de modificación o eliminación
        public static void ModifyOrDeleteMenu(Employee employee, Payslip payslip)
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool exit = false; // Booleana para salir del bucle

            // ENTRADA
            do
            {
                do
                {
                    E_Interface.EmployeeModifyHeader(); // Cabecera de la aplicación

                    // OPCIÓN 1
                    if (option == 1) Option("\t\t\t\t 01.    Modificar Trabajador ");
                    else Console.WriteLine("\t\t\t\t 01.    Modificar Trabajador ");

                    // OPCIÓN 2
                    if (option == 2) Option("\t\t\t\t 02.    Modificar Jornada    ");
                    else Console.WriteLine("\t\t\t\t 02.    Modificar Jornada    ");

                    // OPCIÓN 3
                    if (option == 3) Option("\t\t\t\t 03.    Eliminar Jornada     ");
                    else Console.WriteLine("\t\t\t\t 03.    Eliminar Jornada     ");

                    // OPCIÓN 4
                    if (option == 4) Option("\t\t\t\t 04.    Salir                ");
                    else Console.WriteLine("\t\t\t\t 04.    Salir                ");

                    key = Console.ReadKey(true).Key; // Lectura de la tecla

                    // Si presionamos la flecha Arriba
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (option == 1) option = 4;
                        else option--;
                    }

                    // Si presionamos la fleca Abajo
                    if (key == ConsoleKey.DownArrow)
                    {
                        if (option == 4) option = 1;
                        else option++;
                    }
                    Console.Clear();

                } while (key != ConsoleKey.Enter); // Repetir el bucle mientras no se presione ENTER

                // PROCESO
            
                switch (option)
                {
                    case 1:
                        E_Interface.ModifyEmployee(employee);
                        break;
                    case 2:
                        P_Interface.ModifyPayslipIformation(payslip, employee);
                        break;
                    case 3:
                        P_Interface.DeletePayslipInformation(employee);
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (!exit);
            
        }

        // Menú para la consulta de las semanas
        public static void CheckWeekMenu(Employee employee)
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool check = false; // Booleana para el control del bucle del try...Catch

            // ENTRADA
            if (employee == null)
            {
                CheckWeekHeader();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara consultar una jornada, antes debe haber creada alguna jornada semanal.");
                Console.WriteLine("\tPresione ENTER para continuar...                                           ");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                do
                {
                    do
                    {
                        CheckWeekHeader(); // Cabecera de la aplicación

                        // OPCIÓN 1-5
                        for (int i = 0; i < employee.Weeks; i++)
                        {
                            if (option == i + 1) Option($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                            else Console.WriteLine($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                        }

                        // OPCIÓN 6
                        if (option == 6) Option("\t\t\t\t Salir    ");
                        else Console.WriteLine("\t\t\t\t Salir    ");

                        key = Console.ReadKey(true).Key; // Lectura de la tecla

                        // Si presionamos la flecha Arriba
                        if (key == ConsoleKey.UpArrow)
                        {
                            if (option == 1) option = 6;
                            else option--;
                        }

                        // Si presionamos la fleca Abajo
                        if (key == ConsoleKey.DownArrow)
                        {
                            if (option == 6) option = 1;
                            else option++;
                        }
                        Console.Clear();

                    } while (key != ConsoleKey.Enter); // Repetir el bucle mientras no se presione ENTER

                    try
                    {
                        if (option == 6) check = true; // Si la opción es 6, salimos
                        else
                        {
                            // Validación si la semana está en 0
                            employee.WeekValidation(option, "* Semana sin datos de la jornada del trabajador.");

                            Console.SetWindowSize(155, 32);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(employee.CheckWeek(option));
                            Console.WriteLine(" _____________________________________________________________________________________________________________________________________________________ \n");
                            Console.WriteLine("                                                         Presione ENTER para continuar...");
                            Console.ResetColor();
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                    catch (Exception e)
                    {
                        ErrorCatcher(e.Message);
                    }

                }while (!check);
            }                  
        }

        // Imprimir nómina mensual
        public static void Print(Employee employee)
        {
            if (employee == null) // Si no se han introducidos datos del empleado
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara ver la nómina mensual de un trabajador, antes debe estar creado el trabajador y alguna jornada semanal.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                                            ");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                Console.SetWindowSize(155, 32);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(employee.ToString()); // Imprimir nómina mensual
                Console.WriteLine("                                                         Presione ENTER para continuar...");
                Console.ReadLine();
                Console.ResetColor();
            }
        }


        // ----------------------------------------------------------------------- OTROS MÉTODOS

        // Opciónes del menú cuando se marquen con las flechas
        public static void Option(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Metodo estándar para capturar excepciones
        public static void ErrorCatcher(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n\t\t" + message);
            Console.WriteLine("\t\t  Presiona ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.ResetColor();
        }

        // ----------------------------------------------------------------------- CABECERAS

        // Cabecera Gestion del trabajador (EmployeeM)
        public static void ManagementHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|                    Gestión de la Nómina del trabajador                       |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // Cabecera de la nómina
        public static void PayslipHeader() 
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|            Introducción de la jornada laboral del trabajador                 |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // Cabecera consulta nómina semanal
        public static void CheckWeekHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|             Consulta de la jornada semanal ¿Cuál desea consultar?             |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
