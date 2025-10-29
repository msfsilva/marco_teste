using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades
{
    public class PalletClass : PalletBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PalletClass";
        protected new const string ErroDelete = "Erro ao excluir o PalletClass  ";
        protected new const string ErroSave = "Erro ao salvar o PalletClass.";
        protected new const string ErroValidate = "Erro ao validar os dados do PalletClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PalletClass está sendo utilizada.";

        #endregion


        public PalletClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        protected override void InitClass()
        {
            this.ControleRevisaoHabilitado = false;
        }

        public override string ToString()
        {
            return this.Numero.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaCompleta":
                    whereClause += " AND (CAST(pal_numero AS TEXT) LIKE :BuscaCompleta) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("BuscaCompleta", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue + "%"));
                    return true;
                default:
                    return false;
            }
        }

        public static PalletClass GetPalletMaiorNumero(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario)
        {
            PalletClass maiorPallet = (PalletClass) new PalletClass(usuario, conn).Search(new List<SearchParameterClass>()
            {
                new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Desc, TipoOrdenacao.Automatica)
            }, limit: 1).FirstOrDefault();

            return maiorPallet;
        }

        public static void CriarMultiplosPallets(int numeroInicial, int numeroFinal, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.Transaction = conn.BeginTransaction();
            try
            {
                for (int i = numeroInicial; i <= numeroFinal; i++)
                {
                    PalletClass pallet = new PalletClass(usuario, conn)
                    {
                        Numero = i,
                        Bloqueado = false,
                        Conferido = false,
                        Especial = false,
                        Fechado = false,
                        IdUsuario = null,
                        Ocupado = false,
                        Sequencia = 0,
                    };
                    pallet.Save(ref command);
                }

                command.Transaction.Commit();
            }
            catch
            {
                command.Transaction.Rollback();
                throw;
            }

            

        }
    }


}
