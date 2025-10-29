using System;

namespace ProjectConstants
{
    public static class Constants
    {
        

        public const string BD_TYPE_CODE = "1.1";
        public const string BD_SERVER_CODE = "1.2";
        public const string BD_PORT_CODE = "1.3";
        public const string BD_USERNAME_CODE = "1.4";
        public const string BD_PASSWORD_CODE = "1.5";
        public const string BD_NAME_CODE = "1.6";
        public const string BD_FILE_NAME_CODE = "1.7";
        public const string BD_SERVER_2_CODE = "1.8";
        public const string BD_PORT_2_CODE = "1.9";

        //public const string IN_FILES_LOCATION = "2.1";
        //public const string MR_MANDATORY = "2.2";
        //public const string INVOICE_IN_LOCATION = "2.3";

        //public const string CONFIRMATION_OUT_LOCATION = "3.1";
        //public const string ASN_OUT_LOCATION = "3.2";
        //public const string INVOICE_OUT_LOCATION = "3.3";
        public const string LOG_EASI = "3.5";
        //public const string MR_OUT_LOCATION = "3.6";
      
        //public const string CONFIRMATION_TIME_INTERVAL = "4.1";
        //public const string ASN_TIME_INTERVAL = "4.2";
        //public const string INVOICE_TIME_INTERVAL = "4.3";
        //public const string EXPORT_TIME_INTERVAL = "4.4";
        //public const string IMPORT_TIME_INTERVAL = "4.5";
        //public const string IMPORT_LABEL_INTERVAL = "4.6";
        public const string SESSION_LIMIT_TIME = "4.7";
        public const string INTERVALO_IMPORTACAO_PEDIDOS = "4.8";
        public const string INTERVALO_IMPORTACAO_NF_COMPRA = "4.9";

        public const string TABELA_PRECOS_AUTOMATICO = "4.10";
        public const string TABELA_PRECOS_HORA = "4.11";
        public const string TABELA_PRECOS_MINUTO = "4.12";


        public const string LEADTIME_TESTE_PADRAO = "5.1";
        public const string LEADTIME_PRAZO_PADRAO = "5.2";
        //public const string BD_PRICE_VALIDATE = "5.3";
        //public const string MR_EXE_LOCATION = "5.4";
        //public const string DAYS_BEFORE_AUTO_ASN = "5.5";
        public const string SECONDS_TO_CONF = "5.6";
        public const string BARCODE_LOCATION = "5.7";
        public const string PERCENT_CANCEL_LEFTOVER = "5.8";

        //public const string USE_PPS = "6.1";
        public const string USE_SUPPLYON = "6.2";

        public const string SMTP_HOST = "7.1";
        public const string SMTP_PORT = "7.2";
        public const string SMTP_AUTHENTICATION = "7.3";
        public const string SMTP_USER = "7.4";
        public const string SMTP_PASSWORD = "7.5";
        public const string AVISO_NF_ATIVO = "7.6";
        public const string AVISO_NF_REMETENTE = "7.7";
        public const string AVISO_NF_DESTINATARIO = "7.8";
        public const string SMTP_AUTHENTICATION_SSH = "7.9";

        

        public const string NF_EMITENTE_RAZAO = "8.1";
        public const string NF_EMITENTE_ENDERECO = "8.2";
        public const string NF_EMITENTE_CIDADE = "8.3";
        public const string NF_EMITENTE_CNPJ = "8.6";
        public const string NF_EMITENTE_IE = "8.7";
        public const string NF_EMITENTE_FAX = "8.8";
        public const string NF_EMITENTE_NUMERO = "8.9";
        public const string NF_EMITENTE_COMPLEMENTO = "8.10";
        public const string NF_EMITENTE_BAIRRO = "8.11";
        public const string NF_EMITENTE_CEP = "8.12";
        public const string NF_EMITENTE_CONTATO = "8.13";
        public const string NF_EMITENTE_TELEFONE = "8.14";
        public const string NF_CFOP_DENTRO_ESTADO = "8.15";
        public const string NF_CFOP_FORA_ESTADO = "8.16";
        public const string NF_NATUREZA_OPERACAO = "8.17";
        public const string NF_EMITENTE_OBSERVACAO  = "8.18";

