using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    internal class EstoqueDisponivelClassKey : IEquatable<EstoqueDisponivelClassKey>, IComparable<EstoqueDisponivelClassKey>
    {
        public ProdutoClass Produto { get; private set; }
        public ProdutoKClass ProdutoK { get; private set; }
        public int RevisaoProduto { get; private set; }
        public string Dimensao { get; private set; }
        

        public EstoqueDisponivelClassKey(ProdutoClass produto, int revisaoProduto, string dimensao, ProdutoKClass produtoK)
        {
            Produto = produto;
            RevisaoProduto = revisaoProduto;
            Dimensao = dimensao;
            ProdutoK = produtoK;
        }

        public bool Equals(EstoqueDisponivelClassKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Produto, other.Produto) && Equals(ProdutoK, other.ProdutoK) && RevisaoProduto == other.RevisaoProduto && string.Equals(Dimensao, other.Dimensao);
        }

        public int CompareTo(EstoqueDisponivelClassKey other)
        {
            if (this.Produto.ID == other.Produto.ID)
            {
                return this.RevisaoProduto.CompareTo(other.RevisaoProduto);
            }
            else
            {
                if (this.Produto.ID == other.Produto.ID)
                {
                    if (this.Dimensao.CompareTo(other.Dimensao) == 0)
                    {
                        if (this.ProdutoK != null)
                        {
                            if (other.ProdutoK != null)
                            {
                                return this.ProdutoK.ID.CompareTo(other.ProdutoK.ID);
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            if (other.ProdutoK == null)
                            {
                                return 0;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                    else
                    {
                        return this.Dimensao.CompareTo(other.Dimensao);
                    }
                }
                else
                {
                    return this.Produto.ID.CompareTo(other.Produto.ID);
                }
            }

        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EstoqueDisponivelClassKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Produto != null ? Produto.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ProdutoK != null ? ProdutoK.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ RevisaoProduto;
                hashCode = (hashCode*397) ^ (Dimensao != null ? Dimensao.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(EstoqueDisponivelClassKey left, EstoqueDisponivelClassKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EstoqueDisponivelClassKey left, EstoqueDisponivelClassKey right)
        {
            return !Equals(left, right);
        }


    }
}