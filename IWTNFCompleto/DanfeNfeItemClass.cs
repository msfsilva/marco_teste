using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IWTNFCompleto
{
    public class DanfeNFeItemClass
    {
        public string DfeChaveAcesso { get; private set; }
        public string ItemCodigo { get; private set; }
        public string ItemDescricao { get; private set; }
        public string ItemDescricaoAdicional { get; private set; }
        public string ItemNCM { get; private set; }
        public string ItemCST { get; private set; }
        public string ItemCFOP { get; private set; }
        public string ItemUnidade { get; private set; }
        public double ItemQuantidade { get; private set; }
        public double ItemValorUnitario { get; private set; }
        public string ItemDesconto { get; private set; } 
        public double ItemValorTotal { get; private set; }
        public string ItemBcIcms { get; private set; }
        public string ItemBcIcmsSt { get; private set; }
        public string ItemValorIcms { get; private set; }
        public string ItemValorIcmsSt { get; private set; }
        public string ItemValorIpi { get; private set; }
        public string ItemAliquotaIcms { get; private set; }
        public string ItemAliquotaIpi { get; private set; }

        public DanfeNFeItemClass(string dfeChaveAcesso, string itemCodigo, string itemDescricao, string itemDescricaoAdicional, string itemNcm, string itemCst, string itemCfop, string itemUnidade, double itemQuantidade, double itemValorUnitario, string itemDesconto, double itemValorTotal, string itemBcIcms, string itemBcIcmsSt, string itemValorIcms, string itemValorIcmsSt, string itemValorIpi, string itemAliquotaIcms, string itemAliquotaIpi)
        {
            DfeChaveAcesso = dfeChaveAcesso;
            ItemCodigo = itemCodigo;
            ItemDescricao = itemDescricao;
            ItemDescricaoAdicional = itemDescricaoAdicional;
            ItemNCM = itemNcm;
            ItemCST = itemCst;
            ItemCFOP = itemCfop;
            ItemUnidade = itemUnidade;
            ItemQuantidade = itemQuantidade;
            ItemValorUnitario = itemValorUnitario;
            ItemDesconto = itemDesconto;
            ItemValorTotal = itemValorTotal;
            ItemBcIcms = itemBcIcms;
            ItemBcIcmsSt = itemBcIcmsSt;
            ItemValorIcms = itemValorIcms;
            ItemValorIcmsSt = itemValorIcmsSt;
            ItemValorIpi = itemValorIpi;
            ItemAliquotaIcms = itemAliquotaIcms;
            ItemAliquotaIpi = itemAliquotaIpi;
        }
    }
}