        public const string NF_EMITENTE_CNAE = "8.51";
        public const string NF_EMITENTE_IM = "8.52";


        public const string NF_EMITENTE_PIS_CST = "8.40";
        public const string NF_EMITENTE_PIS_ALIQUOTA = "8.41";
        public const string NF_EMITENTE_PIS_MODALIDADE = "8.42";
        public const string NF_EMITENTE_PIS_IMPOSTO_RETIDO = "8.43";
        public const string NF_EMITENTE_COFINS_CST = "8.44";
        public const string NF_EMITENTE_COFINS_ALIQUOTA = "8.45";
        public const string NF_EMITENTE_COFINS_MODALIDADE = "8.46";
        public const string NF_EMITENTE_COFINS_IMPOSTO_RETIDO = "8.47";

        public const string NF_EMITENTE_CRT = "8.48";
        public const string NF_VERSAO_EMISSOR = "8.49";

        public const string NF_EMITENTE_CERTIFICADO = "8.50";

        public const string NF_PERMITIR_FATURAR_PEDIDO = "8.53";

        //0: Não Incluir, 1: Descrição Itens, 2: Observação
        public const string NF_INCLUIR_NUMERO_PEDIDO_NF = "8.54";

        public const string NF_AUTORIZADOS_DOWNLOAD = "8.55";
        public const string VALIDAR_PESO_VOLUMES_NFE = "8.56";


        public const string NF_PATH_OUT = "8.30";
        //public const string NF_PPS_PATH = "8.31";
        public const string NF_DAYS_TO_PAYMENT = "8.32";
        //public const string ETIQUETAS_PPS_PATH = "8.33";

        public const string INTERNAL_LABEL_PRINTER = "9.1";
        public const string EXPEDITION_LABEL_PRINTER = "9.5";
        public const string MEDIUM_LABEL_PRINTER = "9.6";
        public const string EXPEDITION_LABEL_PAPER = "9.2";
        public const string INTERNAL_LABEL_PAPER = "9.3";
        public const string MEDIUM_LABEL_PAPER = "9.7";
        public const string CONF_STATION = "9.9";
        public const string IMPRESSORA_OP = "9.10";
        public const string TIPO_ETIQUETA_EXPEDICAO = "9.11";
        public const string TIPO_ETIQUETA_RECEBIMENTO = "9.12";
        public const string TIPO_FORMULARIO_MOVIMENTACAO = "9.13";

        public const string PERMITIR_SELECAO_IMPRESSORA_EXP = "9.14";

        public const string ETIQUETA_PRODUTO_VERTICAL = "9.15";


        public const string PEDIDO_ID_OPERACAO_PADRAO = "20.1";
        public const string SEQUENCIAL_ETIQUETAS_INTERNAS = "21.1";

        public const string SEMANA_TIPO_DEFINICAO = "22.1";
        public const string SEMANA_DIA = "22.2";
        public const string UTILIZA_ESTOQUE_OP = "22.3";
        public const string PERMITIR_QTD_FRACIONARIA_OP = "22.4";

        public const string PRAZO_ARMAZENAMENTO_OP = "23.1";
        public const string SUPRIMIR_IMPRESSAO_OP_KB_ZERADA = "23.2";
        public const string SUPRIMIR_IMPRESSAO_QTD_UNITARIA_OP = "23.3";
        public const string EXIGIR_COPIA_DOC_OP_ZERADA = "23.4";

        public const string NUM_THREADS = "24.1";

