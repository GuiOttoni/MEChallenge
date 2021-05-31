using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Pedido.Domain.Enum
{
    public enum StatusEnum
    {
        CODIGO_PEDIDO_INVALIDO,
        REPROVADO,
        APROVADO,
        APROVADO_VALOR_A_MENOR,
        APROVADO_QTD_A_MENOR,
        APROVADO_VALOR_A_MAIOR,
        APROVADO_QTD_A_MAIOR

    }
}
