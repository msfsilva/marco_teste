-- public.nfe_completa_pendentes_cancelamento definition

-- Drop table

-- DROP TABLE public.nfe_completa_pendentes_cancelamento;

CREATE TABLE public.nfe_completa_pendentes_cancelamento (
	id_nfe_completa_pendentes_cancelamento int4 DEFAULT nextval('nfe_completa_pendentes_cancel_id_nfe_completa_pendentes_can_seq'::regclass) NOT NULL,
	npc_numero int4 NOT NULL,
	npc_serie int4 NOT NULL,
	npc_cnpj_emitente varchar(30) NOT NULL,
	npc_justificativa varchar(255) NOT NULL,
	npc_homologacao int4 NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	npc_modelo varchar(10) DEFAULT '55'::character varying NOT NULL,
	CONSTRAINT nfe_completa_pendentes_cancelamento_pkey PRIMARY KEY (id_nfe_completa_pendentes_cancelamento)
);

-- Table Triggers

create trigger nfe_completa_pendentes_cancelamento_version_tr before
update
    on
    public.nfe_completa_pendentes_cancelamento for each row execute function valida_version();


-- public.nfe_completo_inutilizacao definition

-- Drop table

-- DROP TABLE public.nfe_completo_inutilizacao;

CREATE TABLE public.nfe_completo_inutilizacao (
	id_nfe_completo_inutilizacao serial4 NOT NULL,
	nci_cnpj varchar(50) NOT NULL,
	nci_uf varchar(50) NOT NULL,
	nci_serie int4 NOT NULL,
	nci_inicio int4 NOT NULL,
	nci_fim int4 NOT NULL,
	nci_justificativa varchar(255) NOT NULL,
	nci_data timestamp NOT NULL,
	nci_usuario varchar(255) NOT NULL,
	nci_xml text NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nci_homologacao int4 DEFAULT 0 NOT NULL,
	nci_modelo varchar(10) DEFAULT '55'::character varying NOT NULL,
	CONSTRAINT nfe_completo_inutilizacao_pkey PRIMARY KEY (id_nfe_completo_inutilizacao)
);

-- Table Triggers

create trigger nfe_completo_inutilizacao_version_tr before
update
    on
    public.nfe_completo_inutilizacao for each row execute function valida_version();


-- public.nfe_completo_log_chaves definition

-- Drop table

-- DROP TABLE public.nfe_completo_log_chaves;

CREATE TABLE public.nfe_completo_log_chaves (
	id_nfe_completo_log_chaves serial4 NOT NULL,
	nlc_chave varchar(255) NOT NULL,
	nlc_numero int4 NOT NULL,
	nlc_serie int4 NOT NULL,
	nlc_homologacao int2 NOT NULL,
	nlc_data timestamp DEFAULT now() NOT NULL,
	entity_uid varchar(36) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nlc_modelo varchar(10) DEFAULT '55'::character varying NOT NULL,
	CONSTRAINT nfe_completo_log_chaves_pkey PRIMARY KEY (id_nfe_completo_log_chaves)
);


-- public.nfe_completo_lote definition

-- Drop table

-- DROP TABLE public.nfe_completo_lote;

CREATE TABLE public.nfe_completo_lote (
	id_nfe_completo_lote serial4 NOT NULL,
	ncl_numero_lote int4 NOT NULL,
	ncl_recibo varchar(15) NULL,
	ncl_data_envio timestamp NOT NULL,
	ncl_situacao int2 DEFAULT 0 NOT NULL, -- 0: Enviado¶1: Processado¶2: AguardandoEnvio
	ncl_resultado_obs varchar NULL,
	ncl_cnpj_transmissor varchar(30) NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	ncl_scan int4 DEFAULT 0 NOT NULL,
	ncl_homologacao int4 DEFAULT 0 NOT NULL,
	ncl_modelo varchar(10) DEFAULT '55'::character varying NOT NULL,
	CONSTRAINT nfe_completo_lote_idx UNIQUE (ncl_numero_lote, ncl_modelo),
	CONSTRAINT nfe_completo_lote_pkey PRIMARY KEY (id_nfe_completo_lote)
);

-- Column comments

COMMENT ON COLUMN public.nfe_completo_lote.ncl_situacao IS '0: Enviado
1: Processado
2: AguardandoEnvio';

-- Table Triggers

create trigger nfe_completo_lote_version_tr before
update
    on
    public.nfe_completo_lote for each row execute function valida_version();


-- public.nfe_situacao_transmissao definition

-- Drop table

-- DROP TABLE public.nfe_situacao_transmissao;

CREATE TABLE public.nfe_situacao_transmissao (
	id_nfe_situacao_transmissao serial4 NOT NULL,
	id_nf_principal int4 NULL,
	id_nf_completo_nota int4 NULL,
	nst_nota_tipo int2 NOT NULL, -- 0: NFe¶1: NFCe¶2: NF Serviços Londrina¶9: Outros
	nst_situacao int2 DEFAULT 0 NOT NULL, -- 0:AguardandoEnvio¶1:AguardandoResposta¶2:Processada¶3:Rejeitada¶4:Denegada
	nst_mensagem varchar NOT NULL,
	nst_data_atualizacao timestamp DEFAULT now() NOT NULL,
	nst_nota_numero int4 NULL,
	nst_nota_serie varchar NULL,
	nst_nota_modelo varchar NOT NULL,
	nst_nota_emitente varchar NOT NULL,
	nst_nota_destinatario varchar NOT NULL,
	nst_nota_data_emissao timestamp NOT NULL,
	nst_nota_chave varchar NULL,
	nst_nota_endereco_consulta_direto varchar NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nfe_londrina int4 NULL,
	nst_xml_enviado text NULL,
	CONSTRAINT nfe_situacao_transmissao_pkey PRIMARY KEY (id_nfe_situacao_transmissao)
);

-- Column comments

COMMENT ON COLUMN public.nfe_situacao_transmissao.nst_nota_tipo IS '0: NFe
1: NFCe
2: NF Serviços Londrina
9: Outros';
COMMENT ON COLUMN public.nfe_situacao_transmissao.nst_situacao IS '0:AguardandoEnvio
1:AguardandoResposta
2:Processada
3:Rejeitada
4:Denegada';


