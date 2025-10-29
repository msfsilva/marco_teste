using System;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class ContaReceberClass : ContaReceberBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do ContaReceberClass";
        protected new const string ErroDelete = "Erro ao excluir o ContaReceberClass  ";
        protected new const string ErroSave = "Erro ao salvar o ContaReceberClass.";
        protected new const string ErroHistoricoObrigatorio = "O campo Historico é obrigatório";
        protected new const string ErroHistoricoComprimento = "O campo Historico deve ter no máximo 255 caracteres";
        protected new const string ErroCentroCustoLucroObrigatorio = "O campo CentroCustoLucro é obrigatório";
        protected new const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do ContaReceberClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade ContaReceberClass está sendo utilizada.";

        #endregion



        public ContaReceberClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return Historico;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        protected override void CalcularCamposDepoisValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {

            if (ID == -1)
            {
                LancamentoClass lancamento = CollectionLancamentoClassContaReceber.FirstOrDefault(a => a.Tipo == "CONTA");

                if (lancamento == null)
                {
                    CollectionLancamentoClassContaReceber.Add(new LancamentoClass(LoginClass.UsuarioLogado.loggedUser, command.Connection)
                    {
                        Data = DataVencimento,
                        ContaReceber = this,
                        Valor = Valor,
                        Tipo = "CONTA",
                        Efetivacao = "PREVISTO",
                        Natureza = "CREDITO",
                        CentroCustoLucro = CentroCustoLucro
                    });
                }
                else
                {
                    throw new Exception("Situação não prevista ao criar o lançamento da conta, entre em contato com o suporte IWT. Detalhes: Lançamento da Conta a Receber já existe");
                }
            }
        }
    }
}
