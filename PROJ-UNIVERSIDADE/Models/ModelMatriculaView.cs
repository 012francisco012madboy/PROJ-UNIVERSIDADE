namespace PROJ_UNIVERSIDADE.Models
{
    public class ModelMatriculaView
    {
        public ConsultaComIdentificacao Consulta { get; set; } = new ConsultaComIdentificacao();
        public PagamentoMatricula Pagamento { get; set; } = new PagamentoMatricula();
    }
}
