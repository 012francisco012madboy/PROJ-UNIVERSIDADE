namespace PROJ_UNIVERSIDADE.Models
{
    public class Candidatura
    {
        //PESSOA
        public string NomeCompleto { get; set; } = string.Empty;
        public int NacionalidadeID { get; set; }
        public int SexoID { get; set; }
        public int EstadoCivilID { get; set; }
        public string DataNascimento { get; set; } = string.Empty;

        //DOCUMENTO
        public int TipoDocumentoID { get; set; }
        public string NumeroDocumento { get; set; } = string.Empty;
        public string DataEmissao { get; set; } = string.Empty;
        public string DataValidade { get; set; } = string.Empty;

        //CONTACTO
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;

        //ENDEREÇO
        public int MunicipioID { get; set; }

        //CONTACTO
        public string NomePai { get; set; } = string.Empty;
        public string NomeMae { get; set; } = string.Empty;

        //ENSINO MÉDIO
        public int CursoMedioID { get; set; }
        public int AnoConclusao { get; set; }
        public int MediaFinal { get; set; }
        public int ClasseID { get; set; }
        public int InstituicaoEscolar { get; set; }

        //CANDIDATURA
        public int CampusID { get; set; }
        public int CursoID { get; set; }
        public int PeriodoID { get; set; }
        public string Observacao { get; set; } = string.Empty;
    }
}
