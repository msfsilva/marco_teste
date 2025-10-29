using System.Collections.Generic;

namespace BibliotecaEntidades.Relatorios
{
    public class PlanoCorteLocalMaterialReportClass
    {
        public long MaterialID { get; internal set; }
        public long NumeroPc { get; internal set; }

        public string LocalEstoque { get; internal set; }
        public double QtdEstoque { get; internal set; }
        public string Unidade { get; internal set; }

        protected bool Equals(PlanoCorteLocalMaterialReportClass other)
        {
            return MaterialID == other.MaterialID && NumeroPc == other.NumeroPc && string.Equals(LocalEstoque, other.LocalEstoque) && QtdEstoque.Equals(other.QtdEstoque) && string.Equals(Unidade, other.Unidade);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlanoCorteLocalMaterialReportClass) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MaterialID.GetHashCode();
                hashCode = (hashCode * 397) ^ NumeroPc.GetHashCode();
                hashCode = (hashCode * 397) ^ (LocalEstoque != null ? LocalEstoque.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ QtdEstoque.GetHashCode();
                hashCode = (hashCode * 397) ^ (Unidade != null ? Unidade.GetHashCode() : 0);
                return hashCode;
            }
        }

        private sealed class PlanoCorteLocalMaterialReportClassEqualityComparer : IEqualityComparer<PlanoCorteLocalMaterialReportClass>
        {
            public bool Equals(PlanoCorteLocalMaterialReportClass x, PlanoCorteLocalMaterialReportClass y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.MaterialID == y.MaterialID && x.NumeroPc == y.NumeroPc && string.Equals(x.LocalEstoque, y.LocalEstoque) && x.QtdEstoque.Equals(y.QtdEstoque) && string.Equals(x.Unidade, y.Unidade);
            }

            public int GetHashCode(PlanoCorteLocalMaterialReportClass obj)
            {
                unchecked
                {
                    var hashCode = obj.MaterialID.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.NumeroPc.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.LocalEstoque != null ? obj.LocalEstoque.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.QtdEstoque.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Unidade != null ? obj.Unidade.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<PlanoCorteLocalMaterialReportClass> PlanoCorteLocalMaterialReportClassComparer { get; } = new PlanoCorteLocalMaterialReportClassEqualityComparer();
    }
}