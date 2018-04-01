using System.ComponentModel;

namespace TesteMeta.Domain
{
    public enum TipoServico
    {
        [Description("Conserto eletrônico")] ConsertoEletronico = 0,
        [Description("Serviços gerais")] ServicosGerais = 1,
        [Description("Manutenção hidráulica")] ManutencaoHidraulica = 2,
        [Description("Instalação elétrica")] InstalacaoEletrica = 3,
        [Description("Jardinagem")] Jardinagem = 4
    }
}