        public const string ESTOQUE_N_MESES_MEDIA = "25.1";
        public const string ESTOQUE_DIAS_VERDE = "25.2";
        public const string ESTOQUE_DIAS_AMARELO = "25.3";
        public const string ESTOQUE_DIAS_VERMELHO = "25.4";
        public const string ESTOQUE_MARGEM_REVISAO_KB = "25.5";
        public const string ESTOQUE_CLASSIFICACAO_A = "25.6";
        public const string ESTOQUE_CLASSIFICACAO_B = "25.7";
        public const string ESTOQUE_INVENTARIO_PRECO_MEDIO = "25.8";
        public const string ESTOQUE_INVENTARIO_PRECO_MEDIO_MESES = "25.9";
        public const string ESTOQUE_PERMITIR_CRIAR_LOCAL_ESTOQUE = "25.10";


        public const string DIAS_PROGRAMACAO_PCP = "26.1";
        public const string DIAS_PROGRAMACAO_COMPRAS = "26.2";
        public const string DISPARO_SOLICACAO_COMPRAS = "26.3";
        public const string SUGESTAO_ACIMA_CONFIGURADO = "26.4";

        public const string NFE_COMPRA_ENTRADA = "27.1";
        public const string NFE_COMPRA_SAIDA = "27.2";
        public const string COMPRAS_EMAIL_REMETENTE = "27.3";
        public const string COMPRAS_RODAPE = "27.4";
        public const string COMPRAS_EMAIL_MENSAGEM = "27.5";



        public const string DOCUMENTOS_QTD_MAXIMA_COPIAS = "28.1";

        public const string FLUXO_APROVACAO_COMPRAS_HABILITADO = "29.05";

        public const string DIRETORIO_EXPORTACAO_CSV = "30.1";
        public const string EXPORTACAO_PEDIDOS_ATIVA = "30.2";

        public const string EXPORTACAO_CONTAS_ATIVA = "30.5";
        public const string EXPORTACAO_CONTAS_INTERVALO = "30.9";
        public const string EXPORTACAO_PEDIDOS_INTERVALO = "30.8";

        public const string PEDIDO_EMAIL_REMETENTE = "31.1"; // Para envio de email de pedidos e orcamentos
        public const string ENVIO_EMAIL_DESTINATARIO_INTERNO_PEDIDO = "31.2";
        public const string DESTINATARIO_INTERNO_PEDIDO = "31.3";
        public const string ENVIO_EMAIL_DESTINATARIO_INTERNO_ORCAMENTO = "31.4";
        public const string DESTINATARIO_INTERNO_ORCAMENTO = "31.5";
        public const string ENVIAR_EMAIL_COPIA_RELATORIO_COMISSOES = "31.6";
        public const string DESTINATARIO_EMAIL_COPIA_RELATORIO_COMISSOES = "31.7";

        public const string ENVIO_EMAIL_CONFIGURACAO_AUTOMATICA_PEDIDOS = "31.8";
        public const string DESTINATARIO_CONFIGURACAO_AUTOMATICA_PEDIDOS = "31.9";



        //Comissões
        public const string CONTA_BANCARIA_PADRAO_COMISSOES = "32.1";
        public const string CENTRO_CUSTO_PADRAO_COMISSOES = "32.2";

        public const string AVISO_CONCILIACAO_HABILITADO = "33.1";
        public const string DIAS_AVISO_CONCILIACAO = "33.2";

        public const string DIAS_AVISO_CONTA_RECORRENTE = "33.3";
        public const string AVISO_CONTA_RECORRENTE_HABILITADA = "33.4";

        public const string MESES_CALCULO_CUSTO_HORA = "34.1";
        public const string PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE = "34.2";



        //Pedido - Orcamento
        public const string TIPO_IMPRESSAO_ESPELHO_PEDIDO = "35.1";
        public const string OBSERVACAO_PADRAO_ESPELHO_PEDIDO_ORCAMENTO = "35.2";

