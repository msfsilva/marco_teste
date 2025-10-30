using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using IWTNF.Entidades.Base;

namespace IWTNF.Entidades.Entidades
{
    [Serializable()]
    public class NfItemClass : NfItemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do NfItemClass";
        protected new const string ErroDelete = "Erro ao excluir o NfItemClass  ";
        protected new const string ErroSave = "Erro ao salvar o NfItemClass.";
        protected new const string ErroCollectionNfItemTributoCofinsClassNfItem = "Erro ao carregar a coleção de NfItemTributoCofinsClass.";
        protected new const string ErroCollectionNfItemTributoIpiClassNfItem = "Erro ao carregar a coleção de NfItemTributoIpiClass.";
        protected new const string ErroCollectionNfItemTributoIssClassNfItem = "Erro ao carregar a coleção de NfItemTributoIssClass.";
        protected new const string ErroCollectionNfProdutoCofinsClassNfItem = "Erro ao carregar a coleção de NfProdutoCofinsClass.";
        protected new const string ErroCollectionNfProdutoDeclaracaoImportacaoClassNfItem = "Erro ao carregar a coleção de NfProdutoDeclaracaoImportacaoClass.";
        protected new const string ErroCollectionNfItemTributoIimpClassNfItem = "Erro ao carregar a coleção de NfItemTributoIimpClass.";
        protected new const string ErroCollectionNfItemTributoIcmsClassNfItem = "Erro ao carregar a coleção de NfItemTributoIcmsClass.";
        protected new const string ErroCollectionNfProdutoIpiClassNfItem = "Erro ao carregar a coleção de NfProdutoIpiClass.";
        protected new const string ErroCollectionNfItemTributoClassNfItem = "Erro ao carregar a coleção de NfItemTributoClass.";
        protected new const string ErroCollectionNfItemTributoPisClassNfItem = "Erro ao carregar a coleção de NfItemTributoPisClass.";
        protected new const string ErroCollectionNfProdutoIssClassNfItem = "Erro ao carregar a coleção de NfProdutoIssClass.";
        protected new const string ErroCollectionNfProdutoClassNfItem = "Erro ao carregar a coleção de NfProdutoClass.";
        protected new const string ErroCollectionNfProdutoPisClassNfItem = "Erro ao carregar a coleção de NfProdutoPisClass.";
        protected new const string ErroCollectionNfProdutoIcmsClassNfItem = "Erro ao carregar a coleção de NfProdutoIcmsClass.";
        protected new const string ErroCollectionNfProdutoIimpClassNfItem = "Erro ao carregar a coleção de NfProdutoIimpClass.";
        protected new const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do NfItemClass.";
        protected new const string MensagemUtilizadoCollectionNfItemTributoCofinsClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoCofinsClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIpiClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIpiClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIssClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIssClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoCofinsClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoCofinsClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoDeclaracaoImportacaoClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoDeclaracaoImportacaoClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIimpClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIimpClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoIcmsClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoIcmsClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIpiClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIpiClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoClass:";
        protected new const string MensagemUtilizadoCollectionNfItemTributoPisClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfItemTributoPisClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIssClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIssClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoPisClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoPisClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIcmsClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIcmsClass:";
        protected new const string MensagemUtilizadoCollectionNfProdutoIimpClassNfItem = "A entidade NfItemClass está sendo utilizada nos seguintes NfProdutoIimpClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade NfItemClass está sendo utilizada.";

        #endregion
        public bool ItemDevolucao { get; set; } = false;

        public NfItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

        

        protected override void InitClass()
        {
            //SalvarVetoresObjetosHabilitado = false;
        }
        public override string ToString()
        {
            return this.NumeroItem.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            //foreach (NfItemTributoClass item in CollectionNfItemTributoClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoClass item in CollectionNfProdutoClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoCofinsClass item in CollectionNfItemTributoCofinsClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoIcmsClass item in CollectionNfItemTributoIcmsClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoIimpClass item in CollectionNfItemTributoIimpClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoIpiClass item in CollectionNfItemTributoIpiClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoIssClass item in CollectionNfItemTributoIssClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfItemTributoPisClass item in CollectionNfItemTributoPisClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoCofinsClass item in CollectionNfProdutoCofinsClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoIcmsClass item in CollectionNfProdutoIcmsClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoIimpClass item in CollectionNfProdutoIimpClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoIpiClass item in CollectionNfProdutoIpiClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoIssClass item in CollectionNfProdutoIssClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoPisClass item in CollectionNfProdutoPisClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            //foreach (NfProdutoDeclaracaoImportacaoClass item in CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Where(item => item != null))
            //{
            //    item.Save(ref command);
            //}

            return;
        }

