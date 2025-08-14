namespace PROJ_UNIVERSIDADE.Models
{
    public class Candidatura
    {
        //PESSOA
        public string NomeCompleto { get; set; } = string.Empty;
        public int NacionalidadeID { get; set; } = 0;
        public int SexoID { get; set; } = 0;
        public int EstadoCivilID { get; set; } = 0;
        public DateTime DataNascimento { get; set; }

        //DOCUMENTO
        public int TipoDocumentoID { get; set; } = 0;
        public string NumeroDocumento { get; set; } = string.Empty;
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get; set; }

        //CONTACTO
        public int Telefone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;

        //ENDEREÇO
        public int ProvinciaID { get; set; } = 0;
        public int MunicipioID { get; set; } = 0;

        //CONTACTO
        public string NomePai { get; set; } = string.Empty;
        public string NomeMae { get; set; } = string.Empty;

        //ENSINO MÉDIO
        public int AreaFormacaoID { get; set; } = 0; 
        public int CursoMedioID { get; set; } = 0; 
        public int AnoConclusao { get; set; } = 0;
        public int MediaFinal { get; set; } = 0;
        public int ClasseID { get; set; } = 0;
        public string InstituicaoEscolar { get; set; } = string.Empty;

        //CANDIDATURA
        public int CampusID { get; set; } = 0;
        public int FaculdadeID { get; set; } = 0;
        public int CursoID { get; set; } = 0;
        public int PeriodoID { get; set; } = 0;
        public string Observacao { get; set; } = "Nenhuma";
    }
}
