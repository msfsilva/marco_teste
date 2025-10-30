using System;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101
{
    public partial class TEventoInfEvento
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cOrgaoLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cOrgao.ToString().Replace("Item", "")); }
            set { this.cOrgao = (TCOrgaoIBGE)Enum.Parse(typeof(TCOrgaoIBGE), "Item" + ((int)value).ToString()); }
        }
    }

    public partial class TRetEventoInfEvento
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cOrgaoLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cOrgao.ToString().Replace("Item", "")); }
            set { this.cOrgao = (TCOrgaoIBGE)Enum.Parse(typeof(TCOrgaoIBGE), "Item" + ((int)value).ToString()); }
        }
    }
}

namespace IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101
{
    public partial class TEventoInfEvento
    {
        [System.Xml.Serialization.XmlIgnore]
        public TAmbLegado tpAmbLegado
        {
            get { return this.tpAmb == TAmb.Item1 ? TAmbLegado.Producao : TAmbLegado.Homologacao; }
            set { this.tpAmb = (value == TAmbLegado.Producao) ? TAmb.Item1 : TAmb.Item2; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public TCodUfIBGELegado cOrgaoLegado
        {
            get { return (TCodUfIBGELegado)Enum.Parse(typeof(TCodUfIBGELegado), this.cOrgao.ToString().Replace("Item", "")); }
            set { this.cOrgao = (TCOrgaoIBGE)Enum.Parse(typeof(TCOrgaoIBGE), "Item" + ((int)value).ToString()); }
        }
    }
}
