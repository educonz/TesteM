namespace Domain.Resultados
{
    public class ResultadoValidacao
    {
        public ResultadoValidacao()
        {

        }

        public ResultadoValidacao(string mensagem)
        {
            Sucesso = false;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public static ResultadoValidacao CriarErro(string mensagem) => new ResultadoValidacao(mensagem);
        public static ResultadoValidacao CriarSucesso(string mensagem) => new ResultadoValidacao { Mensagem = mensagem, Sucesso = true };
    }
}
