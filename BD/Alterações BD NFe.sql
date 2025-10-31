-- 
-- FRENTE 1: DDL (Data Definition Language) para NT 2025.002 (Reforma Tributária)
-- Dialeto: PostgreSQL (Padrões de nomenclatura e tipos ajustados)
-- Versão completa e final.
--

-- =======================================================================
-- PARTE 1: ALTERAÇÕES EM TABELAS EXISTENTES
-- =======================================================================

-- Adiciona o flag de controle "compoe_total" nas tabelas de ORIGEM de tributos existentes.
-- O cliente (aplicação principal) definirá este flag.
ALTER TABLE public.nf_produto_icms ADD COLUMN npc_compoe_total smallint NOT NULL DEFAULT 1;
ALTER TABLE public.nf_produto_ipi ADD COLUMN npi_compoe_total smallint NOT NULL DEFAULT 1;
ALTER TABLE public.nf_produto_pis ADD COLUMN npp_compoe_total smallint NOT NULL DEFAULT 1;
ALTER TABLE public.nf_produto_cofins ADD COLUMN npo_compoe_total smallint NOT NULL DEFAULT 1;

-- Adiciona os novos campos de TOTAIS (Grupos W02 e W17) na tabela nf_totais
ALTER TABLE public.nf_totais ADD COLUMN nfo_total_ibs double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_total_cbs double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_total_is double precision DEFAULT 0;

-- CORREÇÃO GAP 3: Adicionar campos faltantes de TOTAIS (Grupo W17)
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_ibs_cred double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_ibs_dif double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_ibs_dev double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_ibs_ret double precision DEFAULT 0;

ALTER TABLE public.nf_totais ADD COLUMN nfo_v_cbs_cred double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_cbs_dif double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_cbs_dev double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_cbs_ret double precision DEFAULT 0;

ALTER TABLE public.nf_totais ADD COLUMN nfo_v_is_dev double precision DEFAULT 0;
ALTER TABLE public.nf_totais ADD COLUMN nfo_v_is_ret double precision DEFAULT 0;


-- Adiciona novos campos de cabeçalho (Grupo B) na nf_principal
-- (Prefixos: npr - Nota PRincipal)
ALTER TABLE public.nf_principal ADD COLUMN npr_c_class_trib varchar(2) NULL;
ALTER TABLE public.nf_principal ADD COLUMN npr_fin_deb smallint NULL;
ALTER TABLE public.nf_principal ADD COLUMN npr_fin_cred smallint NULL;

-- Adiciona novos campos de produto (Grupo I) na nf_produto
-- (Prefixos: npd - Nota ProDuto)
-- (Assumindo que a tabela de produto principal do item é 'nf_produto' com base no DDL original)
ALTER TABLE public.nf_produto ADD COLUMN npd_ind_subst smallint NULL;
ALTER TABLE public.nf_produto ADD COLUMN npd_ind_escala char(1) NULL;
ALTER TABLE public.nf_produto ADD COLUMN npd_ind_cred_nfe smallint NULL;
ALTER TABLE public.nf_produto ADD COLUMN npd_c_benef varchar(10) NULL; -- GAP FINAL: cBenef (I18b) movido para nível de produto


-- =======================================================================
-- PARTE 2: NOVAS TABELAS DE "PRODUTO" (ORIGEM / PARÂMETROS)
-- =======================================================================

