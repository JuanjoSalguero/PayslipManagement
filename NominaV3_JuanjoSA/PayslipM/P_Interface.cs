using System;
using System.Collections.Generic;
using System.Text;

namespace NominaV3_JuanjoSA
{
    static class P_Interface
    {
        // ----------------------------------------------------------------------- MÉTODOS DE SOLICITUD DE DATOS

        // Método de solicitud de las horas trabajadas y el importe                 (Payslip)
        static public Employee PayslipInformation(Payslip payslip, Employee employee)
        {
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool exit = false;  // Booleana para controlar la salida del bucle
            bool check = false;  // Booleana para controlar la salida del bucle del try...catch

            if (employee == null) // Si se intenta insertar la jornada de un trabajador antes de insertar sus datos
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara insertar datos de la jornada de un trabajador, antes debe estar creado el trabajador.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                          ");
                Console.ResetColor();
                Console.ReadLine();
            }
            else // Si ya están insertados los datos del trabajador
            {
                do
                {
                    do
                    {
                        InsertWeekHeader(); // Cabecera

                        // MENÚ OPCIONES 1-5
                        for (int i = 0; i < employee.Weeks; i++)
                        {
                            if (option == i + 1) Principal_Interface.Option($"\t\t\t\t Semana {i + 1} ");
                            else Console.WriteLine($"\t\t\t\t Semana {i + 1} ");
                        }

                        // OPCIÓN 6
                        if (option == 6) Principal_Interface.Option($"\t\t\t\t Salir    ");
                        else Console.WriteLine($"\t\t\t\t Salir    ");

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

                    if (option != 6) // Si la opción no se 6
                    {

                        try
                        {
                            InsertWeekHeader(); // Cabecera

                            // Validación de no modificar una semana sin estar introducida
                            employee.CreatedWeekValidation(option);

                            // Solicitud y lectura de los datos de la semana X
                            employee.InsertWorkedHours(option, WorkedHours(payslip, employee, option)); // Horas

                            // Solicitud y lectura de los datos de la semana X
                            employee.InsertHourlyWage(option, HoursWage(payslip, employee, option));
                            Console.Clear();

                            check = true;
                        }
                        catch (Exception e)
                        {
                            Principal_Interface.ErrorCatcher(e.Message);
                        }
                    }
                    else exit = true;

                } while (!exit && check);
            }
            return employee;
        }

        // Métodos de solicitud de Horas trabajadas y precio hora
        static public float WorkedHours(Payslip payslip, Employee employee, byte option)
        {
            bool check = false;
            float aux = 0;

            do
            {
                try
                {   // Solicitud horas
                    payslip.WorkedHours = ReadFloat($"\tIntroduzca las horas trabajadas de {employee.Name} de la Semana {option}:");
                    aux = payslip.WorkedHours;
                    check = true;
                }
                catch (Exception e)
                {
                    Principal_Interface.ErrorCatcher(e.Message);
                }
            } while (!check);

            return aux;
        }
        static public float HoursWage(Payslip payslip, Employee employee, byte option)
        {
            bool check = false;
            float aux = 0;

            do
            {
                try
                {   // Solicitud importe horas
                    payslip.HourlyWage = ReadFloat($"\tIntroduzca el precio de la hora trabajada por {employee.Name} de la Semana {option}:");
                    aux = payslip.HourlyWage;
                    check = true;
                }
                catch (Exception e)
                {
                    Principal_Interface.ErrorCatcher(e.Message);
                }
            } while (!check);

            return aux;
        }

        // ----------------------------------------------------------------------- MÉTODOS DE MODIFICACIÓN DE DATOS

        // Menú de modificacion semanas trabajadas
        static public void ModifyPayslipIformation(Payslip payslip, Employee employee)
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool exit = false; // Booleana para salir del bucle
            bool check = false; // Booleana para controlar el bucle del try... catch

            // ENTRADA
            if (employee == null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara modificar los datos de la nómina, antes debe estar creada alguna jornada semanal.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                      ");
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

                        PayslipModifyHeader(); // Cabecera
                        for (int i = 0; i < employee.Weeks; i++)
                        {
                            if (option == i + 1) Principal_Interface.Option($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                            else Console.WriteLine($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                        }

                        // OPCIÓN 6
                        if (option == 6) Principal_Interface.Option($"\t\t\t\t Salir    ");
                        else Console.WriteLine($"\t\t\t\t Salir    ");

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

                    if (option == 6) exit = true;
                    else
                    {
                        do
                        {
                            try
                            {
                                PayslipModifyHeader();
                                check = true;
                                // Validación si la semana aún no está creada
                                employee.WeekValidation(option, "* La semana que desea modificar no tiene datos, acceda al menú correspondiente para crearla.");

                                // Solicid de la modificación
                                employee.InsertWorkedHours(option, WorkedHours(payslip, employee, option)); // Horas

                                // Solicid de la modificación
                                employee.InsertHourlyWage(option, HoursWage(payslip, employee, option)); // Importe horas 
                            }
                            catch (Exception e)
                            {
                                Principal_Interface.ErrorCatcher(e.Message);
                            }

                        } while (!check);
                    }
                    Console.Clear();
                } while (!exit);
            }
        }

