using System;
using System.Collections.Generic;
using System.Text;

namespace NominaV3_JuanjoSA
{
    static class E_Interface
    {
        // ----------------------------------------------------------------------- MÉTODOS DE SOLICITUD DE DATOS

        // Método de solicitud de la información personal del trabajador            (Employee)
        static public Employee EmployeeInformation(Employee employee)
        {
            bool check = false;

            if (employee == null) // Si los datos del empleado están vacíos
            {
                EmployeeHeader(); // Cabecera

                // Inicialización constructor, solicitud y lectura del dato obligatorio DNI
                do
                {
                    try
                    {
                        employee = new Employee(ReadString("\tIntroduzca el DNI del trabajador: "));
                        check = true;
                    }
                    catch (Exception e)
                    {
                        Principal_Interface.ErrorCatcher(e.Message);
                    }
                } while (!check);

                // Solicitud y Lectura nombre
                employee = Name(employee);

                // Solicitud y Lectura apellidos
                employee = Surnames(employee);

                // Solicitud y Lectura apellidos
                employee = Category(employee);

                // Mensaje de confirmación
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tEl trabajador {employee.Surnames}, {employee.Name} con DNI {employee.Dni} como {employee.Category}");
                Console.WriteLine($"\tha sido creado correctamente.                                            ");
                Console.WriteLine("\tPresione ENTER para continuar...                                         ");
                Console.ResetColor();
                Console.ReadLine();
            }
            else // Si ya se han introducido datos del trabajador
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tYa han sido insertados datos de un TRABAJADOR, si desea modificarlos, vuelva al menu anterior.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                              ");
                Console.ResetColor();
                Console.ReadLine();
            }

            return employee;
        }

        // Metodos de solicitud de Nombre, apellidos y categoría
        static public Employee Name(Employee employee)
        {
            bool check = false;

            do
            {
                try
                {
                    employee.Name = ReadString("\tIntroduzca el NOMBRE del trabajador: ");
                    check = true;
                }
                catch (Exception e)
                {
                    Principal_Interface.ErrorCatcher(e.Message);
                }
            } while (!check);

            return employee;
        }
        static public Employee Surnames(Employee employee)
        {
            bool check = false;

            do
            {
                try
                {
                    employee.Surnames = ReadString($"\tIntroduzca los APELLIDOS de {employee.Name}: ");
                    check = true;
                }
                catch (Exception e)
                {
                    Principal_Interface.ErrorCatcher(e.Message);
                }
            } while (!check);

            return employee;
        }
        static public Employee Category(Employee employee)
        {
            bool check = false;

            do
            {
                try
                {
                    employee.Category = ReadString($"\tIntroduzca el PUESTO de {employee.Surnames}, {employee.Name}: ");
                    check = true;
                }
                catch (Exception e)
                {
                    Principal_Interface.ErrorCatcher(e.Message);
                }
            } while (!check);

            return employee;
        }

        // ----------------------------------------------------------------------- MÉTODOS DE MODIFICACIÓN DE DATOS

        // Menú de modificación información del empleado
        static public void ModifyEmployee(Employee employee)
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool exit = false; // Booleana para salir del bucle

            // ENTRADA
            if (employee == null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara modificar los datos de un trabajador, antes debe estar creado el trabajador.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                 ");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                do
                {
                    do
                    {
                        EmployeeModifyHeader(); // Cabecera

                        // OPCIÓN 1
                        if (option == 1) Principal_Interface.Option($"\t\t\t\t 01.    Nombre: \t{employee.Name} ");
                        else Console.WriteLine($"\t\t\t\t 01.    Nombre: \t{employee.Name}");

                        // OPCIÓN 2
                        if (option == 2) Principal_Interface.Option($"\t\t\t\t 02.    Apellidos: \t{employee.Surnames} ");
                        else Console.WriteLine($"\t\t\t\t 02.    Apellidos: \t{employee.Surnames} ");

                        // OPCIÓN 3
                        if (option == 3) Principal_Interface.Option($"\t\t\t\t 03.    Puesto: \t{employee.Category} ");
                        else Console.WriteLine($"\t\t\t\t 03.    Puesto: \t{employee.Category} ");

                        // OPCIÓN 4
                        if (option == 4) Principal_Interface.Option("\t\t\t\t 04.    Salir");
                        else Console.WriteLine("\t\t\t\t 04.    Salir");

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
                            Name(employee);
                            break;
                        case 2:
                            Surnames(employee);
                            break;
                        case 3:
                            Category(employee);
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                    Console.Clear();

                } while (!exit);
            }
            Console.Clear();
        }

        // ----------------------------------------------------------------------- LECTURA DE DATOS

        // Método para la lectura de String
        static public string ReadString(string message)
        {
            // CONSTANTES
            // VARIABLES
            string aux = "";

            // ENTRADA
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\t" + message + "\n");
            Console.ResetColor();
            Console.Write("\t\t");
            aux = Console.ReadLine();

            // PROCESO
            // SALIDA
            return aux;
        }

        // ----------------------------------------------------------------------- HEADERS

        // Cabecera del empleado
        public static void EmployeeHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|                    Introducción de datos del trabajador                      |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // Cabecera de la modificación de los datos del trabajador
        public static void EmployeeModifyHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|         Modificación datos del trabajador ¿Cuál desea modificar?             |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