-- 2.1. Tabela nf_produto_ibs (Grupo UB - IBS)
-- Prefixo: npb (Nota Produto IBS)
CREATE TABLE public.nf_produto_ibs (
    id_nf_produto_ibs BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos da NT 2025.002 (Tags UB03 em diante)
    npb_cst_ibs varchar(2) NULL,
    npb_v_base_calc_ibs double precision NULL,
    npb_p_ibs double precision NULL,
    npb_v_base_calc_ibs_ret double precision NULL,
    npb_p_ibs_ret double precision NULL,
    npb_ind_ret_ibs smallint NULL,       -- 1=Retido; 2=Subst; 3=Retido/Subst
    npb_ind_dif_ibs smallint NULL,       -- 1=Diferido; 2=Susp; 3=Dif/Susp
    
    -- Flag estratégico de controle
    npb_compoe_total smallint NOT NULL DEFAULT 1,
    
    -- Colunas padrão (baseado no DDL existente)
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_produto_ibs_pkey PRIMARY KEY (id_nf_produto_ibs),
    CONSTRAINT nf_produto_ibs_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_produto_ibs
create trigger nf_produto_ibs_version_tr before
update
    on
    public.nf_produto_ibs for each row execute function valida_version();


-- 2.2. Tabela nf_produto_cbs (Grupo UB - CBS)
-- Prefixo: nps (Nota Produto CBS)
CREATE TABLE public.nf_produto_cbs (
    id_nf_produto_cbs BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos da NT 2025.002 (Tags UB26 em diante)
    nps_cst_cbs varchar(2) NULL,
    nps_v_base_calc_cbs double precision NULL,
    nps_p_cbs double precision NULL,
    nps_v_base_calc_cbs_ret double precision NULL,
    nps_p_cbs_ret double precision NULL,
    nps_ind_ret_cbs smallint NULL,       -- 1=Retido; 2=Subst; 3=Retido/Subst
    nps_ind_dif_cbs smallint NULL,       -- 1=Diferido; 2=Susp; 3=Dif/Susp
    
    -- Flag estratégico de controle
    nps_compoe_total smallint NOT NULL DEFAULT 1,

    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_produto_cbs_pkey PRIMARY KEY (id_nf_produto_cbs),
    CONSTRAINT nf_produto_cbs_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_produto_cbs
create trigger nf_produto_cbs_version_tr before
update
    on
    public.nf_produto_cbs for each row execute function valida_version();


-- 2.3. Tabela nf_produto_is (Imposto Seletivo)
-- Prefixo: npl (Nota Produto IS - Seletivo)
CREATE TABLE public.nf_produto_is (
    id_nf_produto_is BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos da NT 2025.002 (Tags UC03 em diante)
    npl_cst_is varchar(2) NULL,
    npl_v_base_calc_is double precision NULL,
    npl_p_is double precision NULL,
    npl_v_base_calc_is_ret double precision NULL,
    npl_p_is_ret double precision NULL,
    npl_ind_is_ret smallint NULL,    -- 1=Retido; 2=Subst; 3=Retido/Subst
    npl_ind_som_is smallint NULL,    -- 0=Não; 1=Soma (vProd); 2=Soma (vTotTrib)
    
    -- Flag estratégico de controle
    npl_compoe_total smallint NOT NULL DEFAULT 1,

    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_produto_is_pkey PRIMARY KEY (id_nf_produto_is),
    CONSTRAINT nf_produto_is_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_produto_is
create trigger nf_produto_is_version_tr before
update
    on
    public.nf_produto_is for each row execute function valida_version();


-- =======================================================================
-- PARTE 3: NOVAS TABELAS DE "TRIBUTO" (CALCULADO)
-- =======================================================================

-- 3.1. Tabela nf_tributo_ibs
-- Prefixo: ntb (Nota Tributo IBS)
CREATE TABLE public.nf_tributo_ibs (
    id_nf_tributo_ibs BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos Calculados (espelho de nf_tributo_icms e tags da NT)
    ntb_v_bc_ibs double precision NULL,
    ntb_v_ibs double precision NULL,
    ntb_v_bc_ibs_ret double precision NULL,
    ntb_v_ibs_ret double precision NULL,
    ntb_v_ibs_dif double precision NULL,
    ntb_v_ibs_dev double precision NULL,
    ntb_p_ibs double precision NULL, -- Alíquota (para referência)
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_tributo_ibs_pkey PRIMARY KEY (id_nf_tributo_ibs),
    CONSTRAINT nf_tributo_ibs_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_tributo_ibs
create trigger nf_tributo_ibs_version_tr before
update
    on
    public.nf_tributo_ibs for each row execute function valida_version();


-- 3.2. Tabela nf_tributo_cbs
-- Prefixo: nts (Nota Tributo CBS)
CREATE TABLE public.nf_tributo_cbs (
    id_nf_tributo_cbs BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos Calculados (espelho de nf_tributo_icms e tags da NT)
    nts_v_bc_cbs double precision NULL,
    nts_v_cbs double precision NULL,
    nts_v_bc_cbs_ret double precision NULL,
    nts_v_cbs_ret double precision NULL,
    nts_v_cbs_dif double precision NULL,
    nts_v_cbs_dev double precision NULL,
    nts_p_cbs double precision NULL, -- Alíquota (para referência)
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_tributo_cbs_pkey PRIMARY KEY (id_nf_tributo_cbs),
    CONSTRAINT nf_tributo_cbs_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_tributo_cbs
create trigger nf_tributo_cbs_version_tr before
update
    on
    public.nf_tributo_cbs for each row execute function valida_version();


-- 3.3. Tabela nf_tributo_is
-- Prefixo: ntl (Nota Tributo IS - Seletivo)
CREATE TABLE public.nf_tributo_is (
    id_nf_tributo_is BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos Calculados (espelho de nf_tributo_icms e tags da NT)
    ntl_v_bc_is double precision NULL,
    ntl_v_is double precision NULL,
    ntl_v_bc_is_ret double precision NULL,
    ntl_v_is_ret double precision NULL,
    ntl_v_is_dev double precision DEFAULT 0, -- Campo de devolução (GAP 2)
    ntl_p_is double precision NULL, -- Alíquota (para referência)
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_tributo_is_pkey PRIMARY KEY (id_nf_tributo_is),
    CONSTRAINT nf_tributo_is_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_tributo_is
create trigger nf_tributo_is_version_tr before
update
    on
    public.nf_tributo_is for each row execute function valida_version();

-- =======================================================================
-- PARTE 4: ADIÇÃO DO GRUPO I90 (Item Referenciado)
-- =======================================================================

-- 4.1. Tabela nf_item_referenciado (Grupo I90 - itemRef)
-- Prefixo: nir (Nota Item Referenciado)
CREATE TABLE public.nf_item_referenciado (
    id_nf_item_referenciado BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos da NT 2025.002 (Tags I91 em diante)
    nir_n_item_ref int4 NULL,                   -- nItemRef (Seq do item na NF-e referenciada)
    nir_ind_orig_cred smallint NULL,            -- indOrigCred (Origem do crédito)
    nir_chave_nfe_ref varchar(44) NULL,         -- chNFeRef (Chave da NF-e referenciada)
    nir_v_cred_or_ref double precision NULL,    -- vCredOrRef (Valor do crédito)
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_item_referenciado_pkey PRIMARY KEY (id_nf_item_referenciado),
    CONSTRAINT nf_item_referenciado_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_item_referenciado
create trigger nf_item_referenciado_version_tr before
update
    on
    public.nf_item_referenciado for each row execute function valida_version();

-- =======================================================================
-- PARTE 5: ADIÇÃO DO GRUPO UA (impostoDevol)
-- =======================================================================

-- 5.1. Tabela nf_produto_devolucao (ORIGEM / PARÂMETROS)
-- Prefixo: npv (Nota Produto DeVolução)
CREATE TABLE public.nf_produto_devolucao (
    id_nf_produto_devolucao BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos da NT 2025.002 (Tag UA02)
    npv_p_dev double precision NULL, -- Percentual da devolução
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_produto_devolucao_pkey PRIMARY KEY (id_nf_produto_devolucao),
    CONSTRAINT nf_produto_devolucao_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_produto_devolucao
create trigger nf_produto_devolucao_version_tr before
update
    on
    public.nf_produto_devolucao for each row execute function valida_version();

-- 5.2. Tabela nf_tributo_devolucao (CALCULADO)
-- Prefixo: ntv (Nota Tributo DeVolução)
CREATE TABLE public.nf_tributo_devolucao (
    id_nf_tributo_devolucao BIGSERIAL NOT NULL,
    id_nf_item int4 NOT NULL,
    
    -- Campos Calculados (Tags UA03 em diante)
    ntv_v_ipi_dev double precision NULL,
    ntv_v_bc_icms_dev double precision NULL,
    ntv_v_icms_dev double precision NULL,
    ntv_v_bc_icms_st_dev double precision NULL,
    ntv_v_icms_st_dev double precision NULL,
    ntv_v_pis_dev double precision NULL,
    ntv_v_cofins_dev double precision NULL,
    
    -- Colunas padrão
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    
    CONSTRAINT nf_tributo_devolucao_pkey PRIMARY KEY (id_nf_tributo_devolucao),
    CONSTRAINT nf_tributo_devolucao_fk_item FOREIGN KEY (id_nf_item) REFERENCES public.nf_item(id_nf_item) ON DELETE CASCADE
);

-- Trigger de versão para nf_tributo_devolucao
create trigger nf_tributo_devolucao_version_tr before
update
    on
    public.nf_tributo_devolucao for each row execute function valida_version();

-- CORREÇÃO DDL (FRENTE 1) - Adiciona campos de origem faltantes

-- Para nf_produto_ibs
ALTER TABLE public.nf_produto_ibs ADD COLUMN npb_v_ibs_dif double precision DEFAULT 0;
ALTER TABLE public.nf_produto_ibs ADD COLUMN npb_v_ibs_dev double precision DEFAULT 0;

-- Para nf_produto_cbs
ALTER TABLE public.nf_produto_cbs ADD COLUMN nps_v_cbs_dif double precision DEFAULT 0;
ALTER TABLE public.nf_produto_cbs ADD COLUMN nps_v_cbs_dev double precision DEFAULT 0;

-- Para nf_produto_is
ALTER TABLE public.nf_produto_is ADD COLUMN npl_v_is_dev double precision DEFAULT 0;

-- CORREÇÃO DDL (FRENTE 1) - Adiciona colunas de VALOR DE CRÉDITO

ALTER TABLE public.nf_tributo_ibs ADD COLUMN ntb_v_ibs_cred double precision DEFAULT 0;
ALTER TABLE public.nf_tributo_cbs ADD COLUMN nts_v_cbs_cred double precision DEFAULT 0;

ALTER TABLE public.nf_tributo_ibs ADD COLUMN ntb_cst_ibs varchar(2) not NULL;
ALTER TABLE public.nf_tributo_cbs ADD COLUMN nts_cst_cbs varchar(2) not NULL;



/* ====================================================================== */
/* SCRIPT FINAL DE ADEQUAÇÃO DDL (FRENTE 1) v2.md                         */
/* ====================================================================== */

-- 1. AJUSTES NO HEADER (nf_principal)
ALTER TABLE public.nf_principal
    ADD COLUMN npr_c_mun_fg_ibs varchar(7) NULL,                     -- (B12a) cMunFGIBS
    ADD COLUMN npr_tp_nf_debito varchar(2) NULL,                     -- (B25.1) tpNFDebito
    ADD COLUMN npr_tp_nf_credito varchar(2) NULL,                    -- (B25.2) tpNFCredito
    ADD COLUMN npr_tp_ente_gov smallint NULL,                        -- (B32) tpEnteGov
    ADD COLUMN npr_p_redutor double precision DEFAULT 0,             -- (B33) pRedutor
    ADD COLUMN npr_tp_oper_gov smallint NULL;                        -- (B34) tpOperGov

-- Remove campos sobrando da nf_principal
ALTER TABLE public.nf_principal
    DROP COLUMN npr_c_class_trib,
    DROP COLUMN npr_fin_deb,
    DROP COLUMN npr_fin_cred;

-- 2. NOVA TABELA (Grupo BB - gPagAntecipado)
CREATE TABLE public.nf_pagamento_antecipado (
    id_nf_pagamento_antecipado BIGSERIAL NOT NULL,
    id_nf_principal int4 NOT NULL,
    npa_chave_nfe_ref varchar(44) NOT NULL,                          -- (BB02) refNFe
    "version" int4 DEFAULT 0 NOT NULL,
    entity_uid varchar(36) DEFAULT ((to_char(now(), 'YYYYMMDDHH24MISSMS'::text) || ((random() * '1000000000000000'::bigint::double precision)::text))) NOT NULL,
    CONSTRAINT nf_pagamento_antecipado_pkey PRIMARY KEY (id_nf_pagamento_antecipado),
    CONSTRAINT nf_pagamento_antecipado_fk_principal FOREIGN KEY (id_nf_principal) REFERENCES public.nf_principal(id_nf_principal) ON DELETE CASCADE
);
CREATE TRIGGER nf_pagamento_antecipado_version_tr BEFORE UPDATE ON public.nf_pagamento_antecipado FOR EACH ROW EXECUTE FUNCTION valida_version();


-- 3. AJUSTES NO ITEM (nf_produto)
ALTER TABLE public.nf_produto
    ADD COLUMN npd_tp_cred_pres_ibszfm smallint NULL,                -- (I05k / UB133) tpCredPresIBSZFM
    ADD COLUMN npd_ind_bem_movel_usado smallint NULL;                -- (I117c) indBemMovelUsado

-- Remove campos sobrando da nf_produto
ALTER TABLE public.nf_produto
    DROP COLUMN npd_ind_subst,
    DROP COLUMN npd_ind_escala,
    DROP COLUMN npd_ind_cred_nfe,
    DROP COLUMN npd_c_benef;

-- 4. AJUSTES EM nf_produto_is (Parâmetros IS)
ALTER TABLE public.nf_produto_is
    ADD COLUMN npl_c_class_trib_is varchar(6) NULL,                  -- (UB03) cClassTribIS
    ADD COLUMN npl_p_is_espec double precision DEFAULT 0,            -- (UB07) pISEspec
    ADD COLUMN npl_u_trib varchar(6) NULL,                           -- (UB09) uTrib
    ADD COLUMN npl_q_trib double precision DEFAULT 0;                -- (UB10) qTrib

-- 5. AJUSTES EM nf_produto_ibs (Parâmetros IBS)
ALTER TABLE public.nf_produto_ibs RENAME COLUMN npb_p_ibs TO npb_p_ibs_uf; -- (UB18) Renomeando pIBS para pIBSUF
ALTER TABLE public.nf_produto_ibs
    ADD COLUMN npb_c_class_trib varchar(6) NULL,                     -- (UB14) cClassTrib
    ADD COLUMN npb_ind_doacao varchar(1) NULL,                       -- (UB14a) indDoacao
    ADD COLUMN npb_p_ibs_mun double precision DEFAULT 0,             -- (UB37) pIBSMun
    ADD COLUMN npb_p_dif double precision DEFAULT 0,                 -- (UB22/UB40) pDif
    ADD COLUMN npb_p_red_aliq double precision DEFAULT 0,            -- (UB27/UB45) pRedAliq
    ADD COLUMN npb_cst_reg varchar(3) NULL,                          -- (UB69) CSTReg
    ADD COLUMN npb_c_class_trib_reg varchar(6) NULL,                 -- (UB70) cClassTribReg
    ADD COLUMN npb_p_aliq_efet_reg_ibs_uf double precision DEFAULT 0,  -- (UB71) pAliqEfetRegIBSUF
    ADD COLUMN npb_p_aliq_efet_reg_ibs_mun double precision DEFAULT 0, -- (UB72a) pAliqEfetRegIBSMun
    ADD COLUMN npb_p_aliq_ibs_uf_gov double precision DEFAULT 0,     -- (UB82b) pAliqIBSUF
    ADD COLUMN npb_p_aliq_ibs_mun_gov double precision DEFAULT 0,    -- (UB82d) pAliqIBSMun
    ADD COLUMN npb_compet_apur_ajuste varchar(7) NULL,               -- (UB113) competApur
    ADD COLUMN npb_v_bc_cred_pres double precision DEFAULT 0,        -- (UB121) vBCCredPres
    ADD COLUMN npb_c_cred_pres varchar(2) NULL,                      -- (UB122) cCredPres
    ADD COLUMN npb_p_cred_pres double precision DEFAULT 0,           -- (UB124) pCredPres
    ADD COLUMN npb_compet_apur_zfm varchar(7) NULL;                  -- (UB132) competApur

-- Remove campos sobrando da nf_produto_ibs
ALTER TABLE public.nf_produto_ibs
    DROP COLUMN npb_v_base_calc_ibs_ret,
    DROP COLUMN npb_p_ibs_ret,
    DROP COLUMN npb_ind_ret_ibs,
    DROP COLUMN npb_ind_dif_ibs,
    DROP COLUMN npb_v_ibs_dif,
    DROP COLUMN npb_v_ibs_dev;

-- 6. AJUSTES EM nf_tributo_ibs (Calculado IBS)
ALTER TABLE public.nf_tributo_ibs
    ADD COLUMN ntb_v_ibs_uf double precision DEFAULT 0,              -- (UB35) vIBSUF
    ADD COLUMN ntb_v_ibs_mun double precision DEFAULT 0,             -- (UB54) vIBSMun
    ADD COLUMN ntb_p_aliq_efet double precision DEFAULT 0,           -- (UB28/UB45) pAliqEfet
    ADD COLUMN ntb_v_trib_reg_ibs_uf double precision DEFAULT 0,     -- (UB72) vTribRegIBSUF
    ADD COLUMN ntb_v_trib_reg_ibs_mun double precision DEFAULT 0,    -- (UB72b) vTribRegIBSMun
    ADD COLUMN ntb_v_trib_ibs_uf_gov double precision DEFAULT 0,     -- (UB82c) vTribIBSUF
    ADD COLUMN ntb_v_trib_ibs_mun_gov double precision DEFAULT 0,    -- (UB82e) vTribIBSMun
    ADD COLUMN ntb_v_ibs_transf_cred double precision DEFAULT 0,     -- (UB107) gTransfCred.vIBS
    ADD COLUMN ntb_v_ibs_ajuste double precision DEFAULT 0,          -- (UB114) gAjusteCompet.vIBS
    ADD COLUMN ntb_v_ibs_estorno_cred double precision DEFAULT 0,    -- (UB117) gEstornoCred.vIBSEstCred
    ADD COLUMN ntb_v_cred_pres double precision DEFAULT 0,           -- (UB125) vCredPres
    ADD COLUMN ntb_v_cred_pres_cond_sus double precision DEFAULT 0,  -- (UB126) vCredPresCondSus
    ADD COLUMN ntb_v_cred_pres_ibszfm double precision DEFAULT 0;    -- (UB134) vCredPresIBSZFM

-- Remove campos sobrando da nf_tributo_ibs
ALTER TABLE public.nf_tributo_ibs
    DROP COLUMN ntb_v_bc_ibs_ret,
    DROP COLUMN ntb_v_ibs_ret,
    DROP COLUMN ntb_p_ibs,
    DROP COLUMN ntb_v_ibs_cred;

-- 7. AJUSTES EM nf_produto_cbs (Parâmetros CBS)
ALTER TABLE public.nf_produto_cbs
    ADD COLUMN nps_c_class_trib varchar(6) NULL,                     -- (UB14) cClassTrib
    ADD COLUMN nps_ind_doacao varchar(1) NULL,                       -- (UB14a) indDoacao
    ADD COLUMN nps_p_dif double precision DEFAULT 0,                 -- (UB59) pDif
    ADD COLUMN nps_p_red_aliq double precision DEFAULT 0,            -- (UB64) pRedAliq
    ADD COLUMN nps_cst_reg varchar(3) NULL,                          -- (UB69) CSTReg
    ADD COLUMN nps_c_class_trib_reg varchar(6) NULL,                 -- (UB70) cClassTribReg
    ADD COLUMN nps_p_aliq_efet_reg_cbs double precision DEFAULT 0,   -- (UB72c) pAliqEfetRegCBS
    ADD COLUMN nps_p_aliq_cbs_gov double precision DEFAULT 0,        -- (UB82f) pAliqCBS
    ADD COLUMN nps_compet_apur_ajuste varchar(7) NULL,               -- (UB113) competApur
    ADD COLUMN nps_v_bc_cred_pres double precision DEFAULT 0,        -- (UB121) vBCCredPres
    ADD COLUMN nps_c_cred_pres varchar(2) NULL,                      -- (UB122) cCredPres
    ADD COLUMN nps_p_cred_pres double precision DEFAULT 0;           -- (UB128) pCredPres

-- Remove campos sobrando da nf_produto_cbs
ALTER TABLE public.nf_produto_cbs
    DROP COLUMN nps_v_base_calc_cbs_ret,
    DROP COLUMN nps_p_cbs_ret,
    DROP COLUMN nps_ind_ret_cbs,
    DROP COLUMN nps_ind_dif_cbs,
    DROP COLUMN nps_v_cbs_dif,
    DROP COLUMN nps_v_cbs_dev;

-- 8. AJUSTES EM nf_tributo_cbs (Calculado CBS)
ALTER TABLE public.nf_tributo_cbs
    ADD COLUMN nts_p_aliq_efet double precision DEFAULT 0,           -- (UB64) pAliqEfet
    ADD COLUMN nts_v_trib_reg_cbs double precision DEFAULT 0,        -- (UB72d) vTribRegCBS
    ADD COLUMN nts_v_trib_cbs_gov double precision DEFAULT 0,        -- (UB82g) vTribCBS
    ADD COLUMN nts_v_cbs_transf_cred double precision DEFAULT 0,     -- (UB108) gTransfCred.vCBS
    ADD COLUMN nts_v_cbs_ajuste double precision DEFAULT 0,          -- (UB115) gAjusteCompet.vCBS
    ADD COLUMN nts_v_cbs_estorno_cred double precision DEFAULT 0,    -- (UB118) gEstornoCred.vCBSEstCred
    ADD COLUMN nts_v_cred_pres double precision DEFAULT 0,           -- (UB129) vCredPres
    ADD COLUMN nts_v_cred_pres_cond_sus double precision DEFAULT 0;  -- (UB130) vCredPresCondSus

-- Remove campos sobrando da nf_tributo_cbs
ALTER TABLE public.nf_tributo_cbs
    DROP COLUMN nts_v_bc_cbs_ret,
    DROP COLUMN nts_v_cbs_ret,
    DROP COLUMN nts_p_cbs,
    DROP COLUMN nts_v_cbs_cred;

-- 9. AJUSTES EM nf_totais (Totais da NF-e)
-- Renomeia campos antigos para refletir a divisão UF/Mun
ALTER TABLE public.nf_totais RENAME COLUMN nfo_v_ibs_dif TO nfo_v_ibs_dif_uf;     -- (W38)
ALTER TABLE public.nf_totais RENAME COLUMN nfo_v_ibs_dev TO nfo_v_ibs_dev_uf;     -- (W39)
ALTER TABLE public.nf_totais RENAME COLUMN nfo_v_ibs_cred TO nfo_v_ibs_cred_pres; -- (W48)

-- Adiciona campos faltantes
ALTER TABLE public.nf_totais
    ADD COLUMN nfo_v_bc_ibscbs double precision DEFAULT 0,             -- (W35) vBCIBSCBS
    ADD COLUMN nfo_v_ibs_uf double precision DEFAULT 0,                -- (W41) vIBSUF
    ADD COLUMN nfo_v_ibs_dif_mun double precision DEFAULT 0,           -- (W43) vDif (Mun)
    ADD COLUMN nfo_v_ibs_dev_mun double precision DEFAULT 0,           -- (W44) vDevTrib (Mun)
    ADD COLUMN nfo_v_ibs_mun double precision DEFAULT 0,               -- (W46) vIBSMun
    ADD COLUMN nfo_v_ibs_cred_pres_cond_sus double precision DEFAULT 0,-- (W49) vCredPresCondSus
    ADD COLUMN nfo_v_cbs_cred_pres double precision DEFAULT 0,         -- (W56a) vCredPres (CBS)
    ADD COLUMN nfo_v_cbs_cred_pres_cond_sus double precision DEFAULT 0,-- (W56b) vCredPresCondSus (CBS)
    ADD COLUMN nfo_v_ibs_estorno_cred double precision DEFAULT 0,      -- (W59f) vIBSEstCred
    ADD COLUMN nfo_v_cbs_estorno_cred double precision DEFAULT 0;      -- (W59g) vCBSEstCred

-- Remove campos sobrando da nf_totais
ALTER TABLE public.nf_totais
    DROP COLUMN nfo_v_ibs_ret,
    DROP COLUMN nfo_v_cbs_ret,
    DROP COLUMN nfo_v_is_dev,
    DROP COLUMN nfo_v_is_ret;
 