        // Menú de eliminación semanas trabajadas 
        static public Employee DeletePayslipInformation(Employee employee)
        {
            //CONSTANTES
            // VARIABLES
            byte option = 1; // Variable para las opciones del menú
            ConsoleKey key = 0; // Inicialización método ConsoleKey con el nombre de variable key
            bool exit = false; // Booleana para salir del bucle
            string aux; // Variable para la lectura del usuario de si eliminar o no la semana
            bool check = false; // Booleana para controlar la salida del try catch

            // ENTRADA
            if (employee == null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n\tPara eliminar los datos de la nómina, antes debe estar creada alguna jornada semanal.");
                Console.WriteLine("\tPresione ENTER para continuar...                                                     ");
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
                        PayslipDeleteHeader(); // Cabecera

                        for (int i = 0; i < employee.Weeks; i++)
                        {
                            if (option == i + 1) Principal_Interface.Option($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                            else Console.WriteLine($"\t\t\t\t Semana {i + 1}:\t {employee.getMonthlyPayslip(i).WorkedHours} horas\t{employee.getMonthlyPayslip(i).HourlyWage} Euros/h ");
                        }

                        // OPCIÓN 6
                        if (option == 6) Principal_Interface.Option($"\t\t\t\t Salir    ");
                        else Console.WriteLine($"\t\t\t\t Salir    ");

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

                    if (option == 6) exit = true;
                    else
                    {
                        do
                        {
                            try
                            {
                                PayslipDeleteHeader(); // Cabecera

                                // Validación si la semana no esta creada y se intenta eliminar
                                check = true;
                                employee.WeekValidation(option, "* Semana sin datos de la jornada, para crearla acceda a su correspondiente menú.");

                                Console.WriteLine($"\n\t\t¿Está seguro de que desea eliminar la Semana {option}?");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\t\t\tS para eliminar N para anular");
                                Console.ResetColor();
                                aux = Console.ReadLine().ToUpper();

                                if (aux == "S")
                                {
                                    employee.InsertWorkedHours(option, 0);
                                    employee.InsertHourlyWage(option, 0);

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\t\tSemana ELIMINADA con éxito.");
                                    Console.WriteLine("\t\tPresione ENTER para continuar...");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    check = true;
                                }
                                else if (aux == "N")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\t\tAcción cancelada.\n\t\tPresione ENTER para continuar...");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    check = true;
                                }
                                else
                                {
                                    check = false;
                                    throw new Exception("* Decidisión desconocida.");
                                }
                            }
                            catch (Exception e)
                            {
                                Principal_Interface.ErrorCatcher(e.Message);
                            }

                        } while (!check);
                    }
                    Console.Clear();
                } while (!exit);
            }
            return employee;
        }

        // ----------------------------------------------------------------------- LECTURA DE DATOS

        // Método para la lectura de Float
        static public float ReadFloat(string message)
        {
            // CONSTANTES
            // VARIABLES
            float aux;

            // ENTRADA
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\t" + message + "\n");
            Console.ResetColor();
            Console.Write("\t\t");
            if ((aux = float.Parse(Console.ReadLine())) == 0)
            {
                throw new Exception("* Si desea eliminar la semana, deberá acceder a su correspondiente menú.");
            }

            // PROCESO
            // SALIDA
            return aux;
        }

        // ----------------------------------------------------------------------- HEADERS

        // Cabecera crear semana
        public static void InsertWeekHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|                    Insertar una nueva jornada semanal                         |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // Cabecera modificación jornada del trabajador
        public static void PayslipModifyHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|         Modificación de la jornada semanal ¿Cuál desea modificar?            |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }

        // Cabecera eliminación jornada del trabajador
        public static void PayslipDeleteHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t ------------------------------------------------------------------------------");
            Console.WriteLine("\t|          Eliminación de la jornada semanal ¿Cuál desea Eliminar?             |");
            Console.WriteLine("\t ------------------------------------------------------------------------------\n");
            Console.ResetColor();
        }
    }
}
