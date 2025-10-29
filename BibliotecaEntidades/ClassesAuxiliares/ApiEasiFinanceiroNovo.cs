using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class ApiEasiFinanceiroNovo
    {
        public static CredorDevedorClass AtualizarFornecedor(FornecedorClass fornecedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = fornecedor.CollectionCredorDevedorClassFornecedor.FirstOrDefault();
            if (cr == null)
            {
                cr = new CredorDevedorClass(usuario, command.Connection)
                {
                    Ativo = true,
                    Nome = fornecedor.RazaoSocial,
                    Cnpj = fornecedor.Cnpj,
                    TipoCredorDevedor = "FORNECEDOR",
                    Fornecedor = fornecedor,
                    Cliente = null,
                    Funcionario = null,
                    Vendedor = null,
                };

                fornecedor.CollectionCredorDevedorClassFornecedor.Add(cr);

            }
            else
            {
                cr.Nome = fornecedor.RazaoSocial;
                cr.Cnpj = fornecedor.Cnpj;
            }

            cr.Save(ref command);

            return cr;
        }

        public static void ExcluirFornecedor(FornecedorClass fornecedor, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = fornecedor.CollectionCredorDevedorClassFornecedor.FirstOrDefault();
            if (cr != null)
            {
                cr.Delete(ref command);
            }
        }

        public static CredorDevedorClass AtualizarFuncionario(FuncionarioClass funcionario, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = funcionario.CollectionCredorDevedorClassFuncionario.FirstOrDefault();
            if (cr == null)
            {
                cr = new CredorDevedorClass(usuario, command.Connection)
                {
                    Ativo = funcionario.Ativo,
                    Nome = funcionario.Nome,
                    Cnpj = funcionario.Cpf,
                    TipoCredorDevedor = "FUNCIONARIO",
                    Fornecedor = null,
                    Cliente = null,
                    Funcionario = funcionario,
                    Vendedor = null,
                };

                funcionario.CollectionCredorDevedorClassFuncionario.Add(cr);

            }
            else
            {
                cr.Nome = funcionario.Nome;
                cr.Cnpj = funcionario.Cpf;
                cr.Ativo = funcionario.Ativo;
            }

            cr.Save(ref command);

            return cr;
        }

        public static void ExcluirFuncionario(FuncionarioClass funcionario, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = funcionario.CollectionCredorDevedorClassFuncionario.FirstOrDefault();
            if (cr != null)
            {
                cr.Delete(ref command);
            }
        }

        public static CredorDevedorClass AtualizarVendedor(VendedorClass vendedor, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = vendedor.CollectionCredorDevedorClassVendedor.FirstOrDefault();
            if (cr == null)
            {
                cr = new CredorDevedorClass(usuario, command.Connection)
                {
                    Ativo = true,
                    Nome = vendedor.RazaoSocial,
                    Cnpj = vendedor.Cnpj,
                    TipoCredorDevedor = "VENDEDOR",
                    Fornecedor = null,
                    Cliente = null,
                    Funcionario = null,
                    Vendedor = vendedor,
                };

                vendedor.CollectionCredorDevedorClassVendedor.Add(cr);

            }
            else
            {
                cr.Nome = vendedor.RazaoSocial;
                cr.Cnpj = vendedor.Cnpj;
            }

            cr.Save(ref command);

            return cr;
        }

        public static void ExcluirVendedor(VendedorClass vendedor, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = vendedor.CollectionCredorDevedorClassVendedor.FirstOrDefault();
            if (cr != null)
            {
                cr.Delete(ref command);
            }
        }

        public static CredorDevedorClass AtualizarCliente(ClienteClass cliente, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = cliente.CollectionCredorDevedorClassCliente.FirstOrDefault();
            if (cr == null)
            {
                cr = new CredorDevedorClass(usuario, command.Connection)
                {
                    Ativo = true,
                    Nome = cliente.Nome,
                    Cnpj = cliente.Cnpj,
                    TipoCredorDevedor = "CLIENTE",
                    Fornecedor = null,
                    Vendedor = null,
                    Funcionario = null,
                    Cliente = cliente,
                };

                cliente.CollectionCredorDevedorClassCliente.Add(cr);

            }
            else
            {
                cr.Nome = cliente.Nome;
                cr.Cnpj = cliente.Cnpj;
            }

            cr.Save(ref command);

            return cr;
        }

        public static void ExcluirCliente(ClienteClass cliente, IWTPostgreNpgsqlCommand command)
        {
            CredorDevedorClass cr = cliente.CollectionCredorDevedorClassCliente.FirstOrDefault();
            if (cr != null)
            {
                cr.Delete(ref command);
            }
        }
    }
}