-- public.nf_principal definition

-- Drop table

-- DROP TABLE public.nf_principal;

CREATE TABLE public.nf_principal (
	id_nf_principal serial4 NOT NULL,
	nfp_numero int4 NOT NULL,
	nfp_natureza_operacao varchar(60) NOT NULL,
	nfp_serie int4 NOT NULL,
	nfp_forma_pagamento int4 NOT NULL,
	nfp_modelo_doc_fiscal varchar(2) NOT NULL,
	nfp_data_emissao timestamp NOT NULL,
	nfp_data_saida_entrada timestamp NULL,
	nfp_tipo int4 NOT NULL, -- 0: Nota de Entrada¶1: Nota de Saida
	nfp_cod_municipio_fato_gerador int4 NOT NULL,
	nfp_formato_impressao int4 NOT NULL,
	nfp_forma_emissao int4 NOT NULL,
	nfp_identificacao_ambiente int4 NOT NULL,
	nfp_finalidade_emissao int4 NOT NULL,
	nfp_processo_emissao int4 NOT NULL,
	nfp_versao_processo_emissao varchar(20) NOT NULL,
	nfp_tipo_emitente bpchar(1) DEFAULT 'P'::bpchar NOT NULL,
	nfp_situacao bpchar(1) DEFAULT 'N'::bpchar NOT NULL, -- N: Normal¶S: Cancelado¶2: Denegado - Exclusivo para modelo 55¶4: Uso inutilizado - Exclusivo para modelo 55
	nfp_observacoes varchar(5000) NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfp_observacoes_fisco varchar(2000) NULL,
	nfp_enviar_nfe_receita int2 DEFAULT 0 NOT NULL,
	nfp_homologacao int4 DEFAULT 0 NOT NULL,
	impressa int2 DEFAULT 0 NOT NULL,
	nfp_enviar_nfse_londrina int4 DEFAULT 0 NOT NULL,
	nfp_tributada_emissor int2 DEFAULT 1 NOT NULL,
	nfp_bc_iss_retido float8 DEFAULT 0 NOT NULL,
	nfp_valor_iss_retido float8 DEFAULT 0 NOT NULL,
	nfp_rps_numero int4 NULL,
	nfp_rps_serie varchar(10) NULL,
	nfp_rps_data date NULL,
	nfp_consumidor_final int2 DEFAULT 0 NOT NULL,
	nfp_presenca_comprador int2 DEFAULT 9 NOT NULL,
	id_nf_principal_substituida int4 NULL,
	nfp_texto_qr_code varchar(600) NULL,
	nfp_impressao_danfe_liberada int2 DEFAULT 0 NOT NULL,
	nfp_impressao_danfe_contingencia int2 DEFAULT 0 NOT NULL,
	nfp_estoque_movimentado int2 NULL,
	CONSTRAINT nf_principal_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_principal_fk FOREIGN KEY (id_nf_principal_substituida) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Column comments

COMMENT ON COLUMN public.nf_principal.nfp_tipo IS '0: Nota de Entrada
1: Nota de Saida';
COMMENT ON COLUMN public.nf_principal.nfp_situacao IS 'N: Normal
S: Cancelado
2: Denegado - Exclusivo para modelo 55
4: Uso inutilizado - Exclusivo para modelo 55';

-- Table Triggers

create trigger nf_principal_tr after
insert
    on
    public.nf_principal for each row execute function iwt_trigger_nf_principal();
create trigger nf_principal_version_tr before
update
    on
    public.nf_principal for each row execute function valida_version();


-- public.nf_principal_autorizacao_xml definition

-- Drop table

-- DROP TABLE public.nf_principal_autorizacao_xml;

CREATE TABLE public.nf_principal_autorizacao_xml (
	id_nf_principal_autorizacao_xml int8 DEFAULT nextval('nf_principal_autorizacao_xml_id_nf_principal_autorizacao_xm_seq'::regclass) NOT NULL,
	id_nf_principal int8 NOT NULL,
	nax_documento varchar NOT NULL,
	entity_uid varchar(36) NOT NULL,
	"version" int4 NOT NULL,
	CONSTRAINT nf_principal_autorizacao_xml_pkey PRIMARY KEY (id_nf_principal_autorizacao_xml),
	CONSTRAINT nf_principal_autorizacao_xml_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE
);


-- public.nf_totais definition

-- Drop table

-- DROP TABLE public.nf_totais;

CREATE TABLE public.nf_totais (
	id_nf_principal int4 NOT NULL,
	nfo_base_calculo_icms float8 NOT NULL,
	nfo_valor_total_icms float8 NOT NULL,
	nfo_base_calculo_icms_st float8 NOT NULL,
	nfo_valor_total_icms_st float8 NOT NULL,
	nfo_valor_total_produtos_servicos_icms float8 NOT NULL,
	nfo_valor_total_frete float8 NOT NULL,
	nfo_valor_total_seguro float8 NOT NULL,
	nfo_valor_total_desconto float8 NOT NULL,
	nfo_valor_total_desconto_ii float8 NOT NULL,
	nfo_valor_total_ipi float8 NOT NULL,
	nfo_valor_total_pis float8 NOT NULL,
	nfo_valor_total_cofins float8 NOT NULL,
	nfo_outras_despesas float8 NOT NULL,
	nfo_valor_total_nf float8 NOT NULL,
	nfo_valor_total_servicos float8 NULL,
	nfo_base_calculo_iss float8 NULL,
	nfo_valor_total_iss float8 NULL,
	nfo_valor_total_pis_servicos float8 NULL,
	nfo_valor_total_cofins_servicos float8 NULL,
	nfo_valor_total_iimp float8 NOT NULL,
	nfo_valor_total_icms_diferido float8 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfo_valor_retido_pis float8 NULL,
	nfo_valor_retido_cofins float8 NULL,
	nfo_valor_retido_csll float8 NULL,
	nfo_valor_retido_bc_irrf float8 NULL,
	nfo_valor_retido_irrf float8 NULL,
	nfo_valor_retido_bc_previdencia float8 NULL,
	nfo_valor_retido_previencia float8 NULL,
	id_nf_totais serial4 NOT NULL,
	nfo_valor_total_aproximado_tributos float8 NULL,
	nfo_valor_total_icms_desonerado float8 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_totais_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_totais_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_totais_version_tr before
update
    on
    public.nf_totais for each row execute function valida_version();


-- public.nf_transporte definition

-- Drop table

-- DROP TABLE public.nf_transporte;

CREATE TABLE public.nf_transporte (
	id_nf_principal int4 NOT NULL,
	nft_modalidade int2 NOT NULL,
	nft_razao varchar(60) NULL,
	nft_ie varchar(24) NULL,
	nft_endereco varchar(60) NULL,
	nft_sigla_uf varchar(2) NULL,
	nft_municipio varchar(60) NULL,
	nft_cpf_cnpj varchar(14) NULL,
	nft_volumes int4 NULL,
	nft_peso_liquido float8 NULL,
	nft_peso_bruto float8 NULL,
	nft_placa varchar(8) NULL,
	nft_registro_antt varchar(20) NULL,
	nft_sigla_uf_veiculo varchar(2) NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nft_volume_especie varchar(60) NULL,
	nft_volume_marca varchar(60) NULL,
	id_nf_transporte serial4 NOT NULL,
	CONSTRAINT nf_transporte_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_transporte_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_transporte_version_tr before
update
    on
    public.nf_transporte for each row execute function valida_version();


-- public.nfe_completo_nota definition

-- Drop table

-- DROP TABLE public.nfe_completo_nota;

CREATE TABLE public.nfe_completo_nota (
	id_nfe_completo_nota serial4 NOT NULL,
	id_nfe_completo_lote int4 NOT NULL,
	nfn_numero int4 NOT NULL,
	nfn_xml text NOT NULL,
	nfn_situacao int2 DEFAULT 0 NOT NULL, -- 0:Enviada,¶1:Autorizada,¶2:Denegada,¶3:Cancelada,¶4:NaoEncontrada,¶5:Rejeitada¶6:NFC-e Aguardando Envio
	nfn_data_situacao timestamp(0) NOT NULL,
	nfn_situacao_observacao varchar NULL,
	nfn_danfe_impressa int2 DEFAULT 0 NOT NULL,
	nfn_xml_gerado int2 DEFAULT 0 NOT NULL,
	nfn_chave varchar(50) NOT NULL,
	nfn_data_emissao date NOT NULL,
	nfn_cnpj_emitente varchar(50) NOT NULL,
	nfn_serie int4 NOT NULL,
	nfn_xml_cancelamento text NULL,
	nfn_data_cancelamento timestamp(0) NULL,
	nfn_justificativa_cancelamento varchar(255) NULL,
	nfn_usuario_cancelamento varchar(255) NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfn_homologacao int4 DEFAULT 0 NOT NULL,
	nfn_modelo varchar(10) DEFAULT '55'::character varying NOT NULL,
	id_nf_principal int4 NULL,
	CONSTRAINT nfe_completo_nota_idx UNIQUE (nfn_chave),
	CONSTRAINT nfe_completo_nota_idx1 UNIQUE (nfn_numero, nfn_serie, nfn_homologacao, nfn_cnpj_emitente, nfn_modelo),
	CONSTRAINT nfe_completo_nota_pkey PRIMARY KEY (id_nfe_completo_nota),
	CONSTRAINT nfe_completo_nota_fk FOREIGN KEY (id_nfe_completo_lote) REFERENCES public.nfe_completo_lote(id_nfe_completo_lote) ON DELETE CASCADE,
	CONSTRAINT nfe_completo_nota_fk1 FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE SET NULL
);

-- Column comments

COMMENT ON COLUMN public.nfe_completo_nota.nfn_situacao IS '0:Enviada,
1:Autorizada,
2:Denegada,
3:Cancelada,
4:NaoEncontrada,
5:Rejeitada
6:NFC-e Aguardando Envio';

-- Table Triggers

create trigger nfe_completo_nota_version_tr before
update
    on
    public.nfe_completo_nota for each row execute function valida_version();


-- public.nf_atributo definition

-- Drop table

-- DROP TABLE public.nf_atributo;

CREATE TABLE public.nf_atributo (
	nfa_versao_layout varchar(255) NOT NULL,
	nfa_id_nfe varchar(255) NOT NULL,
	id_nf_principal int4 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_atributo serial4 NOT NULL,
	CONSTRAINT nf_atributo_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_atributo_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_atributo_version_tr before
update
    on
    public.nf_atributo for each row execute function valida_version();


-- public.nf_cliente definition

-- Drop table

-- DROP TABLE public.nf_cliente;

CREATE TABLE public.nf_cliente (
	id_nf_principal int4 NOT NULL,
	nfc_razao varchar(60) NOT NULL,
	nfc_nome_fantasia varchar(60) NULL,
	nfc_ie varchar(14) NULL,
	nfc_cnpj_cpf varchar(14) NULL,
	nfc_isuf varchar(9) NULL,
	nfc_email varchar(60) NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_cliente serial4 NOT NULL,
	nfc_im varchar(60) NULL,
	nfc_indicador_ie int2 NULL, -- 0: Contribuinte ICMS¶1: Isento¶2: N?o Contribuinte
	nfc_email_xml varchar NULL,
	nfc_email_danfe varchar NULL,
	CONSTRAINT nf_cliente_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_cliente_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE UNIQUE INDEX nf_cliente_id_nf_cliente_key ON public.nf_cliente USING btree (id_nf_cliente);

-- Column comments

COMMENT ON COLUMN public.nf_cliente.nfc_indicador_ie IS '0: Contribuinte ICMS
1: Isento
2: N?o Contribuinte';

-- Table Triggers

create trigger nf_cliente_tr after
insert
    on
    public.nf_cliente for each row execute function iwt_trigger_nf_cliente();
create trigger nf_cliente_version_tr before
update
    on
    public.nf_cliente for each row execute function valida_version();


-- public.nf_cliente_endereco definition

-- Drop table

-- DROP TABLE public.nf_cliente_endereco;

CREATE TABLE public.nf_cliente_endereco (
	nce_logradouro varchar(60) NOT NULL,
	nce_numero varchar(60) NOT NULL,
	nce_complemento varchar(60) NULL,
	nce_bairro varchar(60) NOT NULL,
	nce_cod_municipio int4 NOT NULL,
	nce_nome_municipio varchar(60) NULL,
	nce_sigla_uf varchar(2) NOT NULL,
	nce_cep varchar(8) NULL,
	nce_cod_pais int4 NOT NULL,
	nce_nome_pais varchar(60) NULL,
	nce_telefone varchar(15) NULL,
	id_nf_principal int4 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_cliente_endereco serial4 NOT NULL,
	CONSTRAINT nf_cliente_endereco_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_cliente_endereco_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_cliente(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_cliente_endereco_version_tr before
update
    on
    public.nf_cliente_endereco for each row execute function valida_version();


-- public.nf_cobranca definition

-- Drop table

-- DROP TABLE public.nf_cobranca;

CREATE TABLE public.nf_cobranca (
	id_nf_principal int4 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_cobranca serial4 NOT NULL,
	CONSTRAINT nf_cobranca_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_cobranca_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE UNIQUE INDEX nf_cobranca_id_nf_cobranca_key ON public.nf_cobranca USING btree (id_nf_cobranca);

-- Table Triggers

create trigger nf_cobranca_version_tr before
update
    on
    public.nf_cobranca for each row execute function valida_version();


-- public.nf_depende definition

-- Drop table

-- DROP TABLE public.nf_depende;

CREATE TABLE public.nf_depende (
	id_nf_depende bigserial NOT NULL,
	id_nf_principal int8 NOT NULL,
	id_nf_principal_depende int8 NOT NULL,
	entity_uid varchar(36) NOT NULL,
	"version" int4 NOT NULL,
	CONSTRAINT nf_depende_pkey PRIMARY KEY (id_nf_depende),
	CONSTRAINT nf_depende_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE,
	CONSTRAINT nf_depende_fk1 FOREIGN KEY (id_nf_principal_depende) REFERENCES public.nf_principal(id_nf_principal) ON DELETE RESTRICT
);


-- public.nf_duplicata definition

-- Drop table

-- DROP TABLE public.nf_duplicata;

CREATE TABLE public.nf_duplicata (
	id_nf_duplicata serial4 NOT NULL,
	id_nf_principal int4 NOT NULL,
	nfd_numero varchar(60) NULL,
	nfd_vencimento date NOT NULL,
	nfd_valor float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_duplicata_pkey PRIMARY KEY (id_nf_duplicata),
	CONSTRAINT nf_duplicata_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_cobranca(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_duplicata_version_tr before
update
    on
    public.nf_duplicata for each row execute function valida_version();


-- public.nf_emitente definition

-- Drop table

-- DROP TABLE public.nf_emitente;

CREATE TABLE public.nf_emitente (
	id_nf_principal int4 NOT NULL,
	nfe_razao varchar(60) NOT NULL,
	nfe_nome_fantasia varchar(60) NULL,
	nfe_ie varchar(14) NOT NULL,
	nfe_ie_st varchar(14) NULL,
	nfe_im varchar(15) NULL,
	nfe_cnae varchar(7) NULL,
	nfe_cnpj_cpf varchar(14) NOT NULL,
	nfe_crt int4 DEFAULT 3 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_emitente serial4 NOT NULL,
	nfe_aliquota_simples_servico float8 DEFAULT 0 NOT NULL,
	nfe_identificado_csc varchar(6) NULL,
	nfe_codigo_seguranca_csc varchar(36) NULL,
	CONSTRAINT nf_emitente_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_emitente_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE UNIQUE INDEX nf_emitente_id_nf_emitente_key ON public.nf_emitente USING btree (id_nf_emitente);

-- Table Triggers

create trigger nf_emitente_tr after
insert
    on
    public.nf_emitente for each row execute function iwt_trigger_nf_emitente();
create trigger nf_emitente_version_tr before
update
    on
    public.nf_emitente for each row execute function valida_version();


-- public.nf_emitente_endereco definition

-- Drop table

-- DROP TABLE public.nf_emitente_endereco;

CREATE TABLE public.nf_emitente_endereco (
	id_nf_principal int4 NOT NULL,
	nee_logradouro varchar(60) NOT NULL,
	nee_numero varchar(60) NOT NULL,
	nee_complemento varchar(60) NULL,
	nee_bairro varchar(60) NOT NULL,
	nee_cod_municipio int4 NOT NULL,
	nee_nome_municipio varchar(60) NULL,
	nee_sigla_uf varchar(2) NOT NULL,
	nee_cep varchar(8) NULL,
	nee_cod_pais int4 NOT NULL,
	nee_nome_pais varchar(60) NULL,
	nee_telefone varchar(15) NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_emitente_endereco serial4 NOT NULL,
	id_nf_emitente int4 NOT NULL,
	CONSTRAINT nf_emitente_endereco_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_emitente_endereco_fk FOREIGN KEY (id_nf_emitente) REFERENCES public.nf_emitente(id_nf_emitente) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED,
	CONSTRAINT nf_emitente_endereco_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_emitente(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_emitente_endereco_version_tr before
update
    on
    public.nf_emitente_endereco for each row execute function valida_version();


-- public.nf_extras definition

-- Drop table

-- DROP TABLE public.nf_extras;

CREATE TABLE public.nf_extras (
	id_nf_extras serial4 NOT NULL,
	nfx_texto text NOT NULL,
	id_nf_principal int4 NOT NULL,
	nfx_texto_v2 text NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_extras_pkey PRIMARY KEY (id_nf_extras),
	CONSTRAINT nf_extras_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_extras_version_tr before
update
    on
    public.nf_extras for each row execute function valida_version();


-- public.nf_fatura definition

-- Drop table

-- DROP TABLE public.nf_fatura;

CREATE TABLE public.nf_fatura (
	id_nf_principal int4 NOT NULL,
	nff_numero varchar(60) NULL,
	nff_valor_original float8 NOT NULL,
	nff_desconto float8 NOT NULL,
	nff_valor_liquido float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_fatura serial4 NOT NULL,
	CONSTRAINT nf_fatura_id_nf_fatura_key UNIQUE (id_nf_fatura),
	CONSTRAINT nf_fatura_pkey PRIMARY KEY (id_nf_principal),
	CONSTRAINT nf_fatura_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_cobranca(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_fatura_version_tr before
update
    on
    public.nf_fatura for each row execute function valida_version();


-- public.nf_item definition

-- Drop table

-- DROP TABLE public.nf_item;

CREATE TABLE public.nf_item (
	id_nf_item serial4 NOT NULL,
	id_nf_principal int4 NOT NULL,
	nfi_numero_item int4 NOT NULL,
	nfi_informacoes_add varchar(500) NULL,
	nfi_cfop int4 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfi_valor_total_aproximado_tributos float8 NULL,
	nfi_cfop_partilha_icms int2 DEFAULT 0 NOT NULL,
	nfi_alquota_fundo_combate_pobreza float8 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_item_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_id_nf_principal_fkey FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE INDEX nf_item_idx ON public.nf_item USING btree (id_nf_principal, nfi_numero_item);

-- Table Triggers

create trigger nf_item_version_tr before
update
    on
    public.nf_item for each row execute function valida_version();


-- public.nf_item_tributo definition

-- Drop table

-- DROP TABLE public.nf_item_tributo;

CREATE TABLE public.nf_item_tributo (
	id_nf_item int4 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE UNIQUE INDEX nf_item_tributo_id_nf_item_tributo_key ON public.nf_item_tributo USING btree (id_nf_item_tributo);

-- Table Triggers

create trigger nf_item_tributo_version_tr before
update
    on
    public.nf_item_tributo for each row execute function valida_version();


-- public.nf_item_tributo_cofins definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_cofins;

CREATE TABLE public.nf_item_tributo_cofins (
	id_nf_item int4 NOT NULL,
	nto_cst varchar(2) NOT NULL,
	nto_aliquota float8 NOT NULL,
	nto_modalidade_tributacao int2 NOT NULL,
	nto_valor_bc float8 NOT NULL,
	nto_quantidade_vendida float8 NOT NULL,
	nto_valor_cofins float8 NOT NULL,
	nto_imposto_retido int2 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo_cofins serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_cofins_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_cofins_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_cofins_version_tr before
update
    on
    public.nf_item_tributo_cofins for each row execute function valida_version();


-- public.nf_item_tributo_icms definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_icms;

CREATE TABLE public.nf_item_tributo_icms (
	id_nf_item int4 NOT NULL,
	ntc_origem int2 NOT NULL,
	ntc_cst varchar(3) NOT NULL,
	ntc_modalidade_bc_icms int2 NOT NULL,
	ntc_percentual_reducao_bc float8 NOT NULL,
	ntc_valor_bc float8 NOT NULL,
	ntc_aliquota float8 NOT NULL,
	ntc_valor_icms float8 NOT NULL,
	ntc_modalidade_bc_st int2 NOT NULL,
	ntc_percentual_mva_st float8 NOT NULL,
	ntc_percentual_reducao_bc_st float8 NOT NULL,
	ntc_valor_bc_st float8 NOT NULL,
	ntc_aliquota_st float8 NOT NULL,
	ntc_valor_icms_st float8 NOT NULL,
	ntc_codigo_antecipacao_st bpchar(1) NOT NULL,
	ntc_percentual_diferimento float8 NOT NULL,
	ntc_obs_diferimento varchar(255) NULL,
	ntc_icms_diferido float8 DEFAULT 0 NOT NULL,
	ntc_percentual_bc_operacao_propria float8 DEFAULT 0 NOT NULL,
	ntc_sigla_uf_devido_icms varchar(2) NULL,
	ntc_valor_bc_st_retido_remetente float8 DEFAULT 0 NOT NULL,
	ntc_valor_icms_st_retido_remetente float8 DEFAULT 0 NOT NULL,
	ntc_valor_bc_st_retido_destinatario float8 DEFAULT 0 NOT NULL,
	ntc_valor_icms_st_retido_destinatario float8 DEFAULT 0 NOT NULL,
	ntc_cso_simples int4 NULL,
	ntc_aliquota_credito_simples float8 DEFAULT 0 NOT NULL,
	ntc_valor_credito_icms_simples float8 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	ntc_motivo_desoneracao_icms int2 NULL,
	id_nf_item_tributo_icms serial4 NOT NULL,
	ntc_valor_credito_presumido float8 NULL,
	ntc_observacao_credito_presumido varchar(255) NULL,
	nfc_valor_icms_operacao float8 NULL,
	ntc_observacao_credito_simples varchar NULL,
	ntc_fcp_retido_bc float8 NULL,
	ntc_fcp_retido_aliquota float8 NULL,
	ntc_fcp_retido_valor float8 NULL,
	ntc_fcp_bc float8 NULL,
	ntc_fcp_aliquota float8 NULL,
	ntc_fcp_valor float8 NULL,
	ntc_valor_icms_desonerado float8 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_item_tributo_icms_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_icms_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_icms_version_tr before
update
    on
    public.nf_item_tributo_icms for each row execute function valida_version();


-- public.nf_item_tributo_iimp definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_iimp;

CREATE TABLE public.nf_item_tributo_iimp (
	id_nf_item int4 NOT NULL,
	ntm_aliquota float8 NOT NULL,
	ntm_modalidade_tributacao int2 NOT NULL,
	ntm_valor_bc float8 NOT NULL,
	ntm_quantidade_vendida float8 NOT NULL,
	ntm_valor_iimp float8 NOT NULL,
	ntm_valor_despesas_aduaneiras float8 NOT NULL,
	ntm_valor_iof float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo_iimp serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_iimp_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_iimp_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_iimp_version_tr before
update
    on
    public.nf_item_tributo_iimp for each row execute function valida_version();


-- public.nf_item_tributo_ipi definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_ipi;

CREATE TABLE public.nf_item_tributo_ipi (
	id_nf_item int4 NOT NULL,
	nti_classe_enquadramento_cigarros_bebidas varchar(3) NULL,
	nti_cnpj_produtor varchar(14) NULL,
	nti_classe_enquadramento varchar(3) NULL,
	nti_codigo_selo_controle varchar(100) NULL,
	nti_quantidade_selo_controle int4 NULL,
	nti_cst varchar(2) NOT NULL,
	nti_valor_bc float8 NOT NULL,
	nti_aliquota float8 NOT NULL,
	nti_valor_ipi float8 NOT NULL,
	nti_modalidade_tributacao int2 NOT NULL,
	nti_quantidade_vendida float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo_ipi serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_ipi_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_ipi_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_ipi_version_tr before
update
    on
    public.nf_item_tributo_ipi for each row execute function valida_version();


-- public.nf_item_tributo_iss definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_iss;

CREATE TABLE public.nf_item_tributo_iss (
	id_nf_item int4 NOT NULL,
	nts_codigo_servico int4 NOT NULL,
	nts_cod_municipio_fato_gerador int4 NOT NULL,
	nts_aliquota float8 NOT NULL,
	nts_bc float8 NOT NULL,
	nts_valor_iss float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo_iss serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_iss_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_iss_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_iss_version_tr before
update
    on
    public.nf_item_tributo_iss for each row execute function valida_version();


-- public.nf_item_tributo_pis definition

-- Drop table

-- DROP TABLE public.nf_item_tributo_pis;

CREATE TABLE public.nf_item_tributo_pis (
	id_nf_item int4 NOT NULL,
	ntp_cst varchar(2) NOT NULL,
	ntp_aliquota float8 NOT NULL,
	ntp_modalidade_tributacao int2 NOT NULL,
	ntp_valor_bc float8 NOT NULL,
	ntp_quantidade_vendida float8 NOT NULL,
	ntp_valor_pis float8 NOT NULL,
	ntp_imposto_retido int2 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_item_tributo_pis serial4 NOT NULL,
	CONSTRAINT nf_item_tributo_pis_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_item_tributo_pis_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item_tributo(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_item_tributo_pis_version_tr before
update
    on
    public.nf_item_tributo_pis for each row execute function valida_version();


-- public.nf_notas_relacionadas definition

-- Drop table

-- DROP TABLE public.nf_notas_relacionadas;

CREATE TABLE public.nf_notas_relacionadas (
	id_nf_notas_relacionadas serial4 NOT NULL,
	id_nf_principal int4 NOT NULL,
	nfn_chave varchar(44) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	CONSTRAINT nf_notas_relacionadas_pkey PRIMARY KEY (id_nf_notas_relacionadas),
	CONSTRAINT nf_notas_relacionadas_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_notas_relacionadas_version_tr before
update
    on
    public.nf_notas_relacionadas for each row execute function valida_version();


-- public.nf_pagamento definition

-- Drop table

-- DROP TABLE public.nf_pagamento;

CREATE TABLE public.nf_pagamento (
	id_nf_pagamento serial4 NOT NULL,
	id_nf_principal int4 NOT NULL,
	nfg_tipo int2 DEFAULT 1 NOT NULL, -- 1:Dinheiro¶2:Cheque¶3:CartaoCredito¶4:CartaoDebito¶5:CreditoLoja¶10:ValeAlimentacao¶11:ValeRefeicao¶12:ValePresente¶13:ValeCombustivel¶99:Outros
	nfg_valor float8 NOT NULL,
	nfg_cnpj_credenciadora varchar(14) NULL,
	nfg_bandeira int2 NULL, -- 1:Visa¶2:Mastercard¶3:American¶4:Sorocred¶99:Outros
	nfg_numero_autorizacao varchar(20) NULL,
	nfg_tipo_integracao int2 NULL, -- 1:PagamentoIntegrado¶2:PagamentoNaoIntegrado
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfg_troco float8 NULL,
	nfg_tipo_descricao varchar(60) NULL,
	CONSTRAINT nf_pagamento_pkey PRIMARY KEY (id_nf_pagamento),
	CONSTRAINT nf_pagamento_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Column comments

COMMENT ON COLUMN public.nf_pagamento.nfg_tipo IS '1:Dinheiro
2:Cheque
3:CartaoCredito
4:CartaoDebito
5:CreditoLoja
10:ValeAlimentacao
11:ValeRefeicao
12:ValePresente
13:ValeCombustivel
99:Outros';
COMMENT ON COLUMN public.nf_pagamento.nfg_bandeira IS '1:Visa
2:Mastercard
3:American
4:Sorocred
99:Outros';
COMMENT ON COLUMN public.nf_pagamento.nfg_tipo_integracao IS '1:PagamentoIntegrado
2:PagamentoNaoIntegrado';


-- public.nf_produto definition

-- Drop table

-- DROP TABLE public.nf_produto;

CREATE TABLE public.nf_produto (
	id_nf_item int4 NOT NULL,
	nfp_codigo varchar(60) NOT NULL,
	nfp_descricao varchar(1400) NOT NULL,
	nfp_gtin varchar(14) NULL,
	nfp_ncm varchar(8) NULL,
	nfp_extipi varchar(3) NULL,
	nfp_genero varchar(2) NULL,
	nfp_unidade varchar(6) NOT NULL,
	nfp_valor_unitario float8 NOT NULL,
	nfp_gtim_unidade_trinutacao varchar(14) NULL,
	nfp_unidade_tributacao varchar(6) NOT NULL,
	nfp_valor_unitario_trinutacao float8 NOT NULL,
	nfp_quantidade_tributavel float8 NOT NULL,
	nfp_valor_total_tributavel float8 NOT NULL,
	nfp_valor_frete float8 NOT NULL,
	nfp_valor_seguro float8 NOT NULL,
	nfp_valor_desconto float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	nfp_quantidade float8 DEFAULT 0 NOT NULL,
	nfp_outras_despesas_acessorias float8 DEFAULT 0 NOT NULL,
	id_nf_produto serial4 NOT NULL,
	nfp_xped varchar(15) NULL,
	nfp_numero_item_pedido int4 NULL,
	nfp_cest varchar(7) NULL,
	nfp_codigo_beneficio varchar(10) NULL,
	nfp_tipo_produto_especifico int2 DEFAULT 0 NOT NULL, -- 0:Produto Comum¶1: Medicamento
	nfp_medicamento_codigo_anvisa varchar(13) NULL,
	nfp_medicamento_preco_maximo_consumidor float8 NULL,
	nfp_percentual_mercadoria_devolvida float8 NULL,
	nfp_valor_ipi_devolvido float8 NULL,
	CONSTRAINT nf_produto_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);
CREATE UNIQUE INDEX nf_produto_id_nf_produto_key ON public.nf_produto USING btree (id_nf_produto);

-- Column comments

COMMENT ON COLUMN public.nf_produto.nfp_tipo_produto_especifico IS '0:Produto Comum
1: Medicamento';

-- Table Triggers

create trigger nf_produto_version_tr before
update
    on
    public.nf_produto for each row execute function valida_version();


-- public.nf_produto_cofins definition

-- Drop table

-- DROP TABLE public.nf_produto_cofins;

CREATE TABLE public.nf_produto_cofins (
	id_nf_item int4 NOT NULL,
	npo_cst varchar(2) NOT NULL,
	npo_aliquota float8 NOT NULL,
	npo_modadlidade_tributacao int2 NOT NULL,
	npo_imposto_retido int2 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_produto_cofins serial4 NOT NULL,
	CONSTRAINT nf_produto_cofins_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_cofins_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_cofins_version_tr before
update
    on
    public.nf_produto_cofins for each row execute function valida_version();


-- public.nf_produto_icms definition

-- Drop table

-- DROP TABLE public.nf_produto_icms;

CREATE TABLE public.nf_produto_icms (
	id_nf_item int4 NOT NULL,
	npc_cst varchar(3) NOT NULL,
	npc_origem int2 NOT NULL,
	npc_modalidade_determinacao_bc int2 NOT NULL,
	npc_aliquota float8 NOT NULL,
	npc_aliquota_st float8 NOT NULL,
	npc_percentual_reducao_bc float8 NOT NULL,
	npc_modalidade_determinacao_bc_st int2 NOT NULL,
	npc_percentual_reducao_bc_st float8 NOT NULL,
	npc_percentual_mva_st float8 NOT NULL,
	npc_codigo_antecipacao_st bpchar(1) NOT NULL,
	npc_percentual_diferimento float8 NOT NULL,
	npc_obs_diferimento varchar(255) NULL,
	npc_percentual_bc_operacao_propria float8 DEFAULT 0 NOT NULL,
	npc_sigla_uf_devido_icms varchar(2) NULL,
	npc_valor_bc_st_retido_remetente float8 DEFAULT 0 NOT NULL,
	npc_valor_icms_st_retido_remetente float8 DEFAULT 0 NOT NULL,
	npc_valor_bc_st_retido_destinatario float8 DEFAULT 0 NOT NULL,
	npc_valor_icms_st_retido_destinatario float8 DEFAULT 0 NOT NULL,
	npc_cso_simples int4 NULL,
	npc_aliquota_credito_simples float8 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	npc_motivo_desoneracao_icms int2 NULL,
	id_nf_produto_icms serial4 NOT NULL,
	npc_percentual_credito_presumido float8 NULL,
	npc_percentual_limite_credito_presumido float8 NULL,
	npc_observacao_credito_presumido varchar(255) NULL,
	npc_observacao_credito_simples varchar NULL,
	npc_fcp_retido_bc float8 NULL,
	npc_fcp_retido_aliquota float8 NULL,
	npc_fcp_retido_valor float8 NULL,
	npc_aliquota_suportada_consumidor_final float8 NULL,
	CONSTRAINT nf_produto_icms_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_icms_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_icms_version_tr before
update
    on
    public.nf_produto_icms for each row execute function valida_version();


-- public.nf_produto_iimp definition

-- Drop table

-- DROP TABLE public.nf_produto_iimp;

CREATE TABLE public.nf_produto_iimp (
	id_nf_item int4 NOT NULL,
	npm_modalidade_tributacao int2 NOT NULL,
	npm_aliquota float8 NOT NULL,
	npm_valor_despesas_aduaneiras float8 NOT NULL,
	npm_valor_iof float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_produto_iimp serial4 NOT NULL,
	CONSTRAINT nf_produto_iimp_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_iimp_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_iimp_version_tr before
update
    on
    public.nf_produto_iimp for each row execute function valida_version();


-- public.nf_produto_ipi definition

-- Drop table

-- DROP TABLE public.nf_produto_ipi;

CREATE TABLE public.nf_produto_ipi (
	id_nf_item int4 NOT NULL,
	npi_classe_enquadramento_cigarros_bebidas varchar(3) NULL,
	npi_cnpj_produtor varchar(14) NULL,
	npi_classe_enquadramento varchar(3) NULL,
	npi_cst varchar(2) NOT NULL,
	npi_aliquota float8 NOT NULL,
	npi_modalidade_tributacao int2 NOT NULL,
	npi_quantidade_vendida float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_produto_ipi serial4 NOT NULL,
	CONSTRAINT nf_produto_ipi_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_ipi_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_ipi_version_tr before
update
    on
    public.nf_produto_ipi for each row execute function valida_version();


-- public.nf_produto_iss definition

-- Drop table

-- DROP TABLE public.nf_produto_iss;

CREATE TABLE public.nf_produto_iss (
	id_nf_item int4 NOT NULL,
	nps_codigo_servico int4 NOT NULL,
	nps_cod_municipio_fato_gerador int4 NOT NULL,
	nps_aliquota float8 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_produto_iss serial4 NOT NULL,
	CONSTRAINT nf_produto_iss_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_iss_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_iss_version_tr before
update
    on
    public.nf_produto_iss for each row execute function valida_version();


-- public.nf_produto_pis definition

-- Drop table

-- DROP TABLE public.nf_produto_pis;

CREATE TABLE public.nf_produto_pis (
	id_nf_item int4 NOT NULL,
	npp_cst varchar(2) NOT NULL,
	npp_aliquota float8 NOT NULL,
	npp_modadlidade_tributacao int2 NOT NULL,
	npp_imposto_retido int2 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	id_nf_produto_pis serial4 NOT NULL,
	CONSTRAINT nf_produto_pis_pkey PRIMARY KEY (id_nf_item),
	CONSTRAINT nf_produto_pis_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_pis_version_tr before
update
    on
    public.nf_produto_pis for each row execute function valida_version();


-- public.nf_produto_rastreabilidade definition

-- Drop table

-- DROP TABLE public.nf_produto_rastreabilidade;

CREATE TABLE public.nf_produto_rastreabilidade (
	id_nf_produto_rastreabilidade serial4 NOT NULL,
	id_nf_produto int4 NOT NULL,
	npr_numero_lote varchar(20) NOT NULL,
	npr_quantidade float8 NOT NULL,
	npr_data_fabricacao date NOT NULL,
	npr_data_validade date NOT NULL,
	npr_codigo_agregacao varchar(20) NULL,
	entity_uid varchar(36) NOT NULL,
	"version" int4 NOT NULL,
	CONSTRAINT nf_produto_rastreabilidade_pkey PRIMARY KEY (id_nf_produto_rastreabilidade),
	CONSTRAINT nf_produto_rastreabilidade_fk FOREIGN KEY (id_nf_produto) REFERENCES public.nf_produto(id_nf_produto) ON DELETE CASCADE
);


-- public.nfe_completo_carta_correcao definition

-- Drop table

-- DROP TABLE public.nfe_completo_carta_correcao;

CREATE TABLE public.nfe_completo_carta_correcao (
	id_nfe_completo_carta_correcao serial4 NOT NULL,
	id_nfe_completo_nota int4 NOT NULL,
	ncc_numero_lote int4 NOT NULL,
	ncc_data_hora timestamptz NOT NULL,
	ncc_sequencial int4 NOT NULL,
	ncc_texto varchar(1000) NOT NULL,
	ncc_xml text NULL,
	ncc_retorno int4 NULL,
	ncc_retorno_detalhado varchar NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	CONSTRAINT nfe_completo_carta_correcao_pkey PRIMARY KEY (id_nfe_completo_carta_correcao),
	CONSTRAINT nfe_completo_carta_correcao_fk FOREIGN KEY (id_nfe_completo_nota) REFERENCES public.nfe_completo_nota(id_nfe_completo_nota) ON DELETE CASCADE
);

-- Table Triggers

create trigger nfe_completo_carta_correcao_version_tr before
update
    on
    public.nfe_completo_carta_correcao for each row execute function valida_version();


-- public.nf_produto_declaracao_importacao definition

-- Drop table

-- DROP TABLE public.nf_produto_declaracao_importacao;

CREATE TABLE public.nf_produto_declaracao_importacao (
	id_nf_produto_declaracao_importacao int4 DEFAULT nextval('nf_produto_declaracao_importa_id_produto_declaracao_importa_seq'::regclass) NOT NULL,
	id_nf_item int4 NOT NULL,
	npd_numero_doc_importacao varchar(12) NOT NULL,
	npd_data_registro_di date NOT NULL,
	npd_local_desembaraco varchar(60) NOT NULL,
	npd_uf_desembaraco varchar(2) NOT NULL,
	npd_data_desembaraco date NOT NULL,
	npd_codigo_exportador varchar(60) NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	npd_via_transporte int4 DEFAULT 4 NOT NULL,
	npd_valor_afrmm float8 NULL,
	npd_tipo_intermedio int4 DEFAULT 1 NOT NULL,
	npd_cnpj_adquirente varchar NULL,
	npd_uf_terceiro varchar NULL,
	CONSTRAINT nf_produto_declaracao_importacao_pkey PRIMARY KEY (id_nf_produto_declaracao_importacao),
	CONSTRAINT nf_produto_declaracao_importacao_id_nf_item_fkey FOREIGN KEY (id_nf_item) REFERENCES public.nf_produto_iimp(id_nf_item) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_declaracao_importacao_version_tr before
update
    on
    public.nf_produto_declaracao_importacao for each row execute function valida_version();


-- public.nf_produto_declaracao_importacao_adicao definition

-- Drop table

-- DROP TABLE public.nf_produto_declaracao_importacao_adicao;

CREATE TABLE public.nf_produto_declaracao_importacao_adicao (
	id_nf_produto_declaracao_importacao_adicao int4 DEFAULT nextval('nf_produto_declaracao_importa_id_nf_produto_declaracao_impo_seq'::regclass) NOT NULL,
	id_nf_produto_declaracao_importacao int4 NOT NULL,
	npa_numero int4 NOT NULL,
	npa_numero_sequencial_item int4 NOT NULL,
	npa_codigo_fabricante varchar(60) NOT NULL,
	npa_valor_desconto_item_di float8 NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	CONSTRAINT nf_produto_declaracao_importacao_adicao_pkey PRIMARY KEY (id_nf_produto_declaracao_importacao_adicao),
	CONSTRAINT nf_produto_declaracao_importa_id_produto_declaracao_import_fkey FOREIGN KEY (id_nf_produto_declaracao_importacao) REFERENCES public.nf_produto_declaracao_importacao(id_nf_produto_declaracao_importacao) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED
);

-- Table Triggers

create trigger nf_produto_declaracao_importacao_adicao_version_tr before
update
    on
    public.nf_produto_declaracao_importacao_adicao for each row execute function valida_version();


-- public.nf_principal_cancelamento_justificativa definition

-- Drop table

-- DROP TABLE public.nf_principal_cancelamento_justificativa;

CREATE TABLE public.nf_principal_cancelamento_justificativa (
	id_nf_principal_cancelamento_justificativa int4 DEFAULT nextval('nf_principal_cancelamento_jus_id_nf_principal_cancelamento__seq'::regclass) NOT NULL,
	id_nf_principal int4 NOT NULL,
	ncj_justificativa varchar(255) NOT NULL,
	id_acs_usuario int4 NOT NULL,
	ncj_data timestamp DEFAULT now() NOT NULL,
	"version" int4 DEFAULT 0 NOT NULL,
	entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
	CONSTRAINT nf_principal_cancelamento_justificativa_pkey PRIMARY KEY (id_nf_principal_cancelamento_justificativa)
);

-- Table Triggers

create trigger nf_principal_cancelamento_justificativa_version_tr before
update
    on
    public.nf_principal_cancelamento_justificativa for each row execute function valida_version();


-- public.nf_principal_cancelamento_justificativa foreign keys

ALTER TABLE public.nf_principal_cancelamento_justificativa ADD CONSTRAINT nf_principal_cancelamento_justificativa_fk FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE DEFERRABLE INITIALLY DEFERRED;
ALTER TABLE public.nf_principal_cancelamento_justificativa ADD CONSTRAINT nf_principal_cancelamento_justificativa_fk1 FOREIGN KEY (id_acs_usuario) REFERENCES public.acs_usuario(id_acs_usuario) ON DELETE RESTRICT;