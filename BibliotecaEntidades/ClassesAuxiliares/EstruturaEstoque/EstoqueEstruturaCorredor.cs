using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    public class EstoqueEstruturaCorredor : SubEstoque
    {
        EstoqueCorredorClass Corredor
        {
            get { return (EstoqueCorredorClass)this.EntidadeBase; }

        }

        public EstoqueEstruturaCorredor(EstoqueCorredorClass corredor, SubEstoque pai)
            : base(corredor, corredor.Identificacao, corredor.Descricao, corredor.Ativo, pai)
        {

        }

        public override string ToString()
        {
            return "Corredor: " + this.Identificacao;
        }

        public override void LoadSubNiveis()
        {
            try
            {
                foreach (EstoquePrateleiraClass prateleira in this.Corredor.CollectionEstoquePrateleiraClassEstoqueCorredor)
                {
                    SubEstoque node = this.AddSubNivel(prateleira);
                   // node.LoadSubNiveis();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da estrutura Corredor.\r\n" + e.Message);
            }
        }

        public override SubEstoque AddSubNivel(string identificacao, string descricao, bool ativo)
        {
            EstoquePrateleiraClass prateleira = this.Corredor.AdicionarPrateleira(identificacao, descricao, ativo);
            return AddSubNivel(prateleira);
        }

        public override SubEstoque AddSubNivel(AbstractEntity entidadeBase)
        {
            SubEstoque tmp = new EstoqueEstruturaPrateleira((EstoquePrateleiraClass)entidadeBase, this);

            this.Nodes.Add(tmp);
            this.SubNiveis.Add(tmp);

            return tmp;
        }

        public override void SetAtivo(bool ativo)
        {

            this.Corredor.Ativo = ativo;


            foreach (SubEstoque item in SubNiveis)
            {
                item.SetAtivo(ativo);
            }
        }

        public override bool GetAtivo()
        {
            return this.Corredor.Ativo;
        }

        public override void ExcluirSubNivel(SubEstoque noExcluir)
        {
            EstoquePrateleiraClass prateleira = (EstoquePrateleiraClass)noExcluir.EntidadeBase;
            this.Corredor.ExcluirPrateleira(prateleira);

            this.Nodes.Remove(noExcluir);
            this.SubNiveis.Remove(noExcluir);
        }

        public override void AtualizarEntidade()
        {
            Corredor.Identificacao = Identificacao;
            Corredor.Descricao = Descricao;

        }

        public override List<EstoqueGavetaReportClass> GerarEtiqueta()
        {
            throw new ExcecaoTratada("Só é possível gerar etiqueta de uma gaveta de estoque");
        }
    }
}