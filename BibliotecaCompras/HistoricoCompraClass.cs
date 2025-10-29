#region Referencias

using System;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;

#endregion

namespace BibliotecaCompras
{
    abstract public class HistoricoCompraClass
    {
        public int? ID { get; protected set; }
        public FornecedorClass Fornecedor { get; protected set; }
        public int? idMarca { get; protected set; }
        public string numeroNF { get; protected set; }
        public DateTime dataRecebimento { get; protected set; }
        public DateTime dataOC { get; protected set; }
        public double precoUnitario { get; protected set; }
        public double icmsIncluso { get; protected set; }
        public double ipiNaoIncluso { get; protected set; }
        public int idLinhaNF { get; protected set; }
        public LoteClass Lote { get; protected set; }

        protected AcsUsuarioClass Usuario;
        protected IWTPostgreNpgsqlConnection conn;

        public HistoricoCompraClass(FornecedorClass fornecedor, int? idMarca, string numeroNF, DateTime dataRecebimento, DateTime dataOC,
            double precoUnitario, double icmsIncluso, double ipiNaoIncluso, int idLinhaNF,LoteClass Lote,
            AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.Fornecedor = fornecedor;
            this.idMarca = idMarca;
            this.numeroNF = numeroNF;
            this.dataRecebimento = dataRecebimento;
            this.dataOC = dataOC;
            this.precoUnitario = precoUnitario;
            this.icmsIncluso = icmsIncluso;
            this.ipiNaoIncluso = ipiNaoIncluso;
            this.idLinhaNF = idLinhaNF;
            this.Lote = Lote;

            this.Usuario = usuario;
            this.conn = conn;
        }

        public HistoricoCompraClass(int ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.ID = ID;
            this.Usuario = usuario;
            this.conn = conn;

            this.Load();
        }

        protected abstract void Load();

        internal abstract void Salvar(ref IWTPostgreNpgsqlCommand command);

        public void Salvar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();

                command.Transaction = this.conn.BeginTransaction();
                this.Salvar(ref command);
                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao salvar o histórico de compras.\r\n" + e.Message, e);
            }
        }



    }

    
}
