using System;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    internal class OrdemProducaoKeyClass : IEquatable<OrdemProducaoKeyClass>
    {
        
        internal string codItem { get; set; }
        internal int revisaoEstruturaItem { get; set; }
        internal string descItem { get; set; }
        internal string tipoDocumento { get; set; }
        internal string numeroDocumento { get; set; }
        internal string revDocumento { get; set; }
        internal string Dimensao { get; set; }
        internal bool rastrearMP { get; set; }
        internal bool imprimeOpsRelacionadas { get; set; }
        internal int? idProdutoK { get; set; }

        public OrdemProducaoKeyClass( string codItem, string descItem, string dimensao, int? idProdutoK, bool imprimeOpsRelacionadas, string numeroDocumento, bool rastrearMp, string revDocumento, int revisaoEstruturaItem, string tipoDocumento)
        {
            this.codItem = codItem;
            this.descItem = descItem;
            Dimensao = dimensao;
            this.idProdutoK = idProdutoK;
            this.imprimeOpsRelacionadas = imprimeOpsRelacionadas;
            this.numeroDocumento = numeroDocumento;
            rastrearMP = rastrearMp;
            this.revDocumento = revDocumento;
            this.revisaoEstruturaItem = revisaoEstruturaItem;
            this.tipoDocumento = tipoDocumento;
        }

        #region IEquatable<OrdemProducaoKeyClass> Members

        public bool Equals(OrdemProducaoKeyClass other)
        {
            int idProdutoKTemp = -1;
            if (idProdutoK.HasValue)
            {
                idProdutoKTemp = idProdutoK.Value;
            }

            //bool aa = this.codItem.Equals(other.codItem) && this.descItem.Equals(other.descItem) && this.tipoDocumento.Equals(other.tipoDocumento) &&
            //       this.numeroDocumento.Equals(other.numeroDocumento) && this.revDocumento.Equals(other.revDocumento) && this.Cliente.Equals(other.Cliente) &&
            //       this.Dimensao.Equals(other.Dimensao) && this.revisaoEstruturaItem.Equals(other.revisaoEstruturaItem) &&
            //       this.rastrearMP.Equals(other.rastrearMP) && this.imprimeOpsRelacionadas.Equals(other.imprimeOpsRelacionadas) &&
            //       idProdutoKTemp.Equals(other.idProdutoK ?? -1);



            return this.codItem.Equals(other.codItem) && this.descItem.Equals(other.descItem) && this.tipoDocumento.Equals(other.tipoDocumento) &&
                   this.numeroDocumento.Equals(other.numeroDocumento) && this.revDocumento.Equals(other.revDocumento) && 
                   this.Dimensao.Equals(other.Dimensao) && this.revisaoEstruturaItem.Equals(other.revisaoEstruturaItem) &&
                   this.rastrearMP.Equals(other.rastrearMP) && this.imprimeOpsRelacionadas.Equals(other.imprimeOpsRelacionadas) &&
                   idProdutoKTemp.Equals(other.idProdutoK??-1);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is OrdemProducaoKeyClass))
                throw new InvalidCastException("The 'obj' argument is not a Person object.");
            else
                return Equals(obj as OrdemProducaoKeyClass);

        }

        public override int GetHashCode()
        {
            int idProdutoKTemp = 1;
            if (idProdutoK.HasValue)
            {
                idProdutoKTemp = idProdutoK.GetHashCode();
            }

            //int ttt = this.codItem.GetHashCode() * this.descItem.GetHashCode() * this.tipoDocumento.GetHashCode() * this.numeroDocumento.GetHashCode() *
            //       this.revDocumento.GetHashCode() * this.Cliente.GetHashCode() * this.Dimensao.GetHashCode() * this.revisaoEstruturaItem.GetHashCode() *
            //       (this.rastrearMP.GetHashCode() == 0 ? 2 : 1) * (this.imprimeOpsRelacionadas.GetHashCode() == 0 ? 2 : 1) * idProdutoKTemp;

            return this.codItem.GetHashCode()*this.descItem.GetHashCode()*this.tipoDocumento.GetHashCode()*this.numeroDocumento.GetHashCode()*
                   this.revDocumento.GetHashCode()*this.Dimensao.GetHashCode()*this.revisaoEstruturaItem.GetHashCode()*
                   (this.rastrearMP.GetHashCode() == 0 ? 2 : 1) * (this.imprimeOpsRelacionadas.GetHashCode() == 0 ? 2 : 1) * idProdutoKTemp;
        }

        public static bool operator ==(OrdemProducaoKeyClass person1, OrdemProducaoKeyClass person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(OrdemProducaoKeyClass person1, OrdemProducaoKeyClass person2)
        {
            return (!person1.Equals(person2));
        }

        #endregion
    }
}