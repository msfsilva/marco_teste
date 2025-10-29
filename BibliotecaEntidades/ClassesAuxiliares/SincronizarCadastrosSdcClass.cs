using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public class SincronizarCadastrosSdcClass
    {
        private IWTPostgreNpgsqlConnection _conn;
        private AcsUsuarioClass _usuario;

        private bool _suprimirErrosTela;
        private readonly string _arquivoLog;

        public SincronizarCadastrosSdcClass(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, bool suprimirErrosTela = false, string arquivoLog = null )
        {
            _conn = conn;
            _usuario = usuario;
            _suprimirErrosTela = suprimirErrosTela;
            _arquivoLog = arquivoLog;
        }

        public void Start()
        {
            try
            {
                StringBuilder erros = new StringBuilder();
                List<FornecedorClass> fornecedores = new FornecedorClass(_usuario, _conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (FornecedorClass)a).ToList();
                foreach (FornecedorClass fornecedor in fornecedores)
                {
                    try
                    {
                        fornecedor.SincronizarSDC(_conn);
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }
                }

                List<UnidadeMedidaClass> unidadesMedida = new UnidadeMedidaClass(_usuario, _conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (UnidadeMedidaClass)a).ToList();
                foreach (UnidadeMedidaClass unidadeMedida in unidadesMedida)
                {
                    try
                    {
                        unidadeMedida.SincronizarSDC(_conn);
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }
                }

                List<ProdutoClass> produtos = new ProdutoClass(_usuario, _conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (ProdutoClass)a).ToList();

                foreach (ProdutoClass produto in produtos)
                {
                    try
                    {
                        produto.SincronizarSDC(_conn);
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }

                }

                List<MaterialClass> materiais = new MaterialClass(_usuario, _conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (MaterialClass)a).ToList();
                foreach (MaterialClass material in materiais)
                {
                    try
                    {
                        material.SincronizarSDC(_conn);
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }
                }

                List<EpiClass> epis = new EpiClass(_usuario, _conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (EpiClass)a).ToList();
                foreach (EpiClass epi in epis)
                {
                    try
                    {
                        epi.SincronizarSDC(_conn);
                    }
                    catch (Exception e)
                    {
                        erros.Append(e.Message);
                    }

                }


                if (erros.Length > 0)
                {
                    if (!_suprimirErrosTela)
                    {
                        ScrollableMessageBox sc = new ScrollableMessageBox(null, erros.ToString(), "Erros na operação de sincronização", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sc.ShowDialog();
                    }

                    if (!string.IsNullOrWhiteSpace(_arquivoLog))
                    {
                        File.WriteAllText(_arquivoLog, erros.ToString());
                    }
                }


            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro inesperado ao sincronizar os cadastros: " + e.Message);
            }
            
        }
    }
}
