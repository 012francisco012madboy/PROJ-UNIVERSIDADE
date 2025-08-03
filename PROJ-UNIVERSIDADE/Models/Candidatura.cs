namespace PROJ_UNIVERSIDADE.Models
{
    public class Candidatura
    {
        //PESSOA
        public string NomeCompleto { get; set; } = string.Empty;
        public int NacionalidadeID { get; set; } = -1;
        public int SexoID { get; set; } = -1;
        public int EstadoCivilID { get; set; } = -1;
        public string DataNascimento { get; set; } = string.Empty;

        //DOCUMENTO
        public int TipoDocumentoID { get; set; } = -1;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string DataEmissao { get; set; } = string.Empty;
        public string DataValidade { get; set; } = string.Empty;

        //CONTACTO
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Morada { get; set; } = string.Empty;

        //ENDEREÇO
        public int MunicipioID { get; set; } = -1;

        //CONTACTO
        public string NomePai { get; set; } = string.Empty;
        public string NomeMae { get; set; } = string.Empty;

        //ENSINO MÉDIO
        public int CursoMedioID { get; set; } = -1; 
        public int AnoConclusao { get; set; } = -1;
        public int MediaFinal { get; set; } = -1;
        public int ClasseID { get; set; } = -1;
        public int InstituicaoEscolar { get; set; } = -1;

        //CANDIDATURA
        public int CampusID { get; set; } = -1;
        public int CursoID { get; set; } = -1;
        public int PeriodoID { get; set; } = -1;
        public string Observacao { get; set; } = string.Empty;
    }
}
