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
    public class EstoqueEstruturaPrateleira : SubEstoque
    {
        EstoquePrateleiraClass Prateleira
        {
            get { return (EstoquePrateleiraClass)this.EntidadeBase; }

        }

        public EstoqueEstruturaPrateleira(EstoquePrateleiraClass prateleira, SubEstoque pai)
            : base(prateleira, prateleira.Identificacao, prateleira.Descricao, prateleira.Ativo, pai)
        {

        }

        public override string ToString()
        {
            return "Prateleira: " + this.Identificacao;
        }


        public override void LoadSubNiveis()
        {
            try
            {
                foreach (EstoqueGavetaClass gaveta in this.Prateleira.CollectionEstoqueGavetaClassEstoquePrateleira)
                {
                    SubEstoque node = this.AddSubNivel(gaveta);
                   // node.LoadSubNiveis();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da estrutura Prateleira.\r\n" + e.Message);
            }
        }

        public override SubEstoque AddSubNivel(string identificacao, string descricao, bool ativo)
        {
            EstoqueGavetaClass gaveta = this.Prateleira.AdicionarGaveta(identificacao, descricao, ativo);
            return AddSubNivel(gaveta);
        }

        public override SubEstoque AddSubNivel(AbstractEntity entidadeBase)
        {
            SubEstoque tmp = new EstoqueEstruturaGaveta((EstoqueGavetaClass)entidadeBase, this);

            this.Nodes.Add(tmp);
            this.SubNiveis.Add(tmp);

            return tmp;
        }

        public override void SetAtivo(bool ativo)
        {

            this.Prateleira.Ativo = ativo;


            foreach (SubEstoque item in SubNiveis)
            {
                item.SetAtivo(ativo);
            }
        }

        public override bool GetAtivo()
        {
            return this.Prateleira.Ativo;
        }

        public override void ExcluirSubNivel(SubEstoque noExcluir)
        {
            EstoqueGavetaClass gaveta = (EstoqueGavetaClass)noExcluir.EntidadeBase;
            this.Prateleira.ExcluirGaveta(gaveta);

            this.Nodes.Remove(noExcluir);
            this.SubNiveis.Remove(noExcluir);
        }

        public override void AtualizarEntidade()
        {
            Prateleira.Identificacao = Identificacao;
            Prateleira.Descricao = Descricao;

        }

        public override List<EstoqueGavetaReportClass> GerarEtiqueta()
        {
            throw new ExcecaoTratada("Só é possível gerar etiqueta de uma gaveta de estoque");
        }
    }
}