using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PROJ_UNIVERSIDADE.Models
{
    public static class CandidaturaValidacao
    {
        public static string? Validar(Candidatura candidatura)
        {
            // Pessoa
            if (string.IsNullOrWhiteSpace(candidatura.NomeCompleto))
                return "O nome completo é obrigatório.";

            if (candidatura.NacionalidadeID <= 0)
                return "A nacionalidade é obrigatória.";

            if (candidatura.SexoID <= 0)
                return "O sexo é obrigatório.";

            if (candidatura.EstadoCivilID <= 0)
                return "O estado civil é obrigatório.";

            if (candidatura.DataNascimento == default)
                return "A data de nascimento é obrigatória.";

            // Documento
            if (candidatura.TipoDocumentoID <= 0)
                return "O tipo de documento é obrigatório.";

            if (string.IsNullOrWhiteSpace(candidatura.NumeroDocumento))
                return "O número do documento é obrigatório.";

            if (candidatura.DataEmissao == default)
                return "A data de emissão é obrigatória.";

            if (candidatura.DataValidade == default)
                return "A data de validade é obrigatória.";

            // Contacto
            if (candidatura.Telefone <= 0)
                return "O telefone é obrigatório.";

            var tel = candidatura.Telefone.ToString();
            if (string.IsNullOrWhiteSpace(tel) || !Regex.IsMatch(tel, @"^\d+$"))
                return "O telefone deve conter apenas números.";

            if (tel.Length < 9 || tel.Length > 15)
                return "O telefone deve ter entre 9 e 15 dígitos.";

            if (string.IsNullOrWhiteSpace(candidatura.Email))
                return "O email é obrigatório.";

            if (!EmailValidacao.Validar(candidatura.Email))
                return "O email é inválido";

            if (string.IsNullOrWhiteSpace(candidatura.Morada))
                return "A morada é obrigatória.";

            // Endereço
            if (candidatura.ProvinciaID <= 0)
                return "A província é obrigatória.";

            if (candidatura.MunicipioID <= 0)
                return "O município é obrigatório.";

            // Pais
            if (string.IsNullOrWhiteSpace(candidatura.NomePai))
                return "O nome do pai é obrigatório.";

            if (string.IsNullOrWhiteSpace(candidatura.NomeMae))
                return "O nome da mãe é obrigatório.";

            // Ensino médio
            if (candidatura.CursoMedioID <= 0)
                return "O curso médio é obrigatório.";

            if (candidatura.AnoConclusao <= 0)
                return "O ano de conclusão é obrigatório.";

            if (candidatura.MediaFinal <= 0)
                return "A média final é obrigatória.";

            if (candidatura.ClasseID <= 0)
                return "A classe é obrigatória.";

            if (string.IsNullOrWhiteSpace(candidatura.InstituicaoEscolar))
                return "A instituição escolar é obrigatória.";

            // Candidatura
            if (candidatura.CampusID <= 0)
                return "O campus é obrigatório.";

            if (candidatura.CursoID <= 0)
                return "O curso é obrigatório.";

            if (candidatura.PeriodoID <= 0)
                return "O período é obrigatório.";

            return null;
        }
    }
}
