namespace PROJ_UNIVERSIDADE.Models
{
    public class ModelInscricaoView
    {
        public ConsultaComIdentificacao Consulta { get; set; } = new ConsultaComIdentificacao();
        public PagamentoInscricao Pagamento { get; set; } = new PagamentoInscricao();
    }
}