        public const string LOGO_EMPRESA = "B_1.1";

        public const string AVISO_PEDIDO_ITEM_SEM_FATURAMENTO = "36.1";
        public const string AVISO_PEDIDO_ITEM_SEM_FATURAMENTO_DIAS = "36.2";

        public const string HISTORICO_ALTERACOES_PEDIDO = "35.3";


        public static string ESTACAO_AUTORIZADA_AUTOMACAO = "37.1";

        public static string DIAS_VALIDADE_PRECO = "DIAS_VALIDADE_PRECO";

        #region Compras

        public const string MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS = "29.1";

        public static string COMPRA_PERMITIR_SC_SABADO = "29.2";
        public static string COMPRA_PERMITIR_SC_DOMINGO = "29.3";
        public static string COMPRA_REVISAR_NOVOS_FORNEC = "29.4";


        #endregion

        #region Configurações Internas
        public const string VALIDAR_PRECOS_RECEBIMENTO = "I_01";
        public const string VALIDACAO_REVISAO_DOCUMENTO_HABILITADA = "I_02";
        public const string EXIGIR_COPIA_DOCUMENTO = "I_03";
        public const string EXIGIR_CONFERENCIA_PALLET = "I_04";
        public const string BLOQUEAR_LIBERACAO_PALLET = "I_05";
        public const string CONTROLE_CONTABIL_ENTRADA_HABILITADO = "I_06";

        //0:Sistema receita SP, 1:Receita SP + EASI Homologação, 2: EASI 
        public const string TIPO_EMISSAO_NFE = "I_07";

        //0:Produção, 1:Homologacao
        public const string AMBIENTE_EMISSAO_NFE_HOMOLOGACAO = "I_08";

        public const string PLANO_CORTE_HABILITADO = "I_09";

        public const string BLOQUEAR_ESTOQUE_NEGATIVO = "I_10";

        //0:Gerar no Cadastro do Pedido, 1: Gerar no Faturamento, 2: Gerar na baixa da Conta Receber
        public const string MODO_CONTROLE_COMISSOES = "I_11";


        public const string FATURAMENTO_DIRETO_HABILITADO = "I_12";

        public const string CONTROLE_CONSUMO_MP_ESTOQUE_HABILITADO = "I_13";

        public const string EMITENTE_NF_SECUNDARIO_HABILITADO = "I_14";

        public const string TRIBUTACAO_OPERACAO = "I_15";

        public const string IMPRESSAO_VALORES_ZERO_DANFE = "I_16";

        //0: Emissor Primário, 1: Emissor secundário
        public const string EMISSOR_NFE_SERVICO_EXT = "I_17";

        public const string PERMITE_PEDIDO_SEM_OPERACAO = "I_18";

        public const string FEEDBACK_SECUNDARIO_HABILITADO = "I_19";

        public const string TRABALHAR_COM_BLOQUEIO_PRODUTO_POR_PRECO_VENCIDO = "I_20";


        #endregion


        //ArredondamentoNF {ArredondarValores = 0, NaoArredondarValores = 1 };
        public const int ArredondamentoNF = 0;

        


        #region Configurações Usuário

        public const string ESTRUTURA_MODO_PADRAO = "UE_MODO_PADRAO";
        public const string ESTRUTURA_LARGURA_VERTICAL = "UE_LARG_VERT";
        public const string ESTRUTURA_ALTURA_VERTICAL = "UE_ALT_VERT";
        public const string ESTRUTURA_LARGURA_HORIZONTAL = "UE_LARG_HOR";
        public const string ESTRUTURA_ALTURA_HORIZONTAL = "UE_ALT_HOR";
        public const string ESTRUTURA_TAMANHO_FONTE = "UE_TAM_FONTE";
        public const string ESTRUTURA_NEGRITO = "UE_NEGRITO";
        public const string ESTRUTURA_TAMANHO_FONTE_LIGACAO = "UE_TAM_FONTE_LIG";
        public const string ESTRUTURA_NEGRITO_LIGACAO = "UE_NEGRITO_LIG";

