using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class NotificacaoDesvioClass : NotificacaoDesvioBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NotificacaoDesvioClass";
        protected new const string ErroDelete = "Erro ao excluir o NotificacaoDesvioClass  ";
        protected new const string ErroSave = "Erro ao salvar o NotificacaoDesvioClass.";
        protected new const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
        protected new const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
        protected new const string ErroDescricaoDefeitoObrigatorio = "O campo DescricaoDefeito é obrigatório";
        protected new const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
        protected new const string ErroTipoNotificacaoDesvioObrigatorio = "O campo TipoNotificacaoDesvio é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NotificacaoDesvioClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NotificacaoDesvioClass está sendo utilizada.";

        #endregion

        private DateTime? _dataEmissaoNfClienteTemp;


        public NotificacaoDesvioClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        protected override void InitClass()
        {
            if (this.ID==-1)
            {
                this.AcsUsuarioNotificacao = this.UsuarioAtual;
            }
        }

        public bool PossuiDataEmissaoNfCliente
        {
            get
            {
                if (this.DataEmissaoNfCliente.HasValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

         
        }

        public bool PossuiValorNfCliente
        {
            get
            {
                if (this.ValorNfCliente.HasValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        
        }

        public bool PossuiPostoTrabalho
        {
            get
            {
                if (this.PostoTrabalho == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

          
        }

        public ClienteClass Cliente
        {
            get
            {
                return this.PedidoItem?.Cliente;
            }
        }

        public ProdutoClass Produto
        {
            get { return this.PedidoItem?.Produto; }
        }


        public override string ToString()
        {
            return this.Numero;
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "Cliente":
                    orderByClause += " , c1.cli_nome_resumido " + ordenacao.ToString();
                    command.CommandText += "  LEFT OUTER JOIN public.pedido_item p1 ON (public.notificacao_desvio.id_pedido_item = p1.id_pedido_item) " +
                                           "  LEFT OUTER JOIN public.cliente c1 ON (p1.id_cliente = c1.id_cliente) ";
                    return true;

                case "Produto":
                    orderByClause += " , pr1.pro_codigo " + ordenacao.ToString();
                    command.CommandText += "  LEFT OUTER JOIN public.pedido_item p1 ON (public.notificacao_desvio.id_pedido_item = p1.id_pedido_item) " +
                                           "  LEFT OUTER JOIN public.produto pr1 ON (p1.id_produto = pr1.id_produto) ";
                    return true;
                default:
                    return false;
            } 
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
    }
}
