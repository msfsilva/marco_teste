using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    public class EstoqueEstruturaPrincipal : SubEstoque
    {

        EstoqueClass Estoque
        {
            get { return (EstoqueClass) this.EntidadeBase; }

        }

        public EstoqueEstruturaPrincipal(EstoqueClass estoque)
            : base(estoque,estoque.Identificacao,estoque.Descricao, estoque.Ativo, null)
        {

        }

        public override string ToString()
        {
            return "Estoque: " + this.Estoque.Identificacao;
        }

        public override void LoadSubNiveis()
        {
            try
            {
                foreach (EstoqueCorredorClass corredor in this.Estoque.CollectionEstoqueCorredorClassEstoque)
                {
                    SubEstoque node = this.AddSubNivel(corredor);
                    //node.LoadSubNiveis();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da estrutura do estoque.\r\n" + e.Message);
            }
        }

        public override SubEstoque AddSubNivel(string identificacao, string descricao, bool ativo)
        {
            EstoqueCorredorClass corredor = this.Estoque.AdicionarCorredor(identificacao, descricao, ativo);
            return AddSubNivel(corredor);
        }

        public override SubEstoque AddSubNivel(AbstractEntity entidadeBase)
        {
            SubEstoque tmp = new EstoqueEstruturaCorredor((EstoqueCorredorClass) entidadeBase, this);

            this.Nodes.Add(tmp);
            this.SubNiveis.Add(tmp);

            return tmp;
        }

        public override void SetAtivo(bool ativo)
        {

            this.Estoque.Ativo = ativo;

            foreach (SubEstoque item in SubNiveis)
            {
                item.SetAtivo(ativo);
            }
        }

        public override bool GetAtivo()
        {
            return this.Estoque.Ativo;
        }

        public override void ExcluirSubNivel(SubEstoque noExcluir)
        {
            EstoqueCorredorClass corredor = (EstoqueCorredorClass) noExcluir.EntidadeBase;
            this.Estoque.ExcluirCorredor(corredor);

            this.Nodes.Remove(noExcluir);
            this.SubNiveis.Remove(noExcluir);
        }

        public override void AtualizarEntidade()
        {
            Estoque.Identificacao = Identificacao;
            Estoque.Descricao = Descricao;

        }

        public override List<EstoqueGavetaReportClass> GerarEtiqueta()
        {
            throw new ExcecaoTratada("Só é possível gerar etiqueta de uma gaveta de estoque");
        }
    }
}