        public const string ESTRUTURA_ALTURA_ARVORE_HORIZONTAL = "UE_ALT_HOR2";
        public const string ESTRUTURA_LARGURA_ARVORE_HORIZONTAL= "UE_LARG_HOR2";

        #endregion


        #region Configuracoes Etiqueta Cliente
        public const string ETIQUETA_CLIENTE_LASER = "ETQ_CLI_14";
        public const string ETIQUETA_CLIENTE_LASER_DPI = "ETQ_CLI_1";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA = "ETQ_CLI_2";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA = "ETQ_CLI_3";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP = "ETQ_CLI_4";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF = "ETQ_CLI_5";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ = "ETQ_CLI_6";
        public const string ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR = "ETQ_CLI_7";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA = "ETQ_CLI_8";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA = "ETQ_CLI_9";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR = "ETQ_CLI_10";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER = "ETQ_CLI_11";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS = "ETQ_CLI_12";
        public const string ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS = "ETQ_CLI_13";

        
        public const string ETIQUETA_CLIENTE_ZEBRA = "ETQ_CLI_15";
        public const string ETIQUETA_CLIENTE_ZEBRA_IMPRESSORA = "ETQ_CLI_16";
        public const string ETIQUETA_CLIENTE_ZEBRA_PAPEL = "ETQ_CLI_17";

        #endregion


        #region Permissões Avulsas

        public static string LIBERAÇAO_QUALIDADE_OP = "LIBERAÇAO_QUALIDADE_OP";

        public static string APROVACAO_DIVERGENCIA_RECEBIMENTO = "APROVACAO_DIVERGENCIA_RECEBIMENTO";


        #endregion

        public static string ID_FORNECEDOR_GAD = "ID_FORNECEDOR_GAD";
        public static string CAMINHO_LOG_NF = AppDomain.CurrentDomain.BaseDirectory+"\\LogNfe.txt";
        


        public const string NFE_ENVIO_EMAIL_HABILITADO = "NFE_1";

        public const string NFE_ENVIO_EMAIL_REMETENTE = "NFE_1.6";

        public const string NFE_ENVIO_EMAIL_XML_HABILITADO = "NFE_1.7";
        public const string NFE_ENVIO_EMAIL_XML_DESTINO = "NFE_1.7.1";

        public const string NFE_ENVIO_EMAIL_DANFE_HABILITADO = "NFE_1.8";
        public const string NFE_ENVIO_EMAIL_DANFE_DESTINO = "NFE_1.8.1";

        public const string NFE_ENVIO_EMAIL_CLIENTE_HABILITADO = "NFE_1.9";

        public const string NFE_IMPRIMIR_DANFE_HABILITADO = "NFE_2";
        public const string NFE_IMPRIMIR_DANFE_IMPRESSORA_1 = "NFE_2.1";
        public const string NFE_IMPRIMIR_DANFE_IMPRESSORA_2 = "NFE_2.2";

        public const string NFE_SALVAR_PASTA_HABILITADO = "NFE_3";
        public const string NFE_SALVAR_PASTA_DANFE = "NFE_3.1";
        public const string NFE_SALVAR_PASTA_XML = "NFE_3.2";

        public const string SIMULADOR_COMPRAS_URL_BE = "SDC_URL";
        public const string SIMULADOR_COMPRAS_USUARIO = "SDC_USUARIO";
        public const string SIMULADOR_COMPRAS_SENHA = "SDC_SENHA";
        public const string SIMULADOR_COMPRAS_HABILITADO = "SDC_HABILITADO";

        public const string MARCAR_AUTOMATICAMENTE_OC_COM_DESCONTO_PARA_NAO_ATUALIZAR_PRECO_PRODUTOS = "38";
    }
}

