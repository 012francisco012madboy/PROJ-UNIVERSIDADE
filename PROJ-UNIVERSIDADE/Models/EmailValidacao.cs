using System.Text.RegularExpressions;

namespace PROJ_UNIVERSIDADE.Models
{
    public static class EmailValidacao
    {
        public static bool Validar(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }
    }
}