using System;
using System.Text.RegularExpressions;

namespace Punto1
{
    internal class ValidarTarjeta
    {
        public string Number { get; set; }
        public string Messaje { get; set; }/*
        public bool NumNul { get; set; }
        public bool YearNull { get; set; }
        public bool LenghNumber { get; set; }
        public bool NumbarCharactersYear { get; set; }
        public bool CharactrsYearDigit { get; set; }
        public bool Betw07y20 { get; set; }
        public bool CadYear { get; set; }
        public bool NumberStarts { get; set; }
        public bool ValidateAll { get; set; }*/
        public ValidarTarjeta()
        {
            Number = "0";
            /* NumNul = false;
             YearNull = false;
             LenghNumber = false;
             NumbarCharactersYear = false;
             CharactrsYearDigit = false;
             Betw07y20 = false;
             CadYear = false;
             NumberStarts = false;
             ValidateAll = false;*/
        }
        public bool NumeroNulo(string Number)
        {
            if (Number is null) {
                Messaje = "Numero de tarjeta nulo";
                return true; }
            Messaje = "Numero de tarjeta ingresado";
            return false;
        }
        public bool FechaCadNula(string Number)
        {
            if (Number.Length == 0) {
                Messaje = "Ingresar Fecha";
                return true; }
            Messaje = "Fecha Correcta";
            return false;
        }
        public bool LenghNumber16(string Number)
        {
            if (Number.Length != 16) {
                Messaje = "Error cantidad de numeros en la tarjeta";
                return true; }
            Messaje = "Cantidad de numeros en la tarjeta correcta";
            return false;
        }
        public bool Betw07y20year(string Number)
        {

            string[] x = (Regex.Split(Number, string.Empty));
            int TXTNumber = Convert.ToInt32(x[4] + x[5]);
            if (TXTNumber > 20 || TXTNumber < 7) {
                Messaje = "Año de caducidad invalido";
                return true; }
            Messaje = "Año de caducidad correcto";
            return false;
        }
        public bool CadYearMet(string Number)
        {
            if (Convert.ToInt32(Number) < Convert.ToInt32(DateTime.Now.Date.ToString("yyyy")))
            {
                Messaje = "Caducado el año";
                return true; }
            Messaje = "Año correcto";
            return false;
        }
        public bool NumberStarts(string Number)
        {
            string[] x = (Regex.Split(Number, string.Empty));
            if (x[1] == "4" || (x[1]+x[2])=="13"|| (x[1] + x[2]) == "16") {
                Messaje = "Digitos de inicio de la tarjeta correctos";
                return false; }
            Messaje =  "Error digitos de inicio de la tarjeta";
            return true;
        }
    }
}
