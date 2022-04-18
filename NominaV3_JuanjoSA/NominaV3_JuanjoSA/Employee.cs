using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NominaV3_JuanjoSA
{
    class Employee
    {
        // ----------------------------------------------------------------------- MIEMBROS
        // CONSTANTES
        private const byte MAX_NAME = 15;                    // Caracteres máximos para el nombre
        private const byte MAX_SURNAMES = 30;                 // Caracteres máximos para los apellidos
        private const byte MAX_CATEGORY = 15;                 // Caracteres máximos para la categoría

        private const byte MAX_DNI = 9;                       // Caracteres del DNI

        private const byte WEEKS = 5;                        // Semanas

        // MIEMBROS
        private string name;            // Nombre del trabajador
        private string surnames;        // Apellidos del trabajador
        private string dni;             // Dni del trabajador
        private string category;        // Puesto de trabajo del trabajador

        // ----------------------------------------------------------------------- NÓMINA MENSUAL

        private List<Payslip> monthPay;

        // ----------------------------------------------------------------------- CONSTRUCTOR

        // Constructor obligatorio
        public Employee(string dni) 
        {
            Name = "Unknow";
            Surnames = "Unknow";
            DniValidation(dni);
            Category = "Unknow";
            monthPay = new List<Payslip>();
            //Inicialización Lista Payslip
            for (int i = 0; i < WEEKS; i++) monthPay.Insert(i, new Payslip());
        }

        // ----------------------------------------------------------------------- PROPIEDADES DE LOS ATRIBUTOS

        public string Name // Propiedad nombre 
        {
            get 
            {
                return name;
            }
            set 
            {
                Validation(value); // Validación string

                // Validación caracteres máximos
                if (value.Length > MAX_NAME) throw new Exception($"* El NOMBRE no puede contener más de {MAX_NAME} caracteres.");

                name = SpacesReplace(value);
            }
        }
 
        public string Surnames // Propiedad apellidos 
        {
            get 
            {
                return surnames;
            }
            set 
            {
                Validation(value); // Validación string

                // Validación caracteres máximos
                if (value.Length > MAX_SURNAMES) throw new Exception($"* Los APELLIDOS no puede contener más de {MAX_SURNAMES} caracteres.");

                surnames = SpacesReplace(value);
            }   
        }

        public string Dni => dni; // Propiedad dni (Sólo lectura)

        public string Category // Propiedad puesto 
        {
            get 
            {
                return category;
            }
            set
            {
                Validation(value);

                // Validación caracteres máximos
                if (value.Length > MAX_CATEGORY) throw new Exception($"* La CATEGORIA no puede contener más de {MAX_CATEGORY} caracteres.");

                category = SpacesReplace(value);
            }
        }

        // ----------------------------------------------------------------------- PROPIEDAD DE LAS CONSTANTES

        public byte Weeks => WEEKS; // Propiedad WEEKS

        // ----------------------------------------------------------------------- MÉTODOS PRIVADOS - INTERNOS
        
        // Método para la validación de la cadena introducida
        private void Validation(string value) 
        {
            value = value.ToUpper(); // Pasamos la cadena a UPPER para las validaciones

            // Validación espacios en blanco
            if (String.IsNullOrWhiteSpace(value)) throw new Exception("* Este campo no puede estar formado por espacios en blanco.");

            // Validación campo vacío
            if (String.IsNullOrEmpty(value)) throw new Exception("* Este campo no puede estar vacío.");

            // Validación caracteres
            for (int i = 0; i < value.Length; i++)
            {
                if (!((value[i] >= 65 && value[i] <= 90) || value[i] == 32 || value[i] == 'Ñ' ||
                    value[i] == 'Á' || value[i] == 'É' || value[i] == 'Í' || value[i] == 'Ó' || value[i] == 'Ú'))
                    throw new Exception("* La cadena introducida contiene caracteres no válidos.");
            }
        }

        // Método para eliminar espacios duplicados en una cadena
        private string SpacesReplace(string value)
        {
            // Suprimir los espacios en blanco sobrantes (cuando haya mas de uno seguido)
            value = Regex.Replace(value, @"\s+", " "); // Elimina los espacios duplicados en 
            // Elimina los espacios en blanco tanto del principio como del final
            value = value.Trim();

            return value;
        }

        // Método para la validación del DNI
        private void DniValidation(string dni)
        {
            dni = dni.ToUpper(); // Pasamos a UPPER para la validación del ultimo caracter
            // Validación de la longitud del Dni
            if (dni.Length != MAX_DNI) throw new Exception("* El DNI debe contener 9 caracteres obligatoriamente.");

            // Validación de los 8 números del dni (48 - 57)
            for (int i = 0; i < MAX_DNI - 1; i++)
            {
                if (!(dni[i] >= 48 && dni[i] <= 57)) throw new Exception("* Los primero 8 caracteres del DNI deben ser números.");
            }

            // Validación de que el ultimo caracter del dni sea letra
            if (!(dni[8] >= 65 && dni[8] <= 90)) throw new Exception("* El ultimo caracter del DNI debe ser una letra.");

            // Validación de que sea un DNI correcto
            // Extraemos los 8 primeros caracteres del string y hacemos el modulo de 23
            char[] dniLetter = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};
            if (dniLetter[Int32.Parse(dni.Substring(0, 8)) % 23] != dni[8])
                throw new Exception("* El DNI introducido no es un DNI válido.");

            this.dni = dni;
        }

        // ----------------------------------------------------------------------- MÉTODOS 

        // Método para insertar/modificar las horas trabajadas
        public void InsertWorkedHours(byte option, float hours)
        {
            monthPay[option - 1].WorkedHours = hours; // Horas
        }

        // Método para insertar el importe de las horas trabajadas
        public void InsertHourlyWage(byte option, float wage)
        {
            monthPay[option - 1].HourlyWage = wage; // Importe
        }

        // Método de validación si la semana seleccionada ya ha sido creada (Insertar nómina)
        public void CreatedWeekValidation(byte option)
        {
            // Validación de no modificar una semana sin estar introducida
            if (monthPay[option - 1].WorkedHours != 0) throw new Exception("* Semana ya creada, para modificarla acceda a su correspondiente menú.");
        }

        // Método para devolver la Nómina al completo
        public Payslip getMonthlyPayslip(int i)
        {
            return monthPay[i];
        }

        // Validación eliminación jornada y modificación jornada
        public void WeekValidation(byte option, string message)
        {
            if (monthPay[option - 1].WorkedHours == 0)
            {
                throw new Exception(message);
            }
        }

        // ----------------------------------------------------------------------- OVERRIDE 

        // Método para consultar la nomina semanal
        public string CheckWeek(byte i)
        {
            string week = " ";

            week = " _____________________________________________________________________________________________________________________________________________________ \n" +
                $"|  Puesto: {Category}\n\n|  DNI: {Dni}\t\tNombre: {Name}\t\tApellidos: {Surnames}\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n" +
                $"|\t\t\tHoras\tEuros/Hora\tHoras Extra\tSal. Extra\tSal. Base\tSal. Bruto\tRetención({monthPay[0].Irpf}%)        Sal. Neto\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n" +
                $"|\tSemana {i}" +
                $"\t{monthPay[i - 1].WorkedHours}\t{monthPay[i - 1].HourlyWage}\t\t{monthPay[i - 1].getOvertimeHours}" +
                $"\t\t{monthPay[i - 1].getOvertimeSalary}\t\t{monthPay[i - 1].getBasicSalary}\t\t{monthPay[i - 1].getGrossSalary}" +
                $"\t\t{monthPay[i - 1].getIncomeTax}\t                {monthPay[i - 1].getNetSalary}\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n" +
                " _____________________________________________________________________________________________________________________________________________________ \n";

            return week;
        }

        // Método para imprimir la nómina 
        public override string ToString()
        {
            string print = "";

            print = " _____________________________________________________________________________________________________________________________________________________ \n" +
                $"|  Puesto: {Category}\n\n|  DNI: {Dni}\t\tNombre: {Name}\t\tApellidos: {Surnames}\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n" +
                $"|\t\t\tHoras\tEuros/Hora\tHoras Extra\tSal. Extra\tSal. Base\tSal. Bruto\tRetención({monthPay[0].Irpf}%)        Sal. Neto\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n";
            for (int i = 0; i < Weeks; i++)
            {
                print += $"|\tSemana {i + 1}" +
                    $"\t{monthPay[i].WorkedHours}\t{monthPay[i].HourlyWage}\t\t{monthPay[i].getOvertimeHours}" +
                    $"\t\t{monthPay[i].getOvertimeSalary}\t\t{monthPay[i].getBasicSalary}\t\t{monthPay[i].getGrossSalary}" +
                    $"\t\t{monthPay[i].getIncomeTax}\t                {monthPay[i].getNetSalary}\n" +
                    " _____________________________________________________________________________________________________________________________________________________ \n";
            }
            print += " _____________________________________________________________________________________________________________________________________________________ \n" +
                "|  TOTAL MES:" +
                $"\t\t{monthPay.Sum(x => x.WorkedHours)}\t\t\t{monthPay.Sum(x => x.getOvertimeHours)}\t\t" +
                $"{Math.Round(monthPay.Sum(x => x.getOvertimeSalary), 2)}\t\t{Math.Round(monthPay.Sum(x => x.getBasicSalary), 2)}\t\t{Math.Round(monthPay.Sum(x => x.getGrossSalary), 2)}" +
                $"\t\t{Math.Round(monthPay.Sum(x => x.getIncomeTax), 2)}\t                {Math.Round(monthPay.Sum(x => x.getNetSalary), 2)}\n" +
                " _____________________________________________________________________________________________________________________________________________________ \n";

            return print;
        }
    }
}