        #region Propriedades Manuais
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfItemTributoClass NfItemTributo
        {
            get { return this.CollectionNfItemTributoClassNfItem != null && this.CollectionNfItemTributoClassNfItem.Count > 0 ? this.CollectionNfItemTributoClassNfItem[0] : null; }
            set
            {
                if (this.CollectionNfItemTributoClassNfItem == null) CollectionNfItemTributoClassNfItem = new BindingList<NfItemTributoClass>();
                if (CollectionNfItemTributoClassNfItem.Count == 0)
                {
                    if (value != null)
                    CollectionNfItemTributoClassNfItem.Add(value);
                }
                else
                {
                    CollectionNfItemTributoClassNfItem[0] = value;
                }
            }
        }

         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
        public NfProdutoClass NfProduto
        {
            get { return this.CollectionNfProdutoClassNfItem != null && this.CollectionNfProdutoClassNfItem.Count > 0 ? this.CollectionNfProdutoClassNfItem[0] : null; }
            set
            {
                if (this.CollectionNfProdutoClassNfItem == null) CollectionNfProdutoClassNfItem = new BindingList<NfProdutoClass>();
                if (CollectionNfProdutoClassNfItem.Count == 0)
                {
                    if (value != null)
                    CollectionNfProdutoClassNfItem.Add(value);
                }
                else
                {
                    CollectionNfProdutoClassNfItem[0] = value;
                }
            }
        }

        public void ExcluirDeclaracaoImportacao(NfProdutoDeclaracaoImportacaoClass declaracaoImportacao)
        {
            try
            {
                if (!this.CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Contains(declaracaoImportacao))
                {
                    throw new ExcecaoTratada("A declaração de importação " + declaracaoImportacao.NumeroDocImportacao + " não foi encontrada no produto");
                }

                this.CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Remove(declaracaoImportacao);
                this.adicionarObjetoDeletar(declaracaoImportacao);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao excluir a declaração de importação.\r\n" + e.Message, e);
            }
        }
        #endregion

        public void LimparId()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
                this.ID = -1;
                if (_valueCollectionNfItemTributoClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoClassNfItem.Count; i++)
                    {
                        NfItemTributoClass item = CollectionNfItemTributoClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoCofinsClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoCofinsClassNfItem.Count; i++)
                    {
                        NfItemTributoCofinsClass item = CollectionNfItemTributoCofinsClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoCofinsClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoIcmsClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoIcmsClassNfItem.Count; i++)
                    {
                        NfItemTributoIcmsClass item = CollectionNfItemTributoIcmsClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoIcmsClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoIimpClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoIimpClassNfItem.Count; i++)
                    {
                        NfItemTributoIimpClass item = CollectionNfItemTributoIimpClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoIimpClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoIpiClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoIpiClassNfItem.Count; i++)
                    {
                        NfItemTributoIpiClass item = CollectionNfItemTributoIpiClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoIpiClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoIssClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoIssClassNfItem.Count; i++)
                    {
                        NfItemTributoIssClass item = CollectionNfItemTributoIssClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoIssClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfItemTributoPisClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfItemTributoPisClassNfItem.Count; i++)
                    {
                        NfItemTributoPisClass item = CollectionNfItemTributoPisClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfItemTributoPisClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoClassNfItem.Count; i++)
                    {
                        NfProdutoClass item = CollectionNfProdutoClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoCofinsClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoCofinsClassNfItem.Count; i++)
                    {
                        NfProdutoCofinsClass item = CollectionNfProdutoCofinsClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoCofinsClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoDeclaracaoImportacaoClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Count; i++)
                    {
                        NfProdutoDeclaracaoImportacaoClass item = CollectionNfProdutoDeclaracaoImportacaoClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoDeclaracaoImportacaoClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoIcmsClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoIcmsClassNfItem.Count; i++)
                    {
                        NfProdutoIcmsClass item = CollectionNfProdutoIcmsClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoIcmsClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoIimpClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoIimpClassNfItem.Count; i++)
                    {
                        NfProdutoIimpClass item = CollectionNfProdutoIimpClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoIimpClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoIpiClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoIpiClassNfItem.Count; i++)
                    {
                        NfProdutoIpiClass item = CollectionNfProdutoIpiClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoIpiClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoIssClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoIssClassNfItem.Count; i++)
                    {
                        NfProdutoIssClass item = CollectionNfProdutoIssClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoIssClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
                if (_valueCollectionNfProdutoPisClassNfItemLoaded)
                {
                    for (var i = 0; i < CollectionNfProdutoPisClassNfItem.Count; i++)
                    {
                        NfProdutoPisClass item = CollectionNfProdutoPisClassNfItem[i];
                        if (item == null)
                        {
                            CollectionNfProdutoPisClassNfItem.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            item.LimparId();
                        }
                    }
                }
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado;
                DisableLoadCollection = sitAnteriorDisableLoadCollection;
            }
        }

    }
}
